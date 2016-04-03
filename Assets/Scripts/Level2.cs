using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level2 : MonoBehaviour, ILevel
{
    public GameObject Worker;
    public List<GameObject> Blocks;
    public int levelSocore;
    public int numberOfWorkers;
    private bool spawnFlag;
    private int spawnLimit;
    private float spawnDelay;

    // Use this for initialization
    void Start()
    {
        //BURAYA OYUNUN BAŞLAYACAĞINI BELİRTEN GERİ SAYIMDAN SONRA FLAGI AKTIF ETMEYİ KOY
        spawnLimit = 0;
        spawnFlag = true;
        var backgroundObject = transform.FindChild("BlockHolder");
        foreach (Transform child in backgroundObject.transform)
        {
            Blocks.Add(child.gameObject);
        }
        Blocks.RemoveAt(Blocks.Count - 1);

    }

    void OnEnable()
    {
        EventManager.OnAddScore += Score;
    }
    void OnDisable()
    {
        EventManager.OnAddScore -= Score;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfWorkers<3 && spawnFlag)
        {

            StartCoroutine(WaitAndSpawn(1.0f));
            SpawnWorker();
            spawnFlag = false;
        }
    }

    IEnumerator WaitAndSpawn(float sec) {
        yield return new WaitForSeconds(sec);
        spawnFlag = true;
    }

    public void GameLoop()
    {
        
    }

    void Score(int addedScore)
    {
        levelSocore += addedScore;
    }

    public void SpawnWorker()
    {
        var isSpawnAvailable = false;
        foreach (var obj in Blocks)
        {
            if (!obj.GetComponent<BlockController>().hasWorker)
            {
                isSpawnAvailable = true;
                break;
            }   
        }
        if (!isSpawnAvailable) return;
        var workerInstance = Instantiate(Worker);
        var block = GetRandomBlock();
        var bc = block.GetComponent<BlockController>();
        var wl = workerInstance.GetComponent<WorkerLogic>();
        numberOfWorkers++;

        wl.blockIndex = block.transform.GetSiblingIndex();
        wl.SetInitialPosition();
        bc.hasWorker = true;
        bc.UpdateVisual(wl.DigMasks[0]);

    }



    public GameObject GetRandomBlock()
    {
        var index = Random.Range(0, Blocks.Count);
        while (Blocks[index].GetComponent<BlockController>().hasWorker)
        {
            index = Random.Range(0, Blocks.Count);
        }
        return Blocks[index];
    }

    void AddScore() {
    
    }

    public void StartLevel()
    {
        throw new System.NotImplementedException();
    }

    public void EndLevel()
    {
        Debug.Log("Level2 - GameEnd");
    }

    public void ToogleInput(bool flag)
    {
        throw new System.NotImplementedException();
    }
}
