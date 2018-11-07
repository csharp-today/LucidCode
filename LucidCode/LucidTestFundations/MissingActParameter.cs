namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Represents missing parameter for Act action
    /// </summary>
    public class MissingActParameter
    {
        /// <summary>
        /// Singleton value of MissingActParameter
        /// </summary>
        public static MissingActParameter Value { get; } = new MissingActParameter();

        private MissingActParameter() { }
    }
}
