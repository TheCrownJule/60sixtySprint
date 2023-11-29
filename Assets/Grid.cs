using UnityEngine;
using CodeMonkey.Utils;

public class Grid<T>
{
    private int width;
    private int height;
    private T[,] gridArray; // data of the grid
    private float cellSize; // size of each cell
    private TextMesh[,] debugTextArray; // text for each cell
    private Vector3 originPosition; // origin position of the grid

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height]; // create new grid
        debugTextArray = new TextMesh[width, height]; // create new text array

        for (int x = 0; x < gridArray.GetLength(0); x++) // loop through grid
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] =
                    UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetXY(x, y) + Vector3.one * cellSize * .5f, 30, Color.white, TextAnchor.MiddleCenter); // create text for each cell
                Debug.DrawLine(GetXY(x, y), GetXY(x, y + 1), Color.white, 100f); // draw line for each cell
                Debug.DrawLine(GetXY(x, y), GetXY(x + 1, y), Color.white, 100f); // draw line for each cell 
            }
        }

        Debug.DrawLine(GetXY(0, height), GetXY(width, height), Color.white, 100f); // draw line for each cell X
        Debug.DrawLine(GetXY(width, 0), GetXY(width, height), Color.white, 100f); // draw line for each cell Y

        // Example: SetValue(2, 1, 56); // set value of cell
    }

    private Vector3 GetXY(int x, int y) // get the position of the cell
    {
        return new Vector3(x, y) * cellSize + originPosition; // return the position of the cell
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y) // get the position of the cell
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize); // get the x position of the cell
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize); // get the y position of the cell
    }

    public void SetValue(int x, int y, T value) // set the value of the cell
    {
        if (x >= 0 && y >= 0 && x < width && y < height) // if the cell is in the grid
        {
            gridArray[x, y] = value; // set the value of the cell
            Debug.Log("Set value of " + x + "," + y + " to " + value); // log the value of the cell
            debugTextArray[x, y].text = value.ToString(); // set the text of the cell
        }
    }

    public void SetValue(Vector3 worldPosition, T value) // set the value of the cell
    {
        int x, y; // create x + y variables
        GetXY(worldPosition, out x, out y); // get the x + y position of the cell
        SetValue(x, y, value); // set the value of the cell
    }

    public T GetValue(int x, int y) // get the value of the cell
    {
        if (x >= 0 && y >= 0 && x < width && y < height) // if the cell is in the grid
        {
            return gridArray[x, y]; // return the value of the cell
        }
        else
        {
            return default(T); // return the default value for the type
        }
    }

    public T GetValue(Vector3 worldPosition) // get the value of the cell
    {
        int x, y; // create x + y variables
        GetXY(worldPosition, out x, out y); // get the x + y position of the cell
        return GetValue(x, y); // return the value of the cell
    }
}
