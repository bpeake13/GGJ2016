using UnityEngine;
using System.Collections;

public class HeartFollow : MonoBehaviour {

    float speed = 5;
    public GameObject objectToFollow;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        float distance = Vector3.Distance(gameObject.transform.position, objectToFollow.transform.position);

        if (Mathf.Abs(distance) > 3) {
            float step = speed * Time.deltaTime;
            Vector3 moveToPoint = new Vector3(objectToFollow.transform.position.x, gameObject.transform.position.y, objectToFollow.transform.position.z);
            transform.position = Vector3.MoveTowards(gameObject.transform.position, moveToPoint, step);
        }
    }
}
