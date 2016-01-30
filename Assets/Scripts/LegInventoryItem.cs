using UnityEngine;
using System.Collections;

public class LegInventoryItem : InventoryItem
{
    enums.headType headType = 0;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        slot = enums.InventorySlot.leg;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
