namespace Solutions.Solutions._2024;

public class Day05
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }
    
    private int Solve(string[] input, int part)
    {
        var rules = ExtractRules(input);
        var updates = ExtractUpdates(input);
        var sum = 0;

        foreach (var update in updates)
        {
            var rulesToApply = rules.Where(update.IsRuleApplicable).ToList();
            var isValid = rulesToApply.All(update.IsRuleValid);

            sum += part == 1 
                ? isValid ? update.GetMiddlePage() : 0 
                : isValid ? 0 : update.Sort(rulesToApply).GetMiddlePage();
        }

        return sum;
    }

    private static List<Rule> ExtractRules(string[] input)
    {
        return input.TakeWhile(x => x != "").Select(x => x.Split("|").Select(int.Parse).ToList())
            .Select(x => new Rule(x[0], x[1])).ToList();
    }

    private static List<Update> ExtractUpdates(string[] input)
    {
        return input.SkipWhile(x => x != "").Skip(1).Select(x => x.Split(",").Select(int.Parse).ToList())
            .Select(x => new Update(x)).ToList();
    }

    private class Rule(int firstPage, int secondPage)
    {
        public int FirstPage { get; } = firstPage;
        public int SecondPage { get; } = secondPage;
    }

    private class Update(List<int> pages)
    {
        public List<int> Pages { get; } = pages;
        private readonly Dictionary<int, int> _pageIndexCache = new();

        public bool IsRuleApplicable(Rule rule)
        {
            var indexes = GetIndexes(rule);
            return indexes.FirstIndex != -1 && indexes.SecondIndex != -1;
        }

        public bool IsRuleValid(Rule rule)
        {
            var indexes = GetIndexes(rule);
            return IsRuleApplicable(rule) && indexes.FirstIndex < indexes.SecondIndex;
        }

        private (int FirstIndex, int SecondIndex) GetIndexes(Rule rule)
        {
            var firstIndex = GetPageIndex(rule.FirstPage);
            var secondIndex = GetPageIndex(rule.SecondPage);
            return (firstIndex, secondIndex);
        }

        private int GetPageIndex(int page)
        {
            if (_pageIndexCache.TryGetValue(page, out var cachedIndex))
            {
                return cachedIndex;
            }

            var index = Pages.IndexOf(page);
            _pageIndexCache[page] = index;
            return index;
        }

        public int GetMiddlePage()
        {
            return Pages.ElementAt(Pages.Count / 2);
        }

        public Update Sort(List<Rule> rules)
        {
            var currentPages = new List<int>(Pages);
            var sortedPages = new List<int>();
            while (currentPages.Count > 0)
            {
                foreach (var page in currentPages)
                {
                    var isEarliest = true;
                    foreach (var rule in rules)
                    {
                        if (rule.SecondPage != page || sortedPages.Contains(rule.FirstPage)) continue;
                        isEarliest = false;
                        break;
                    }

                    if (!isEarliest) continue;
                
                    sortedPages.Add(page);
                    currentPages.Remove(page);
                    break;
                }
            }

            return new Update(sortedPages);
        }
    }
}