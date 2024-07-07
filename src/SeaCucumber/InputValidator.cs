namespace SeaCucumber;

public class InputValidator
{
    private readonly string[]? input;

    public InputValidator(string[]? input)
    {
        this.input = input;
    }

    public bool Validate(out string? notValidReason)
    {
        // input should not be null
        if (this.input == null)
        {
            notValidReason = "The input is null";
            return false;
        }

        // input should not be empty
        if (input.Length == 0)
        {
            notValidReason = "The input is empty";
            return false;
        }

        var rows = this.input.Length;
        var columns = this.input[0].Length;

        for (var i = 0; i < rows; i++)
        {
            var line = this.input[i];
            // input each row should have the same amount of columns
            if (line.Length != columns)
            {
                notValidReason = $"Line '{i}' was expected to have a length of {columns}, actual length {line.Length}";
                return false;
            }
            
            for (var j = 0; j < columns; j++)
            {
                var character = line[j];
                // each character should be either '.', '>' or 'v'
                switch (character)
                {
                    case Cell.Empty:
                    case Cell.EastFacing:
                    case Cell.SouthFacing:
                        break;
                    default:
                        notValidReason = $"Character {character} was expected to be {Cell.Empty}, {Cell.EastFacing} or {Cell.SouthFacing}";
                        return false;
                }
            }
        }

        notValidReason = null;
        return true;
    }
}