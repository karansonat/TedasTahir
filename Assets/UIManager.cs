using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    public Text ingameScore;
    public Text EndGameScore;
    public Text WaveScoreText;
    public int can;
    public GameObject WaveEnd;
    public List<GameObject> salters;
    public List<GameObject> lambs;
    public int WaveScore;
    public int LevelScore;
    public int GeneralScore;

    // Use this for initialization
    void Start () {
        can = 3;
    }

    void OnEnable()
    {
        EventManager.OnAddScore += Score;
        EventManager.OnWaveStart += HideWaveEnd;
        EventManager.OnWaveEnd += ShowWaveEnd;
    }
    void OnDisable()
    {
        EventManager.OnAddScore -= Score;
        EventManager.OnWaveStart -= HideWaveEnd;
        EventManager.OnWaveEnd -= ShowWaveEnd;
    }

    void Score(int addedScore)
    {
        LevelScore += addedScore;
        GeneralScore += addedScore;
        UpdateScoreTexts();
    }

    void ShowWaveEnd(int waveScore)
    {
       
 

        WaveEnd.SetActive(true);
        if (waveScore == -1)
        {
            can += waveScore;
            if (can == 2)
            {
                lambs[can].GetComponent<Animator>().SetTrigger("down");
            }
            else if (can == 1)
            {
                lambs[can + 1].GetComponent<Animator>().SetTrigger("down");
                lambs[can].GetComponent<Animator>().SetTrigger("down");
            }
            else if (can == 0)
            {
                lambs[can + 2].GetComponent<Animator>().SetTrigger("down");
                lambs[can + 1].GetComponent<Animator>().SetTrigger("down");
                lambs[can].GetComponent<Animator>().SetTrigger("down");
            }
            salters[can].GetComponent<Animator>().SetTrigger("down");
            lambs[can].GetComponent<Animator>().SetTrigger("down");
        }
        // WaveScore = waveScore;
        Score(waveScore);
       // WaveScoreText.text = ""+waveScore;
       // UpdateScoreTexts();
    }
    void HideWaveEnd()
    {
        WaveEnd.SetActive(false);
        WaveScore = 0;
        // WaveScoreText.text = ""+waveScore;
        // UpdateScoreTexts();
    }

    void UpdateScoreTexts() {
 //       ingameScore.text = "" + LevelScore;
  //     EndGameScore.text = "" + GeneralScore;
    }

}
