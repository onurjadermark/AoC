namespace Solutions.Infrastructure;

public class InputLoader
{
    private readonly int _day;

    public InputLoader(int day)
    {
        _day = day;
    }

    private string GetPath() => Path.Combine("inputs", $"input_day_{_day:00}.txt");

    public T Read<T>() => (T) Convert.ChangeType(ReadAllText(), typeof(T));
    public T[] ReadLines<T>() => ReadAllLines().Select(x => (T) Convert.ChangeType(x, typeof(T))).ToArray();

    private string ReadAllText() => File.ReadAllText(GetPath());
    private string[] ReadAllLines() => File.ReadAllLines(GetPath());
}