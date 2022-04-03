using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoShuffler.Registry;
using System;
using Moq;
using VideoShuffler.EntryHandler;
using System.Collections.Generic;

namespace VideoShuffler.Tests
{
    [TestClass]
    public class RegisterHandlerTests
    {
        [TestMethod]
        public void CheckRegistryPathEmptyContext()
        {
            Mock<IRegistryManager> regMock = new Mock<IRegistryManager>();
            var regi = new RegistryHandler(string.Empty, regMock.Object);
            Assert.AreEqual("SOFTWARE\\VideoShuffler\\", regi.RegistryPath);
        }

        [TestMethod]
        public void CheckRegistryPathContext()
        {
            Mock<IRegistryManager> regMock = new Mock<IRegistryManager>();
            var regi = new RegistryHandler("Joao", regMock.Object);
            Assert.AreEqual("SOFTWARE\\VideoShuffler\\Joao", regi.RegistryPath);


        }

        [TestMethod]
        public void ReadRegistryWithError()
        {
            Mock<IRegistryManager> regMock = new Mock<IRegistryManager>();
            regMock.Setup(x => x.ReadKey(It.IsAny<string>(), false)).Returns(() => null);

            var regi = new RegistryHandler("teste", regMock.Object);

            var rs = regi.Read();

            Assert.IsTrue(!string.IsNullOrEmpty(rs.Error));
            Assert.IsTrue(rs.IsValid == false);

        }

        [TestMethod]
        public void ReadRegistrySuccess()
        {
            Mock<IRegistryManager> regMock = new Mock<IRegistryManager>();
            var regi = new RegistryHandler("teste", regMock.Object);

            regMock.Setup(x => x.ReadKey(It.IsAny<string>(), It.IsAny<bool>())).Returns(() => new Dictionary<string, string>(){
                    {"PastaOrigem", "C:\\meu\\diretorio"},
                    {"AplicativoReader","app.exe"},
                    {"Filtro", "*.*"},
                    {"QtdArquivos", "4"},
                });


            var rs = regi.Read();

            Assert.IsTrue(rs.IsValid);
            Assert.IsTrue(string.IsNullOrEmpty(rs.Error));
            Assert.IsTrue(rs.Entry.AplicativoReader == "app.exe");
            Assert.IsTrue(rs.Entry.Filtro == "*.*");
            Assert.IsTrue(rs.Entry.PastaOrigem == "C:\\meu\\diretorio");
            Assert.IsTrue(rs.Entry.QtdArquivos == 4);
        }

        [TestMethod]
        public void WriteRegistryError()
        {
            Mock<IRegistryManager> mock = new Mock<IRegistryManager>();
            var regi = new RegistryHandler("teste", mock.Object);

            mock.Setup(x => x.WriteKey(It.IsAny<string>(),
                                      It.IsAny<bool>(),
                                      It.IsAny<Dictionary<string, Tuple<string, Microsoft.Win32.RegistryValueKind>>>()))
                .Throws(new AccessViolationException("access denied"));

            var rs = regi.Write(new Entry()
            {
                AplicativoReader = "teste.exe",
                Filtro = "*.*",
                PastaOrigem = "c:\\temp",
                QtdArquivos = 2
            });

            Assert.IsFalse(rs.IsValid);

        }

        [TestMethod]
        public void WriteRegistrySuccess()
        {
            Mock<IRegistryManager> mock = new Mock<IRegistryManager>();
            var regi = new RegistryHandler("teste", mock.Object);

            mock.Setup(x => x.WriteKey(It.IsAny<string>(),
                                      It.IsAny<bool>(),
                                      It.IsAny<Dictionary<string, Tuple<string, Microsoft.Win32.RegistryValueKind>>>())).Verifiable();
                

            var rs = regi.Write(new Entry()
            {
                AplicativoReader = "teste.exe",
                Filtro = "*.*",
                PastaOrigem = "c:\\temp",
                QtdArquivos = 2
            });

            Assert.IsTrue(rs.IsValid);

        }

    }
}
