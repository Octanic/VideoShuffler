namespace VideoShuffler.EntryHandler
{
    /// <summary>
    /// Binds an entry with some state
    /// </summary>
    /// <typeparam name="T">Anything you want to wrap and track if it's correct, and what happend if not.</typeparam>
    public class KeyWrapper<T>
    {
        /// <summary>
        /// The actual object that can be anything
        /// </summary>
        public T Entry { get; set; }
        /// <summary>
        /// Flag that shows if this is a valid object (true) or not (false)
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Validation error bound to the failure on <para>IsValid</para> parameter.
        /// </summary>
        public string Error { get; set; }
    }
}
