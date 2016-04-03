using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerLogic : MonoBehaviour
{
    private Level2 level;
    public List<Sprite> DigMasks;
    public List<float> stateYPos; 
    public bool isAlive;
    public int blockIndex;

    public float digTimer;

    void Awake()
    {
        Debug.Log("WorkerLogic::Start");
        level = GameObject.Find("MiniGame2").GetComponent<Level2>();
        isAlive = true;
        
    }

    public void SetWorker(int index) {
        blockIndex = index;
    }

	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        Dig();
	    }
	}

    public void Dig()
    {
        if (!isAlive) return;
        var bc = level.Blocks[blockIndex].GetComponent<BlockController>();
        bc.blockState++;
        if (bc.blockState == DigMasks.Count)
        {
            EventManager.GameEnd();
            return;
        }
        //Delete this after implement end game session.
        if (bc.blockState >= DigMasks.Count)
        {
            Debug.LogError("1)End Game ekranini implement etmen gerek. 2)Level2 kapanmali. 3)en asagi kadar inmeden oyun bitiyor cunku gorsel yok.");
            return;
        }
        //End
        bc.UpdateVisual(DigMasks[bc.blockState]);
        transform.position = new Vector3(transform.position.x, stateYPos[bc.blockState], transform.position.z);
    }

    public void SetInitialPosition()
    {
        //Hack(sonat): This method can be run before Awake.
        if(!level) level = GameObject.Find("MiniGame2").GetComponent<Level2>();
        //End of hack
        var blockPos = level.Blocks[blockIndex].transform.position;
        transform.position = new Vector3(blockPos.x, stateYPos[0], blockPos.z);
    }

    public void KillWorker()
    {
        //isAlive = false;
        level.Blocks[blockIndex].GetComponent<BlockController>().hasWorker = false;
        level.numberOfWorkers--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (isAlive)
        {


            if (col.gameObject.tag == "lightning")
            {

                isAlive = false;
                GetComponent<Animator>().SetTrigger("Dead");
            }

        }

    }

    public void DiggingAnimationCallback()
    {
        digTimer += 0.5f;
        if (digTimer == 4.5f)
        {
            digTimer = 0;
            Dig();
        }   
    }
}
