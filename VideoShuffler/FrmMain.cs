using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VideoShuffler.EntryHandler;
using VideoShuffler.FileHandling;
using VideoShuffler.Registry;
using static VideoShuffler.EntryHandler.EntryHandlerFactory;

namespace VideoShuffler
{
    public partial class FrmMain : Form
    {
        private readonly string _context;
        private readonly bool _isAutoMode;
        private readonly EntryHandlerType _entryHandlerType;
        private readonly IRegistryManager _registryManager;

        public FilePairInformation[] Pathes { get; set; }
        public FrmMain(string context, bool isAutoMode, EntryHandlerType entryHandlerType, IRegistryManager regMan)
        {
            InitializeComponent();
            _context = context;
            _isAutoMode = isAutoMode;
            _entryHandlerType = entryHandlerType;
            _registryManager = regMan;
        }

        private void cmdFindFolder_Click(object sender, EventArgs e)
        {
            if (dlgBuscaDiretorio.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = dlgBuscaDiretorio.SelectedPath;
            }
        }

        private void cmdFindApp_Click(object sender, EventArgs e)
        {
            if (dlgBuscaArquivo.ShowDialog() == DialogResult.OK)
            {
                txtApp.Text = dlgBuscaArquivo.FileName;
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            if (!checkRequiredData()) return;
            KeyWrapper<bool> resp = writeRegistryData();

            if (!resp.IsValid)
            {
                MessageBox.Show($"Houve um erro ao gravar sua configuração.\n{resp.Error}.\nTente acessar com modo administrador e tente novamente.",
                     "Erro ao escrever dados",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
            else
            {
                reloadFileList();
            }

        }

        private KeyWrapper<bool> writeRegistryData()
        {
            IEntryHandler registry = EntryHandlerFactory.GenerateHandler(_entryHandlerType, _context, _registryManager);
            var resp = registry.Write(new Entry()
            {
                AplicativoReader = txtApp.Text,
                Filtro = txtFilter.Text,
                PastaOrigem = txtFolder.Text,
                QtdArquivos = Convert.ToInt32(numFileQty.Value)
            });
            return resp;
        }

        private bool checkRequiredData(bool fullCheck = false)
        {
            var erros = validateConfigData(fullCheck);

            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show($"Verifique os itens a seguir:\n{erros}",
                    "Erro ao validar configuração inicial",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;

            }

            return true;

        }

        private void reloadFileList()
        {
            if (string.IsNullOrEmpty(txtFolder.Text) || !Directory.Exists(txtFolder.Text)) return;

            listFiles.Columns.Clear();
            listFiles.Clear();

            Pathes = FileSearcher.FindFiles(txtFolder.Text, txtFilter.Text, SearchOption.AllDirectories);

            groupBox2.Text = $"Resultado ({Pathes.Length} arquivos)";

            foreach (var item in Pathes)
            {
                listFiles.Items.Add(new ListViewItem(item.FileName)).ToolTipText = item.Path;
            }

            listFiles.Columns.Add("Caminho").AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private string validateConfigData(bool fullCheck = false)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtFolder.Text) && Directory.Exists(txtFolder.Text))
            {
                errors.AppendLine("- Local dos vídeos inválido.");
            }

            if (string.IsNullOrWhiteSpace(txtApp.Text) && File.Exists(txtApp.Text))
            {
                errors.AppendLine("- Local do aplicativo de vídeo inválido.");
            }

            if (fullCheck)
            {
                if (numFileQty.Value == 0)
                {
                    errors.AppendLine("Quantidade de arquivos está zerada");
                }

                if ((Pathes?.Length ?? 0) == 0)
                {
                    errors.AppendLine("Não existem arquivos para exibir");
                }
                else if (numFileQty.Value > Pathes.Length)
                {
                    errors.AppendLine($"Quantidade de arquivos disponíveis a exibir ({numFileQty.Value}) é superior à quantidade da lista ({Pathes.Length}).");
                }
            }

            return errors.ToString();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadRegistryData();

            if (_isAutoMode)
            {
                cmdRun_Click(this, EventArgs.Empty);
            }
        }

        private void loadRegistryData()
        {
            RegistryHandler rh = new RegistryHandler(_context, _registryManager);
            var data = rh.Read();

            if (data.IsValid)
            {
                txtApp.Text = data.Entry.AplicativoReader;
                txtFilter.Text = data.Entry.Filtro;
                txtFolder.Text = data.Entry.PastaOrigem;
                numFileQty.Value = data.Entry.QtdArquivos;

                reloadFileList();
            }
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            if (checkRequiredData(true))
            {
                executeProcess();

            }
        }

        private void executeProcess()
        {
            Process pr = new Process();

            var filesToRun = Shuffler<FilePairInformation>.ShuffleAndGet(Pathes, Convert.ToInt32(numFileQty.Value));

            var app = txtApp.Text;
            var args = string.Join(" ", filesToRun.Select(x => string.Concat("\"", x.Path, "\"")).ToArray());

            pr.StartInfo = new ProcessStartInfo(app, args);
            pr.Start();

            this.Close();
        }
    }
}
