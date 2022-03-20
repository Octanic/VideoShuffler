using System;
using VideoShuffler.Registry;

namespace VideoShuffler.EntryHandler
{
    public class EntryHandlerFactory
    {
        public enum EntryHandlerType
        {
            Registry
        }

        public static IEntryHandler GenerateHandler(EntryHandlerType HandlerType, string context )
        {
            switch (HandlerType)
            {
                case EntryHandlerType.Registry:
                    return new RegistryHandler(context);
                default:
                    throw new NotImplementedException("No Handler Found");
            }
        }
    }
}
