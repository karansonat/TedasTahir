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
    public delegate void AddScoreAction(int score);

    public static event AddScoreAction OnAddScore;

    public static void AddScore(int score)
    {
        if (OnAddScore != null)
        {
            OnAddScore(score);
        }
    }

    public delegate void WaveEndAction(int score);

    public static event WaveEndAction OnWaveEnd;

    public static void WaveEnd(int score)
    {
        if (OnAddScore != null)
        {
            OnWaveEnd(score);
        }
    }

    public delegate void WaveStartAction();

    public static event WaveStartAction OnWaveStart;

    public static void WaveStart()
    {
        if (OnWaveStart != null)
        {
            OnWaveStart();
        }
    }

}
