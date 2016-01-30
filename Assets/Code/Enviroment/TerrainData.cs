using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainData
{
    private Block[] m_data;
    private List<Area> m_areas = new List<Area>();

    private int m_width, m_height;

    public int Width
    {
        get { return m_width; }
    }

    public int Height
    {
        get { return m_height; }
    }

    public TerrainData(int width, int height)
    {
        m_width = width;
        m_height = height;
        m_data = new Block[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                m_data[y * width + x] = new Block(this, new Point(x, y), 0);
            }
        }
    }

    public int GetData(int x, int y)
    {
        return IsInBounds(x, y) ? m_data[m_width * y + x].Value : 0;
    }

    public int GetValue(Point p)
    {
        return GetData(p.X, p.Y);
    }

    public Block GetBlock(Point p)
    {
        return IsInBounds(p) ? m_data[m_width * p.Y + p.X] : null;
    }

    public void SetValue(int x, int y, int value)
    {
        if(IsInBounds(x, y))
            m_data[m_width * y + x].Value = value;
    }

    public void SetValue(Point p, int value)
    {
        SetValue(p.X, p.Y, value);
    }

    public bool IsInBounds(int x, int y)
    {
        int width = Width;
        int height = Height;
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public bool IsInBounds(Point p)
    {
        return IsInBounds(p.X, p.Y);
    }

    public int FilledNeighbors(int x, int y)
    {
        int count = 0;
        for (int gridY = y - 1; gridY <= y + 1; gridY++)
        {
            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                if (!(gridX == x && gridY == y) && GetData(gridX, gridY) > 0)
                    count ++;
            }
        }

        return count;
    }

    public int FilledNeighbors(Point p)
    {
        return FilledNeighbors(p.X, p.Y);
    }

    public void AddArea(Area area)
    {
        m_areas.Add(area);
    }

    public int GetAreaCount()
    {
        return m_areas.Count;
    }

    public Area GetArea(int index)
    {
        return m_areas[index];
    }
}
