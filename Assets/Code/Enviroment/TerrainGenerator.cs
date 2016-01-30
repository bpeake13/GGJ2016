using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SocialPlatforms.GameCenter;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float m_randomFillChance = 0.5f;

    [SerializeField]
    private int m_width = 100;
    [SerializeField]
    private int m_height = 100;

    [SerializeField]
    private int m_minAreaSize = 10;

    public TerrainData Generate()
    {
        return Generate(Random.Range(int.MinValue, int.MaxValue));
    }

    public TerrainData Generate(int seed)
    {
        System.Random rng = new System.Random(seed);
        TerrainData data = new TerrainData(m_width, m_height);

        _generateNoise(rng, data);
        _circleCull(data);
        _smoothMap(rng, data);
        _findAreas(data);
        _removeSmallAreas(data);

        return data;
    }

    private void _generateNoise(System.Random rng, TerrainData data)
    {
        int width = data.Width;
        int height = data.Height;
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                data.SetValue(x, y, rng.NextDouble() < m_randomFillChance ? 1 : 0);
            }
        }
    }

    private void _circleCull(TerrainData data)
    {
        int centerX = m_width / 2;
        int centerY = m_height / 2;
        Vector2 center = new Vector2(centerX, centerY);
        int radius = Mathf.Min(m_width, m_height) / 2;

        for (int y = 0; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                Vector2 point = new Vector2(x, y);
                if ((point - center).magnitude > radius)
                    data.SetValue(x, y, 0);
            }
        }
    }

    private void _smoothMap(System.Random rng, TerrainData data)
    {
        int width = data.Width;
        int height = data.Height;

        int[,] newData = new int[width,height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int filledCount = data.FilledNeighbors(x, y);
                if (filledCount > 4)
                {
                    data.SetValue(x, y, 1);
                }
                else if(filledCount < 4)
                {
                    data.SetValue(x, y, 0);
                }
            }
        }
    }

    private void _findAreas(TerrainData data)
    {
        HashSet<Block> visited = new HashSet<Block>();

        int width = data.Width;
        int height = data.Height;

        LinkedList<Area> areas = new LinkedList<Area>();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Block block = data.GetBlock(new Point(x, y));
                if (block.Value > 0 && !visited.Contains(block))
                {
                    Area newArea = _floodFillArea(block, visited);
                    if (newArea != null)
                        areas.AddLast(newArea);
                }
            }
        }

        foreach (Area area in areas)
        {
            data.AddArea(area);
        }
    }

    private Area _floodFillArea(Block start, HashSet<Block> visited)
    {
        TerrainData data = start.Owner;

        LinkedList<Block> flooded = new LinkedList<Block>();
        Queue<Block> frontier = new Queue<Block>();

        frontier.Enqueue(start);

        Block next;
        while (frontier.Count > 0)
        {
            next = frontier.Dequeue();

            for (int x = next.Location.X - 1; x <= next.Location.X + 1; x++)
            {
                for (int y = next.Location.Y - 1; y <= next.Location.Y + 1; y++)
                {
                    Block block = data.GetBlock(new Point(x, y));
                    if (block != null && block.Value != 0 && !visited.Contains(block))
                    {
                        flooded.AddLast(block);
                        visited.Add(block);
                        frontier.Enqueue(block);
                    }
                }
            }
        }

        if (flooded.Count > 0)
        {
            return new Section(start.Owner, flooded.ToArray());
        }
        else
        {
            return null;
        }
    }

    private void _removeSmallAreas(TerrainData data)
    {
        for (int i = 0; i < data.GetAreaCount(); i++)
        {
            Area area = data.GetArea(i);
            if (area.GetPointCount() < m_minAreaSize)
            {
                area.Obliterate();
                i--;
            }
        }
    }
}
