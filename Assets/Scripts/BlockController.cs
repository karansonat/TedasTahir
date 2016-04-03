using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour
{
    public Sprite InitialSprite;
    public bool hasWorker = false;
    public int blockState;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = InitialSprite;
    }
	
	// Update is called once per frame
	public void UpdateVisual (Sprite sprite)
	{
	    GetComponent<SpriteRenderer>().sprite = sprite;
	}
    public void Reset() {
        blockState = -1;
        GetComponent<SpriteRenderer>().sprite = InitialSprite;

    }
}
