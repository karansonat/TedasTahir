using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour, ILevel
{
    public GameObject Tahir;

    private bool isTahirMoving = false;
    private Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = Tahir.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameLoop();
    }

    public void GameLoop()
    {
        OnTouch();
        MoveCharacterToPosition();
    }

    public void OnTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            {
                if (hitInfo.transform.tag == "Direk")
                {
                    Debug.Log("Direk clicked.");
                    targetPos = hitInfo.transform.position;
                    isTahirMoving = true;
                }
            }
        }
    }

    private void MoveCharacterToPosition()
    {
        if (!isTahirMoving) return;
        Debug.Log("MoveToCharacter");
        Tahir.transform.position = Vector3.MoveTowards(Tahir.transform.position, new Vector3(targetPos.x, Tahir.transform.position.y, Tahir.transform.position.z), Time.deltaTime * 10);
        isTahirMoving = !(Tahir.transform.position.x == targetPos.x);
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
