namespace SeaCucumber;

public class SeaCucumberSimulator
{
    private readonly Grid map;

    public SeaCucumberSimulator(Grid map)
    {
        this.map = map ?? throw new ArgumentNullException(nameof(map));
    }
    
    public int SimulateUntilNoMovementsDetected()
    {
        var steps = 0;
        var movementDetected = false;

        do
        {
            movementDetected = this.map.MoveEastFacing();
            movementDetected = this.map.MoveSouthFacing() || movementDetected; // Ensure both movements are considered
            steps++;
        } while (movementDetected);
        
        return steps;
    }
}