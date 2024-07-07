using SeaCucumber;

const string inputFileName = "input.txt";

var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName);
var input = File.ReadAllLines(inputFilePath);
var inputValidator = new InputValidator(input);
var isValid = inputValidator.Validate(out var notValidReason);

if (!isValid)
{
    throw new InvalidOperationException($"The input is not valid: {notValidReason}");
}

var grid = new Grid(input);