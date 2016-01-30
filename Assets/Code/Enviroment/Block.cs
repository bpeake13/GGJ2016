using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block
{
    private Point m_location;

    private int m_value;

    private List<Area> m_areas = new List<Area>();
    private HashSet<Area> m_areaSet = new HashSet<Area>();

    private TerrainData m_owner;

    public Point Location
    {
        get { return m_location; }
    }

    public int Value
    {
        get { return m_value; }
        set
        {
            m_value = value;

            if (value == 0)
            {
                while (m_areas.Count > 0)
                {
                    m_areas[0].RemovePoint(this);
                }
            }
        }
    }

    public TerrainData Owner
    {
        get { return m_owner; }
    }

    public Block(TerrainData owner, Point location, int value)
    {
        m_location = location;
        m_value = value;
        m_owner = owner;
    }

    public int GetAreaCount()
    {
        return m_areas.Count;
    }

    public Area GetArea(int index)
    {
        return m_areas[index];
    }

    public bool IsInArea(Area area)
    {
        return m_areaSet.Contains(area);
    }

    public void RegisterToArea(Area area)
    {
        m_areas.Add(area);
        m_areaSet.Add(area);
    }

    public void UnregisterFromArea(Area area)
    {
        m_areas.Remove(area);
        m_areaSet.Remove(area);
    }
}
