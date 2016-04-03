using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public List<GameObject> levels = new List<GameObject>();
    private int activeLevelIndex;
    private ILevel activeLevel;
    private GameObject UI;

    void Start()
    {
        UI = GameObject.Find("UI");
    }

    void OnEnable()
    {
        EventManager.OnGameEnd += EndGame;
    }

    void OnDisable()
    {
        EventManager.OnGameEnd -= EndGame;
    }

    public void StartGame()
    {
        //Start first finished level.;
        SwitchLevel(1);
        UI.SetActive(false);
        Debug.Log("Star Game Clicked");
    }

    public void EndGame()
    {
        //Goto gameover screen.
        Debug.Log("GameOver.");
    }

    private void SwitchLevel(int index)
    { 
        //Set active level parameters
        activeLevelIndex = index;
        activeLevel = levels[index].GetComponent<ILevel>();
        levels[activeLevelIndex].SetActive(true);
        //Deactivate other level gameobjects.
        for(var i = 0; i < levels.Count; i++)
        {
            if(i == activeLevelIndex)continue;
            levels[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var index = Random.Range(0, 4);
            SwitchLevel(index);
            Debug.Log(index);
        }
    }
}
