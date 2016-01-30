using UnityEngine;
using System.Collections;

public struct Point
{
    private int m_x, m_y;

    public int X
    {
        get { return m_x; }
    }

    public int Y
    {
        get { return m_y; }
    }

    public Point(int x, int y)
    {
        m_x = x;
        m_y = y;
    }

    public Point(Vector2 vector)
    {
        m_x = (int) vector.x;
        m_y = (int) vector.y;
    }

    public static Point operator +(Point lhs, Point rhs)
    {
        return  new Point(lhs.m_x + rhs.m_x, lhs.m_y + rhs.m_y);
    }

    public static Point operator -(Point p)
    {
        return new Point(-p.m_x, -p.m_y);
    }

    public static Point operator -(Point lhs, Point rhs)
    {
        return new Point(lhs.m_x - rhs.m_x, lhs.m_y - rhs.m_y);
    }
}
