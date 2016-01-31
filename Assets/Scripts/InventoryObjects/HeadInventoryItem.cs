using UnityEngine;
using System.Collections;

public class HeadInventoryItem : InventoryItem
{
    public enums.headType headType = 0;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        slot = enums.InventorySlot.head;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
