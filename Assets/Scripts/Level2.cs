using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level2 : MonoBehaviour, ILevel
{
    List<int> blocksWithWorker;
    public GameObject Worker;
    public List<GameObject> Blocks;
    // Use this for initialization
    void Start()
    {
        for (var i = 0; i < Blocks.Count; i++) {
            blocksWithWorker.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameLoop();
    }

    public void GameLoop()
    {
        
    }

    public void SpawnWorker(int blockIndex) {
        GameObject WorkerInstance = GameObject.Instantiate(Worker);

    }

    public void StartLevel()
    {
        throw new System.NotImplementedException();
    }

    public void EndLevel()
    {
        throw new System.NotImplementedException();
    }

    public void ToogleInput(bool flag)
    {
        throw new System.NotImplementedException();
    }
}
