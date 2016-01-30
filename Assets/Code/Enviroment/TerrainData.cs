using UnityEngine;
using System.Collections;

public class TerrainData
{
    private int[,] m_data;

    public int Width
    {
        get { return m_data.GetLength(0); }
    }

    public int Height
    {
        get { return m_data.GetLength(1); }
    }

    public TerrainData(int width, int height)
    {
        m_data = new int[width, height];
    }

    public int GetData(int x, int y)
    {
        return IsInBounds(x, y) ? m_data[x, y] : 0;
    }

    public void SetData(int x, int y, int value)
    {
        if(IsInBounds(x, y))
            m_data[x, y] = value;
    }

    public bool IsInBounds(int x, int y)
    {
        int width = Width;
        int height = Height;
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public int FilledNeighbors(int x, int y)
    {
        int count = 0;
        for (int gridY = y - 1; gridY <= y + 1; gridY++)
        {
            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                if (gridX != x && gridY != y && GetData(gridX, gridY) > 0)
                    count ++;
            }
        }

        return count;
    }
}
