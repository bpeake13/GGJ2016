using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Defines an area in the terrain.
/// </summary>
public abstract class Area
{
    private List<Block> m_blocks = new List<Block>();
    private HashSet<Block> m_blocksSet = new HashSet<Block>();

    private TerrainData m_owner;

    public Block[] Points
    {
        get { return m_blocks.ToArray(); }
    }

    public TerrainData Owner
    {
        get { return m_owner; }
    }

    public Area(TerrainData owner, Block[] blocks)
    {
        m_owner = owner;
        
        foreach (Block point in blocks)
        {
            AddPoint(point);
        }
    }

    public int GetPointCount()
    {
        return m_blocks.Count;
    }

    public Block GetPoint(int index)
    {
        return m_blocks[index];
    }

    public bool Contains(Block p)
    {
        return m_blocksSet.Contains(p);
    }

    public void AddPoint(Block block)
    {
        m_blocksSet.Add(block);
        m_blocks.Add(block);
        block.RegisterToArea(this);
    }

    public void RemovePoint(Block block)
    {
        m_blocksSet.Remove(block);
        m_blocks.Remove(block);
        block.UnregisterFromArea(this);
    }

    public void ClearArea()
    {
        m_blocksSet.Clear();

        foreach (Block block in m_blocks)
        {
            block.UnregisterFromArea(this);
        }

        m_blocks.Clear();
    }

    public void Obliterate()
    {
        while (m_blocks.Count > 0)
        {
            m_blocks[0].Value = 0;
        }

        m_owner.RemoveArea(this);
    }
}
