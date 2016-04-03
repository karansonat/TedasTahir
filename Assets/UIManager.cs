using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text ingameScore;
    public Text EndGameScore;
    public Text WaveScoreText;
    public int WaveScore;
    public int LevelScore;
    public int GeneralScore;

    // Use this for initialization
    void Start () {
	
	}

    void OnEnable()
    {
        EventManager.OnAddScore += Score;
        EventManager.OnWaveEnd += ShowWaveEnd;
    }
    void OnDisable()
    {
        EventManager.OnAddScore -= Score;
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
        WaveScore = waveScore;
        Score(waveScore);
       // WaveScoreText.text = ""+waveScore;
       // UpdateScoreTexts();
    }

    void UpdateScoreTexts() {
 //       ingameScore.text = "" + LevelScore;
  //     EndGameScore.text = "" + GeneralScore;
    }

}
