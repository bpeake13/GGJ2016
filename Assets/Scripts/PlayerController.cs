using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float playerVelocity;

    Vector3 forwardVelocity;

    Rigidbody rigidbody;
    InventoryUI inventory;

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        inventory = GameObject.Find("InventoryUI").GetComponent<InventoryUI>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, playerVelocity);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -playerVelocity);
        }
        else
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(-playerVelocity, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(playerVelocity, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        else
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z );
        }
    }

    public void pickupBodyPart(GameObject item)
    {
        switch (item.GetComponent<InventoryItem>().getSlot())
        {
            case enums.InventorySlot.head: inventory.setHeadSlot(item); break;
            case enums.InventorySlot.leg: inventory.setLegSlot(item); break;
            case enums.InventorySlot.body: inventory.setBodySlot(item); break;
            case enums.InventorySlot.arm: inventory.setArmSlot(item); break;
        }
    }
}
