using static LibraryAPI.Common.Enum;

namespace LibraryAPI.Common.Result
{
    public class ResultPT
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string Message { get; set; } = string.Empty;
        public dynamic Result { get; set; } = Enumerable.Empty<string>().ToArray();
    }
}
