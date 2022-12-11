namespace Solutions.Infrastructure;

internal static class Program
{
    private static void Main(string[] args)
    {
        var days = DayRunner.GetAvailableDays().ToArray();

        if (int.TryParse(args.FirstOrDefault(), out var dayParam))
        {
            if (days.Contains(dayParam))
                new DayRunner(dayParam).Run();
            else
                Console.WriteLine($"Can't find Day {dayParam}, exiting");
        }
        else
        {
            foreach (var day in days) new DayRunner(day).Run();
        }
    }
}