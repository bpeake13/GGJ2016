using UnityEngine;
using System.Collections;

public class WolfController : MonoBehaviour {

    GameObject player;

    float timerTillNewDirection = 6;
    float speed = 4;
    public Vector3 currentTarget;  
    Rigidbody rigidBody;
    Animator animator;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player1");
        currentTarget = getNewPosition();

        rigidBody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();

        animator.Play(enums.WolfAnimations.Wolf_Idle.ToString());
    }
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(gameObject.transform.position, currentTarget);

        if (Mathf.Abs(distance) > 3)
        {
            float step = speed * Time.deltaTime;
            Vector3 moveToPoint = new Vector3(currentTarget.x, gameObject.transform.position.y, currentTarget.z);
            transform.position = Vector3.MoveTowards(gameObject.transform.position, moveToPoint, step);
        }
        gameObject.transform.LookAt(currentTarget);

        if (Mathf.Abs(distance) < 3)
        {
            animator.Play(enums.WolfAnimations.Wolf_Idle.ToString());
        }
        else
        {
            animator.Play(enums.WolfAnimations.Wolf_Run.ToString());
        }

        timerTillNewDirection -= Time.deltaTime;
        if(timerTillNewDirection < 0)
        {
            currentTarget = getNewPosition();
            timerTillNewDirection = 6;
        }
    }

    Vector3 getNewPosition()
    {
        return player.transform.position;
    }
}
