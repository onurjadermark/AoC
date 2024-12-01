namespace Solutions.Infrastructure
{
    public class InputLoader
    {
        private readonly int _year;
        private readonly int _day;
        private string? _cachedInput;

        public InputLoader(int year, int day)
        {
            _year = year;
            _day = day;
        }

        private string GetPath()
        {
            string solutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Solutions");
            return Path.Combine(solutionDirectory, "inputs", $"{_year}", $"input_day_{_day:00}.txt");
        }

        public T[] ReadLines<T>()
        {
            EnsureFileExists();
            return string.IsNullOrEmpty(_cachedInput) 
                ? Array.Empty<T>() 
                : ReadAllLines().Select(x => (T) Convert.ChangeType(x, typeof(T))).ToArray();
        }

        private void EnsureFileExists()
        {
            var path = GetPath();
            if (!File.Exists(path) || IsFileEmpty(path))
            {
                DownloadFile(path);
            }
            else
            {
                _cachedInput = File.ReadAllText(path);
            }
        }

        private bool IsFileEmpty(string path)
        {
            var content = File.ReadAllText(path);
            return string.IsNullOrWhiteSpace(content);
        }

        private void DownloadFile(string path)
        {
            using var aocClient = new AocHttpClient(_year, _day);
            var response = aocClient.GetPuzzleInput().Result;

            if (response.ResponseType == ClientResponseType.Success)
            {
                _cachedInput = response.Content;
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                File.WriteAllText(path, response.Content);
            }
            else
            {
                _cachedInput = string.Empty;
            }
        }

        private string ReadAllText() => _cachedInput?.TrimEnd() ?? string.Empty;

        private string[] ReadAllLines() => ReadAllText().Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
    }
}
