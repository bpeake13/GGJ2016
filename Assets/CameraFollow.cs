using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float speed;

    public GameObject objectToFollow;
    float zOffset = -16;
    float xOffset = 1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 moveToPoint = new Vector3(objectToFollow.transform.position.x + xOffset, gameObject.transform.position.y, objectToFollow.transform.position.z + zOffset);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, moveToPoint, step);
    }
}
