using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float m_randomFillChance;

    [SerializeField]
    private int m_width;
    [SerializeField]
    private int m_height;

    public TerrainData Generate()
    {
        return Generate(Random.Range(int.MinValue, int.MaxValue));
    }

    public TerrainData Generate(int seed)
    {
        System.Random rng = new System.Random(seed);
        TerrainData data = new TerrainData(m_width, m_height);

        _generateNoise(rng, data);
        _smoothMap(rng, data);

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
                data.SetData(x, y, rng.NextDouble() < m_randomFillChance ? 1 : 0);
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
                    newData[x, y] = 1;
                }
                else if(filledCount < 4)
                {
                    newData[x, y] = 0;
                }
                else
                {
                    newData[x, y] = data.GetData(x, y);
                }
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                data.SetData(x, y, newData[x, y]);
            }
        }
    }
}
