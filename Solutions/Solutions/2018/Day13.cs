using MoreLinq;

namespace Solutions.Solutions._2018;

public class Day13
{
    public string Part1(string input)
    {
        return Solve(input, 1);
    }

    public string Part2(string input)
    {
        return Solve(input, 2);
    }

    public string Solve(string input, int part)
    {
        var lines = input.Split("\n");
        var maxLength = lines.Max(x => x.Length);
        var grid = new char[maxLength, lines.Length];

        for (var i = 0; i < lines.Length; i++)
        for (var j = 0; j < lines[i].Length; j++)
            grid[j, i] = lines[i][j];

        var cartSymbols = new[] {'^', 'v', '>', '<'};
        var carts = new List<Cart>();

        for (var i = 0; i < maxLength; i++)
        for (var j = 0; j < lines.Length; j++)
        {
            var cur = grid[i, j];
            if (!cartSymbols.Contains(cur)) continue;

            carts.Add(new Cart
            {
                X = i,
                Y = j,
                Direction = cur,
                Turn = 'l'
            });
            if (cur == '>' || cur == '<')
                grid[i, j] = '-';
            else
                grid[i, j] = '|';
        }

        var turns = new Dictionary<(char dir, char gridSymbol), char>
        {
            {('<', '/'), 'v'},
            {('^', '/'), '>'},
            {('>', '/'), '^'},
            {('v', '/'), '<'},
            {('<', '\\'), '^'},
            {('^', '\\'), '<'},
            {('>', '\\'), 'v'},
            {('v', '\\'), '>'}
        };

        var intersections = new Dictionary<(char dir, char turn), (char dir, char turn)>
        {
            {('<', 'l'), ('v', 's')},
            {('<', 's'), ('<', 'r')},
            {('<', 'r'), ('^', 'l')},
            {('^', 'l'), ('<', 's')},
            {('^', 's'), ('^', 'r')},
            {('^', 'r'), ('>', 'l')},
            {('>', 'l'), ('^', 's')},
            {('>', 's'), ('>', 'r')},
            {('>', 'r'), ('v', 'l')},
            {('v', 'l'), ('>', 's')},
            {('v', 's'), ('v', 'r')},
            {('v', 'r'), ('<', 'l')}
        };

        while (true)
        {
            if (part == 2 && carts.Count == 1) return carts.First().X + "," + carts.First().Y;

            foreach (var cart in carts.OrderBy(x => x.Y).ThenBy(x => x.X).ToList())
            {
                if (cart.Crashed) continue;

                Move(cart);

                if (grid[cart.X, cart.Y] == '+')
                {
                    var next = intersections[(cart.Direction, cart.Turn)];
                    cart.Direction = next.dir;
                    cart.Turn = next.turn;
                }

                if (grid[cart.X, cart.Y] == '\\' || grid[cart.X, cart.Y] == '/')
                    cart.Direction = turns[(cart.Direction, grid[cart.X, cart.Y])];

                if (carts.Any(x => x.X == cart.X && x.Y == cart.Y && x != cart))
                {
                    if (part == 1) return cart.X + "," + cart.Y;
                    var crashed = carts.Where(x => x.X == cart.X && x.Y == cart.Y);
                    crashed.ForEach(x => x.Crashed = true);
                }
            }

            carts.RemoveAll(x => x.Crashed);
        }
    }

    private void Move(Cart cart)
    {
        switch (cart.Direction)
        {
            case '>':
                cart.X++;
                break;
            case 'v':
                cart.Y++;
                break;
            case '<':
                cart.X--;
                break;
            case '^':
                cart.Y--;
                break;
        }
    }

    private class Cart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }
        public char Turn { get; set; }
        public bool Crashed { get; set; }
    }
}