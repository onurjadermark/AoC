namespace Solutions.Solutions._2020;

public class Day21
{
    public string Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public string Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static string Solve(string[] input, int part)
    {
        var foods = new List<Food>();
        foreach (var line in input.Select(x => x.Trim())) foods.Add(new Food(line));

        var allIngredients = foods.SelectMany(x => x.Ingredients).Distinct().ToList();
        var allAllergens = foods.SelectMany(x => x.Allergens).Distinct().ToList();


        if (part == 1)
        {
            var dangerousIngredients = new HashSet<string>();
            foreach (var ingredient in allIngredients.ToArray())
            {
                var containingFoods = foods.Where(x => x.Ingredients.Contains(ingredient)).ToList();
                foreach (var allergen in allAllergens)
                    if (foods.Except(containingFoods).All(x => !x.Allergens.Contains(allergen)))
                        dangerousIngredients.Add(ingredient);
            }

            return allIngredients.Except(dangerousIngredients)
                .Select(x => foods.Count(y => y.Ingredients.Contains(x))).Sum().ToString();
        }

        var matches = new List<(string Allergen, string Ingredient)>();
        while (true)
        {
            var allergens = allAllergens.Where(x => matches.All(y => y.Allergen != x)).ToList();
            if (!allergens.Any()) break;
            foreach (var allergen in allergens)
            {
                var containingFoods = foods.Where(x => x.Allergens.Contains(allergen));
                var possibleIngredients = containingFoods.Select(x => x.Ingredients)
                    .Aggregate((x, i) => x.Intersect(i).ToHashSet()).Where(x => matches.All(y => y.Ingredient != x))
                    .ToHashSet();
                if (possibleIngredients.Count == 1) matches.Add((allergen, possibleIngredients.Single()));
            }
        }

        return string.Join(",", matches.OrderBy(x => x.Allergen).Select(x => x.Ingredient));
    }

    private class Food
    {
        public Food(string line)
        {
            var split = line.Split("(");
            Ingredients = split[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToHashSet();
            Allergens = split[1].Replace(")", "").Replace("contains", "")
                .Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToHashSet();
        }

        public HashSet<string> Ingredients { get; }
        public HashSet<string> Allergens { get; }
    }
}