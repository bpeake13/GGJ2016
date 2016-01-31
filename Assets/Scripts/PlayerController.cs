using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject heart;
    public GameObject otherPlayer;
    float followSpeed = 5;

    public float playerVelocity;
    public bool isDead;
    public bool isFocus;

    Rigidbody rigidbody;
    InventoryUI inventory;

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        inventory = GameObject.Find("InventoryUI").GetComponent<InventoryUI>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isFocus)
        {
            checkPlayerInput();
        }
        else
        {
            float distance = Vector3.Distance(gameObject.transform.position, otherPlayer.transform.position);
            if (Mathf.Abs(distance) > 3)
            {
                float step = followSpeed * Time.deltaTime;
                Vector3 moveToPoint = new Vector3(otherPlayer.transform.position.x, gameObject.transform.position.y, otherPlayer.transform.position.z);
                transform.position = Vector3.MoveTowards(gameObject.transform.position, moveToPoint, step);
            }
        }
    }

    void checkPlayerInput()
    {
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
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
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

    public void makeDead()
    {
        isDead = true;
        gameObject.SetActive(false);
        heart.SetActive(true);
        heart.transform.position = gameObject.transform.position;
    }
    public void makeAlive()
    {
        isDead = false;
        gameObject.SetActive(true);
        heart.SetActive(false);
        gameObject.transform.position = heart.transform.position;
    }
}
