using UnityEngine;
using System.Collections;

public class Section : Area
{
    public Section(TerrainData owner, Block[] blocks)
        :base(owner, blocks)
    { }
}
