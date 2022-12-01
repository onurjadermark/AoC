namespace Solutions.Infrastructure;

public class InputLoader
{
    private readonly int _year;
    private readonly int _day;

    public InputLoader(int year, int day)
    {
        _year = year;
        _day = day;
    }

    private string GetPath() => Path.Combine($"inputs\\{_year}", $"input_day_{_day:00}.txt");

    public T Read<T>() => (T) Convert.ChangeType(ReadAllText(), typeof(T));
    public T[] ReadLines<T>() => ReadAllLines().Select(x => (T) Convert.ChangeType(x, typeof(T))).ToArray();

    private string ReadAllText() => File.ReadAllText(GetPath());
    private string[] ReadAllLines() => File.ReadAllLines(GetPath());
}