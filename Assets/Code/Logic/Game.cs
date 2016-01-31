using UnityEngine;
using System.Collections;

public abstract class Game : MonoBehaviour
{
    static float initDeathClockTime = 45;
    static enums.PlayerStates playerState = enums.PlayerStates.bothAlive;
    static enums.PlayerStates previousPlayerState = enums.PlayerStates.player2Alive;

    static float DeathClock;
    protected abstract void OnStartGame();

    private void Start()
    {
        OnStartGame();
        resetDeathClock();
    }

    private void Update()
    {
        //debug auto progress character kill
        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            DeathClock -= initDeathClockTime;
        }
        */

        DeathClock -= Time.deltaTime;
        if (DeathClock <= 0)
        {
            switchPlayerStates();
        }
    }

    public static float getDeathClock()
    {
        return DeathClock;
    }

    public static void resetDeathClock()
    {
        DeathClock = initDeathClockTime;
    }
    public static enums.PlayerStates getPlayerState()
    {
        return playerState;
    }
    public static enums.PlayerStates getPreviousPlayerState()
    {
        return previousPlayerState;
    }

    public static void switchPlayerStates()
    {
        switch (playerState)
        {
            case enums.PlayerStates.bothAlive:

                if(previousPlayerState == enums.PlayerStates.player1Alive)
                {
                    playerState = enums.PlayerStates.player2Alive;
                }
                else if (previousPlayerState == enums.PlayerStates.player2Alive)
                {
                    playerState = enums.PlayerStates.player1Alive;
                }

                break;
            case enums.PlayerStates.player1Alive:
                previousPlayerState = playerState;
                playerState = enums.PlayerStates.bothAlive;
                break;
            case enums.PlayerStates.player2Alive:
                previousPlayerState = playerState;
                playerState = enums.PlayerStates.bothAlive;
                break;
        }
    }
}
