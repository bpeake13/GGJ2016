using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour {

    protected enums.InventorySlot slot = 0; 
    GameObject notificationGO;
    public Sprite sprite;

    // Use this for initialization
    protected virtual void Start () {
        notificationGO = gameObject.GetComponentInChildren<InteractibleNotification>().gameObject;
        notificationGO.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite getImage()
    {
        return sprite;
    }

    public enums.InventorySlot getSlot()
    {
        return slot;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            notificationGO.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (other.GetComponent<PlayerController>().isFocus)
                {
                    other.gameObject.GetComponent<PlayerController>().pickupBodyPart(gameObject);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            notificationGO.SetActive(false);
        }
    }

    public void droppedBackIntoWorld(Vector3 pos)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = pos + new Vector3(0, 1, 0);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0));
    }
}
