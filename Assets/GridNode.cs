public class PathNode
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Grid<PathNode> Grid { get; private set; }

    public int GCost { get; set; }
    public int HCost { get; set; }
    public int FCost { get { return GCost + HCost; } }

    public PathNode CameFromNode { get; set; }

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        Grid = grid;
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return X + "," + Y;
    }
}
