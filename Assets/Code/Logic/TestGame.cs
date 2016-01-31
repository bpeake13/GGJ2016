using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TerrainGenerator))]
public class TestGame : Game
{
    [SerializeField]
    private Terrain m_targetTerrain;

    protected override void OnStartGame()
    {
       TerrainGenerator gen = GetComponent<TerrainGenerator>();
       TerrainData data = gen.Generate();

        m_targetTerrain.Construct(data);
    }
}
