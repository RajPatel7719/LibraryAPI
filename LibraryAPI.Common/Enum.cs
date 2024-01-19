namespace LibraryAPI.Common
{
    public class Enum
    {
        public enum Category
        {
            Fiction = 1,
            NonFiction,
            Mystery,
            ScienceFiction,
            Romance,
            History
        }

        public enum ResponseStatus
        {
            Error,
            Success
        }
    }
}
