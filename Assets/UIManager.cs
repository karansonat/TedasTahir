using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text ingameScore;
    public Text EndGameScore;
    public int LevelScore;
    public int GeneralScore;

    // Use this for initialization
    void Start () {
	
	}

    void OnEnable()
    {
        EventManager.OnAddScore += Score;
    }
    void OnDisable()
    {
        EventManager.OnAddScore -= Score;
    }

    void Score(int addedScore)
    {
        LevelScore += addedScore;
        GeneralScore += addedScore;
        UpdateScoreTexts();
    }

    void UpdateScoreTexts() {
        ingameScore.text = "" + LevelScore;
        EndGameScore.text = "" + GeneralScore;
    }

}
