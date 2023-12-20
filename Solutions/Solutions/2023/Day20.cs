using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day20
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        var modules = new Dictionary<string, List<string>>();
        var flipFlops = new Dictionary<string, bool>();
        var conjunctions = new Dictionary<string, Dictionary<string, bool>>();
        var pulseCount = new Dictionary<bool, int> {[false] = 0, [true] = 0};
        
        foreach (var line in input)
        {
            var parts = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            var key = parts[0].Trim();
            var values = parts[1].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim()).ToList();

            if (key.StartsWith("%"))
            {
                key = key[1..];
                flipFlops.Add(key, false);
            }
            else if (key.StartsWith("&"))
            {
                key = key[1..];
                conjunctions.Add(key, new Dictionary<string, bool>());
            }
            
            modules[key] = values;
        }

        foreach (var conjunction in conjunctions)
        {
            foreach (var rule in modules.Where(rule => rule.Value.Any(x => x == conjunction.Key)))
            {
                conjunction.Value.Add(rule.Key, true);
            }
        }
      
        var finalTargets = modules.Where(x => x.Value.Contains("bn")).ToDictionary(x => x.Key, _ => new List<int>());
        
        for (var i = 0; i < (part == 1 ? 1000 : long.MaxValue); i++)
        {
            pulseCount[true]++;
            var pulses = new Queue<(string, string, bool)>();
            pulses.Enqueue(("button", "broadcaster", true));
            while (pulses.Any())
            {
                var (source, target, isLowPulse) = pulses.Dequeue();
               
                if (!modules.ContainsKey(target)) continue;
                
                var targets = modules[target];
                if (target == "broadcaster")
                {
                    targets.ForEach(x => pulses.Enqueue((target, x, isLowPulse)));
                    pulseCount[isLowPulse] += targets.Count;
                }
                else if (flipFlops.ContainsKey(target) && isLowPulse)
                {
                    targets.ForEach(x => pulses.Enqueue((target, x, flipFlops[target])));
                    pulseCount[flipFlops[target]] += targets.Count;
                    flipFlops[target] = !flipFlops[target];
                }
                else if (conjunctions.ContainsKey(target))
                {
                    conjunctions[target][source] = isLowPulse;
                    isLowPulse = !conjunctions[target].Any(y => y.Value);
                    targets.ForEach(x => pulses.Enqueue((target, x, isLowPulse)));
                    pulseCount[isLowPulse] += targets.Count;
                }
                
                if (part == 2 && i > 0)
                {
                    foreach (var finalTarget in finalTargets)
                    {
                        if (conjunctions[finalTarget.Key].All(x => x.Value) && !finalTargets[finalTarget.Key].Contains(i))
                        {
                            finalTargets[finalTarget.Key].Add(i);
                            
                            if (finalTargets.All(x => x.Value.Count > 1))
                            {
                                var diffs = finalTargets.Select(x => x.Value.Last() - x.Value.ElementAt(x.Value.Count - 2));
                                var result = Utilities.LCM(diffs);
                                return result;
                            }
                        }
                    }
                }
            }
        }
        
        return pulseCount[true] * pulseCount[false];
    }
}