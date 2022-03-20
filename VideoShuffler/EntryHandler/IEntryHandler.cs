namespace VideoShuffler.EntryHandler
{
    public interface IEntryHandler
    {
        KeyWrapper<Entry> Read();
        KeyWrapper<bool> Write(Entry entry);

    }
}
