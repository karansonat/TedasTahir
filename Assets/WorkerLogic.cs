using UnityEngine;
using System.Collections;

public class WorkerLogic : MonoBehaviour
{
    public GameObject DigMask;
    public bool isAlive;
    private static Vector3 digStep;

    // Use this for initialization
    void Start()
    {
        digStep = new Vector3(0.0f,-0.05f,0.0f);
        isAlive = true;
    }


	
	// Update is called once per frame
	void Update () {
	
	}

    public void Dig()
    {
        if (!isAlive) return;
        transform.position += digStep;
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
