using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void GameStartAction();

    public static event GameStartAction OnGameStart;

    public void GameStart()
    {
        if (OnGameStart != null)
        {
            OnGameStart();
        }
    }

    public delegate void GameEndAction();

    public static event GameEndAction OnGameEnd;

    public static void GameEnd()
    {
        if (OnGameEnd != null)
        {
            OnGameEnd();
        }
    }
}
