using UnityEngine;
using System.Collections;

public class MiniGame1 : MonoBehaviour, ILevel
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CoreLoop();
    }

    public void CoreLoop()
    {
        
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
