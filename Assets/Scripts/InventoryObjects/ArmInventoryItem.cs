using UnityEngine;
using System.Collections;

public class ArmInventoryItem : InventoryItem
{
    enums.bodyType armType = 0;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        slot = enums.InventorySlot.arm;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
