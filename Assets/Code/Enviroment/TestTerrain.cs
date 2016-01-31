using UnityEngine;
using System.Collections;

public class TestTerrain : Terrain
{
    [SerializeField]
    private GameObject[] m_blocks = new GameObject[0];

    [SerializeField]
    private float m_blockSize = 1.0f;

    public override void Construct(TerrainData data)
    {
        Vector3 position = transform.position;

        for (int y = 0; y < data.Height; y++)
        {
            for (int x = 0; x < data.Width; x++)
            {
                if (data.GetData(x, y) > 0)
                {
                    float worldX = x * m_blockSize + position.x;
                    float worldZ = y * m_blockSize + position.z;
                    float worldY = position.y;

                    GameObject newBlock = (GameObject) Instantiate(m_blocks[data.GetData(x, y)], new Vector3(worldX, worldY, worldZ),
                        Quaternion.identity);
                }
            }
        }
    }
}
