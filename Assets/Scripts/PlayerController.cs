using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject heart;
    public GameObject otherPlayer;
    public GameObject emoteBubble;

    public InventoryModelUI playerModel;
    public InventoryModelUI uiModel;

    playerAnimationController animationController;

    public SpriteRenderer emoteContainer;
    public Sprite happyEmote;
    public Sprite sadEmote;

    float followSpeed = 5;

    public float playerVelocity;
    public bool isDead;
    public bool isFocus;

    Rigidbody rigidbody;
    InventoryUI inventory;

    enums.PlayerActionStates playerState = enums.PlayerActionStates.Walk;

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        inventory = GameObject.Find("InventoryUI").GetComponent<InventoryUI>();
        animationController = gameObject.GetComponent<playerAnimationController>();
        uiModel = GameObject.Find("UiCamera").GetComponent<InventoryModelUI>();
    }

	// Update is called once per frame
	void Update () {

        switch (playerState)
        {
            case enums.PlayerActionStates.Idle: IdleUpdate(); break;
            case enums.PlayerActionStates.Walk: WalkUpdate(); break;
        }
    }
    void SwitchState(enums.PlayerActionStates newState)
    {
        switch (playerState)
        {
            case enums.PlayerActionStates.Idle: IdleExit(); break;
            case enums.PlayerActionStates.Walk: WalkExit(); break;
        }

        playerState = newState;

        switch (playerState)
        {
            case enums.PlayerActionStates.Idle: IdleEnter(); break;
            case enums.PlayerActionStates.Walk: WalkEnter(); break;
        }
    }

    void IdleEnter()
    {

    }

    void IdleUpdate()
    {

    }

    void IdleExit()
    {

    }

    void WalkEnter()
    {

    }

    void WalkUpdate()
    {
        if (isFocus)
        {
            checkPlayerInput();
        }
        else        //cpu player follow
        {
            float distance = Vector3.Distance(gameObject.transform.position, otherPlayer.transform.position);
            if (Mathf.Abs(distance) > 3)
            {
                float step = followSpeed * Time.deltaTime;
                Vector3 moveToPoint = new Vector3(otherPlayer.transform.position.x, gameObject.transform.position.y, otherPlayer.transform.position.z);
                transform.position = Vector3.MoveTowards(gameObject.transform.position, moveToPoint, step);
            }

            if (rigidbody.velocity.x == 0 && rigidbody.velocity.z == 0)
            {
                if (animationController.getCurrentAnimation() != enums.PlayerAnimations.Torso_Rig_Idle)
                {
                    animationController.SetIdle();
                }
            }
            else if (animationController.getCurrentAnimation() != enums.PlayerAnimations.Torso_Rig_Walk)
            {
                animationController.SetWalk();
            }
            gameObject.transform.LookAt(new Vector3(otherPlayer.transform.position.x, gameObject.transform.position.y, otherPlayer.transform.position.z));
        }
    }

    void WalkExit()
    {

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


        if(rigidbody.velocity.x == 0 && rigidbody.velocity.z == 0)
        {
            if (animationController.getCurrentAnimation() != enums.PlayerAnimations.Torso_Rig_Idle)
            {
                animationController.SetIdle();
            }
        }
        else if (animationController.getCurrentAnimation() != enums.PlayerAnimations.Torso_Rig_Walk)
        {
            animationController.SetWalk();
        }

        if (animationController.getCurrentAnimation() != enums.PlayerAnimations.Torso_Rig_Idle)
        {
            gameObject.transform.LookAt(new Vector3(rigidbody.velocity.x * 10, gameObject.transform.position.y, rigidbody.velocity.z * 10));
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

    public void turnOnEmoteFromPartner()
    {
        if (!isDead)
        {
            emoteBubble.SetActive(true);
            emoteContainer.sprite = happyEmote;
            StartCoroutine(turnOffEmoteAfterSeconds());
        }
    }

    public void turnOnEmote()
    {
        emoteBubble.SetActive(true);

        if (otherPlayer.GetComponent<PlayerController>().isDead)
        {
            emoteContainer.sprite = sadEmote;
        }
        else
        {
            emoteContainer.sprite = happyEmote;
        }

        otherPlayer.GetComponent<PlayerController>().turnOnEmoteFromPartner();
        StartCoroutine(turnOffEmoteAfterSeconds());
    }

    IEnumerator turnOffEmoteAfterSeconds()
    {
        yield return new WaitForSeconds(3);
        emoteBubble.SetActive(false);
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
        setModelFromUi();
        uiModel.resetModel();
    }

    void setModelFromUi()
    {
        playerModel.resetModel();
        playerModel.SetBodyModel(uiModel.bodyItem);
        playerModel.SetHeadModel(uiModel.headItem);
        playerModel.SetLeftArmModel(uiModel.leftArmItem);
        playerModel.SetRightArmModel(uiModel.rightArmItem);
        playerModel.SetLeftLegModel(uiModel.leftLegItem);
        playerModel.SetRightLegModel(uiModel.rightLegItem);
    }
}
