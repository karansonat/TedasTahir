using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Level2 : MonoBehaviour, ILevel
{
    public GameObject Worker;
    public List<GameObject> Blocks;
    public List<WaveData> TotalWaves = new List<WaveData>();
    public int levelSocore;
    public bool isLevelStarted;
    public int numberOfWorkers;
    private bool spawnFlag;
    private float spawnLimit;
    private float spawnDelay;
    private int currentIndex;
    private float WaveTimeLimit;
    private float WaveStartTime;
    private bool isWaveStarted;
    private int WaveScore;

    public Text CountDown;

    // Use this for initialization
    void Start()
    {
        isLevelStarted = false;
        isWaveStarted = false;
        WaveTimeLimit = 5;
        currentIndex = -1;
        WaveScore = 0;
        //BURAYA OYUNUN BAŞLAYACAĞINI BELİRTEN GERİ SAYIMDAN SONRA FLAGI AKTIF ETMEYİ KOY
        spawnLimit = 0;
        spawnFlag = true;
        var backgroundObject = transform.FindChild("BlockHolder");
        foreach (Transform child in backgroundObject.transform)
        {
            Blocks.Add(child.gameObject);
        }
        Blocks.RemoveAt(Blocks.Count - 1);
        Blocks.RemoveAt(Blocks.Count - 1); 

    }

    void SetUpWave() {
        spawnDelay = TotalWaves[currentIndex].SpawnDelay;
        spawnLimit = TotalWaves[currentIndex].SpawnLimit;
    }

    void WaveController() {
        
    }
 

    void OnEnable()
    {
        EventManager.OnAddScore += Score;
        EventManager.OnWaveStart += WaveStart;
        EventManager.OnWaveEnd += WaveEnd;


    }
    void OnDisable()
    {
        EventManager.OnAddScore -= Score;
        EventManager.OnWaveStart -= WaveStart;
        EventManager.OnWaveEnd -= WaveEnd;
    }

    void WaveStart() {
        currentIndex++;
        SetUpWave();
        isWaveStarted = true;
        WaveStartTime = Time.realtimeSinceStartup;
    }

    void WaveEnd(int score)
    {
        Debug.Log("WaveEnd");
        GameObject[] diggers = GameObject.FindGameObjectsWithTag("Digger");
        foreach (GameObject digger in diggers) {
            digger.GetComponent<WorkerLogic>().KillWorker();
            
        }
        isWaveStarted = false;


    }
    // Update is called once per frame
    void Update()
    {
        if (isLevelStarted && isWaveStarted )
        {
            float countdown = WaveTimeLimit- Mathf.Floor(Time.realtimeSinceStartup - WaveStartTime  );
            CountDown.text = "" + countdown;
            if (numberOfWorkers < spawnLimit && spawnFlag)
            {
                StartCoroutine(WaitAndSpawn());
                SpawnWorker();
                spawnFlag = false;
            }
            Debug.Log(Time.realtimeSinceStartup+ "   " + WaveStartTime);
            if (Time.realtimeSinceStartup - WaveStartTime > WaveTimeLimit)
            {

                EventManager.WaveEnd(WaveScore);
                return;
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!isLevelStarted)
            {
                isWaveStarted = true;
                isLevelStarted = true;
                EventManager.WaveStart();
                // EventManager.WaveStart();
            }
           else if (!isWaveStarted)
            {
                isWaveStarted = true;
                EventManager.WaveStart();
                // EventManager.WaveStart();
            }

        }

    }



    IEnumerator WaitAndSpawn() {
        yield return new WaitForSeconds(spawnDelay);
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
        if(bc.blockState==-1)
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
