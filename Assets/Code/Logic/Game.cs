using UnityEngine;
using System.Collections;

public abstract class Game : MonoBehaviour
{
    static float initDeathClockTime = 120;
    static float DeathClock;
    protected abstract void OnStartGame();

    private void Start()
    {
        OnStartGame();
        resetDeathClock();
    }

    private void Update()
    {
        DeathClock -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.T))
        {
            DeathClock -= initDeathClockTime;
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
}
