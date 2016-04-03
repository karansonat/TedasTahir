using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerLogic : MonoBehaviour
{
    public List<Sprite> DigMasks;
    List<GameObject> blocks;
    public bool isAlive;
    private static Vector3 digStep;
    public int blockIndex;
    public int blockState;

    // Use this for initialization
    void Start()
    {
        digStep = new Vector3(0.0f,-0.05f,0.0f);
        isAlive = true;
    }
    public void SetWorker(int index,int blockState) {
        blockIndex = index;
        this.blockState = blockState;
    }

	
	// Update is called once per frame
	void Update () {
	
	}

    public void Dig()
    {
        if (!isAlive) return;
        blockState++;
        blocks[blockIndex].GetComponent<SpriteRenderer>().sprite = DigMasks[blockState];
    }

    public void KillWorker()
    {
        isAlive = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cable")
        {
            EventManager.GameEnd();
        }
    }
}
