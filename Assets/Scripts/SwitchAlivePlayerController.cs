using UnityEngine;
using System.Collections;

public class SwitchAlivePlayerController : MonoBehaviour {

    public CameraFollow cameraFollow;
    public GameObject player1;
    public GameObject player2;
    public InventoryUI inventoryUi;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Game.getDeathClock() <= 0)
        {
            checkAndSetPlayerDeaths();
            Game.resetDeathClock();
        }
	}

    void checkAndSetPlayerDeaths()
    {
        switch (Game.getPlayerState())
        {
            case enums.PlayerStates.player1Alive:
                player2.GetComponent<PlayerController>().makeDead();
                cameraFollow.setCameraFollowObject(player1);
                inventoryUi.PlayerInFocus = player1;
                player2.GetComponent<PlayerController>().isFocus = false;
                player1.GetComponent<PlayerController>().isFocus = true;
                break;

            case enums.PlayerStates.player2Alive:
                player1.GetComponent<PlayerController>().makeDead();
                cameraFollow.setCameraFollowObject(player2);
                inventoryUi.PlayerInFocus = player2;
                player2.GetComponent<PlayerController>().isFocus = true;
                player1.GetComponent<PlayerController>().isFocus = false;
                break;

            case enums.PlayerStates.bothAlive:

                if (player1.GetComponent<PlayerController>().isDead)
                {
                    player1.GetComponent<PlayerController>().makeAlive();
                }
                if (player2.GetComponent<PlayerController>().isDead)
                {
                    player2.GetComponent<PlayerController>().makeAlive();
                }
                break;
        }
    }
}
