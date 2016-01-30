using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Defines an area in the terrain.
/// </summary>
public class Area
{
    private readonly Block[] m_blocks;
    private HashSet<Block> m_blocksSet; 

    public Block[] Points
    {
        get { return (Block[])m_blocks.Clone(); }
    }

    public Area(Block[] blocks)
    {
        m_blocks = blocks;
        
        foreach (Block point in blocks)
        {
            m_blocksSet.Add(point);
            point.AddToArea(this);
        }
    }

    public int GetPointCount()
    {
        return m_blocks.Length;
    }

    public Block GetPoint(int index)
    {
        return m_blocks[index];
    }

    public bool Contains(Block p)
    {
        return m_blocksSet.Contains(p);
    }
}
