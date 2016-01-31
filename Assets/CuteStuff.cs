using UnityEngine;
using System.Collections;

public class CuteStuff : MonoBehaviour {

    public GameObject notificationGO;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (other.GetComponent<PlayerController>().isFocus)
                {
                        other.GetComponent<PlayerController>().turnOnEmote();
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
