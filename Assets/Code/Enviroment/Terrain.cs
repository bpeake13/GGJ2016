using UnityEngine;
using System.Collections;

public abstract class Terrain : MonoBehaviour, IConstructable<TerrainData>
{
    public abstract void Construct(TerrainData data);
}
