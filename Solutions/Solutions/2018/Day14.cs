namespace Solutions.Solutions._2018;

public class Day14
{
    public string Part1(string input)
    {
        var neededRecipes = int.Parse(input);
        var recipes = new List<int> {3, 7};
        var position1 = 0;
        var position2 = 1;
        while (recipes.Count < neededRecipes + 10)
        {
            var sum = recipes[position1] + recipes[position2];
            if (sum >= 10)
            {
                recipes.Add(1);
                recipes.Add(sum % 10);
            }
            else
            {
                recipes.Add(sum);
            }

            position1 = (position1 + recipes[position1] + 1) % recipes.Count;
            position2 = (position2 + recipes[position2] + 1) % recipes.Count;
        }

        return string.Join("", recipes.Skip(neededRecipes).Take(10));
    }

    public string Part2(string input)
    {
        var neededRecipe = input.ToList().Select(x => int.Parse(x.ToString())).ToList();
        var recipes = new List<int> {3, 7};
        var position1 = 0;
        var position2 = 1;
        var positionToCheck = 0;
        while (true)
        {
            var sum = recipes[position1] + recipes[position2];

            if (sum >= 10)
            {
                recipes.Add(1);
                recipes.Add(sum % 10);
            }
            else
            {
                recipes.Add(sum);
            }

            position1 = (position1 + recipes[position1] + 1) % recipes.Count;
            position2 = (position2 + recipes[position2] + 1) % recipes.Count;

            var i = 0;
            while (i + positionToCheck < recipes.Count)
                if (recipes[positionToCheck + i] == neededRecipe[i])
                {
                    if (i < neededRecipe.Count - 1)
                        i++;
                    else
                        return positionToCheck.ToString();
                }
                else
                {
                    i = 0;
                    positionToCheck++;
                }
        }
    }
}