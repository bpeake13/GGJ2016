using UnityEngine;
using System.Collections;

public class GraveInteractions : MonoBehaviour {

    GameObject notificationGO;
    string[] pickupNames = { "BodyPickup","HeadPickup","ArmPickup","BodyPickup","LegPickup"};

    int amountToOpenGrave = 5;

    // Use this for initialization
    void Start () {
        notificationGO = gameObject.GetComponentInChildren<InteractibleNotification>().gameObject;
        notificationGO.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
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
            if (Input.GetKeyDown(KeyCode.Space) && amountToOpenGrave > 0)
            {
                amountToOpenGrave--;
                if(amountToOpenGrave <= 0)
                {
                    dropBodyPart();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            notificationGO.SetActive(false);
        }
    }

    void dropBodyPart() { 
    
        int randType = Random.Range((int)0, (int)4);
        int randItem = Random.Range((int)1, (int)3);
        GameObject instance = Instantiate(Resources.Load(pickupNames[randType] + randItem.ToString(), typeof(GameObject))) as GameObject;
        instance.GetComponent<InventoryItem>().droppedBackIntoWorld(gameObject.transform.position + new Vector3(0,4,0));

        GameObject.Destroy(gameObject);
    }
    
}
