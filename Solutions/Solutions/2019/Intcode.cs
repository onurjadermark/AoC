namespace Solutions.Solutions._2019;

public class Intcode
{
    private readonly int[] _program;
    private int _position;
    
    private enum Opcode
    {
        Addition = 1,
        Multiplication = 2,
        Return = 99
    }
    
    public Intcode(int[] program)
    {
        _program = (int[]) program.Clone();
    }

    public int[] TryRun()
    {
        try
        {
            return Run();
        }
        catch
        {
            return _program;
        }
    }

    public int[] Run()
    {
        while (true)
        {
            var opcode = GetCurrentOpcode();
            if (opcode == Opcode.Addition)
            {
                _program[_program[_program[_position + 3]]] =
                    _program[_program[_position + 1]] + _program[_program[_position + 2]];
                _position += 4;
            }
            else if (opcode == Opcode.Multiplication)
            {
                _program[_program[_program[_position + 3]]] =
                    _program[_program[_position + 1]] * _program[_program[_position + 2]];
                _position += 4;
            }
            else if (opcode == Opcode.Return)
            {
                break;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        _position = 0;
        return _program;
    }

    private Opcode GetCurrentOpcode()
    {
        return (Opcode) _program[_position];
    }
}