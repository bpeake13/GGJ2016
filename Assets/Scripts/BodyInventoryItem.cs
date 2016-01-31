using UnityEngine;
using System.Collections;

public class BodyInventoryItem : InventoryItem
{
    enums.bodyType bodyType = 0;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        slot = enums.InventorySlot.body;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
