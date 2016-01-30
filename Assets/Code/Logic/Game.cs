using UnityEngine;
using System.Collections;

public abstract class Game : MonoBehaviour
{
    protected abstract void OnStartGame();

    private void Start()
    {
        OnStartGame();
    }
}
