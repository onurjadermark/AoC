namespace Solutions.Solutions._2018;

public class Day07
{
    public string Part1(string[] input)
    {
        var requirements = input.Select(x => x.Split()).Select(x => (x[1], x[7])).ToList();
        var allJobs = requirements.Select(x => x.Item1).Concat(requirements.Select(x => x.Item2)).Distinct()
            .OrderBy(x => x).ToList();
        var completedJobs = new List<string>();
        while (completedJobs.Count < allJobs.Count)
        {
            var remainingJobs = allJobs.Except(completedJobs);
            var availableJobs = remainingJobs.Except(requirements.Select(x => x.Item2)).ToList();
            var nextJob = availableJobs.ToList().OrderBy(x => x).First();
            completedJobs.Add(nextJob);
            requirements.RemoveAll(x => x.Item1 == nextJob);
        }

        return string.Join("", completedJobs);
    }

    public int Part2(string[] input)
    {
        var workerCount = input.Length == 7 ? 2 : 5;
        var requirements = input.Select(x => x.Split()).Select(x => (FirstId: x[1], SecondId: x[7])).ToList();
        var allJobs = requirements
            .Select(x => x.FirstId)
            .Concat(requirements.Select(x => x.SecondId))
            .Distinct()
            .OrderBy(x => x)
            .Select(x => new Job(x, (workerCount == 2 ? 1 : 61) + x[0] - 'A')).ToList();

        foreach (var (firstId, secondId) in requirements)
            allJobs.Single(x => x.Id == secondId).RequiredIds.Add(firstId);

        var currentMinute = 0;
        var currentJobs = new Job?[workerCount];
        while (allJobs.Any(x => x.TimeLeft != 0))
        {
            for (var j = 0; j < currentJobs.Length; j++)
            {
                var currentJob = currentJobs[j];
                if (currentJob != null)
                {
                    currentJob.TimeLeft--;
                    if (currentJob.TimeLeft == 0)
                    {
                        currentJobs[j] = null;
                        allJobs.ForEach(x => x.RequiredIds.Remove(currentJob.Id));
                    }
                }
            }

            for (var i = 0; i < workerCount; i++)
                if (currentJobs[i] == null)
                {
                    var availableJobs = allJobs.Where(x =>
                        x.TimeLeft > 0 && !x.RequiredIds.Any() && currentJobs.All(y => y == null || y != x)).ToList();
                    if (availableJobs.Any())
                    {
                        var nextJob = availableJobs.OrderBy(x => x.Id).First();
                        currentJobs[i] = nextJob;
                    }
                }

            currentMinute++;
        }


        return currentMinute - 1;
    }

    private class Job
    {
        public Job(string id, int timeLeft)
        {
            Id = id;
            TimeLeft = timeLeft;
        }

        public string Id { get; }
        public int TimeLeft { get; set; }
        public List<string> RequiredIds { get; } = new();
    }
}