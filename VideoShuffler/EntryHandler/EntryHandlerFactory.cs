using System;
using VideoShuffler.Registry;

namespace VideoShuffler.EntryHandler
{
    public class EntryHandlerFactory
    {
        public enum EntryHandlerType
        {
            Registry,File
        }

        public static IEntryHandler GenerateHandler(EntryHandlerType HandlerType, string context, IRegistryManager registryManager )
        {
            switch (HandlerType)
            {
                case EntryHandlerType.Registry:
                    return new RegistryHandler(context, registryManager);
                default:
                    throw new NotImplementedException("No Handler Found");
            }
        }
    }
}
