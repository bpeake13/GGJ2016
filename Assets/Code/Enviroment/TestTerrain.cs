using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestTerrain : Terrain
{
    [SerializeField]
    private GameObject[] m_blocks = new GameObject[0];

    [SerializeField]
    private float m_blockSize = 1.0f;

    [SerializeField]
    private HeadInventoryItem[] m_headItems;

    [SerializeField]
    private ArmInventoryItem[] m_armItems;

    [SerializeField]
    private LegInventoryItem[] m_legItems;

    [SerializeField]
    private BodyInventoryItem[] m_bodyItems;

    [SerializeField]
    private GameObject m_startArea;

    [SerializeField]
    private float m_itemOffset = 0.5f;

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

                    GameObject newBlock = (GameObject) Instantiate(m_blocks[data.GetData(x, y) - 1], new Vector3(worldX, worldY, worldZ),
                        Quaternion.identity);
                }
            }
        }

        List<EmptyTerrainBlock> emptyTerrain = new List<EmptyTerrainBlock>(FindObjectsOfType<EmptyTerrainBlock>());

        int bodyBlock = Random.Range(0, emptyTerrain.Count);
        Instantiate(m_bodyItems[Random.Range(0, m_bodyItems.Length)], emptyTerrain[bodyBlock].transform.position + Vector3.up * m_blockSize * 0.5f + Vector3.up * m_itemOffset, Quaternion.identity);
        emptyTerrain.RemoveAt(bodyBlock);

        int headBlock = Random.Range(0, emptyTerrain.Count);
        Instantiate(m_headItems[Random.Range(0, m_headItems.Length)], emptyTerrain[headBlock].transform.position + Vector3.up * m_blockSize * 0.5f + Vector3.up * m_itemOffset, Quaternion.identity);
        emptyTerrain.RemoveAt(headBlock);

        int leftArm = Random.Range(0, emptyTerrain.Count);
        Instantiate(m_armItems[Random.Range(0, m_armItems.Length)], emptyTerrain[leftArm].transform.position + Vector3.up * m_blockSize * 0.5f + Vector3.up * m_itemOffset, Quaternion.identity);
        emptyTerrain.RemoveAt(leftArm);

        int rightArm = Random.Range(0, emptyTerrain.Count);
        Instantiate(m_armItems[Random.Range(0, m_armItems.Length)], emptyTerrain[rightArm].transform.position + Vector3.up * m_blockSize * 0.5f + Vector3.up * m_itemOffset, Quaternion.identity);
        emptyTerrain.RemoveAt(rightArm);

        int leftLeg = Random.Range(0, emptyTerrain.Count);
        Instantiate(m_legItems[Random.Range(0, m_legItems.Length)], emptyTerrain[leftLeg].transform.position + Vector3.up * m_blockSize * 0.5f + Vector3.up * m_itemOffset, Quaternion.identity);
        emptyTerrain.RemoveAt(leftLeg);

        int rightLeg = Random.Range(0, emptyTerrain.Count);
        Instantiate(m_legItems[Random.Range(0, m_legItems.Length)], emptyTerrain[rightLeg].transform.position + Vector3.up * m_blockSize * 0.5f + Vector3.up * m_itemOffset, Quaternion.identity);
        emptyTerrain.RemoveAt(rightLeg);

        int startBlock = Random.Range(0, emptyTerrain.Count);
        Instantiate(m_startArea, emptyTerrain[bodyBlock].transform.position + Vector3.up * m_blockSize * 0.5f,
            Quaternion.identity);
        emptyTerrain.RemoveAt(startBlock);
    }
}
