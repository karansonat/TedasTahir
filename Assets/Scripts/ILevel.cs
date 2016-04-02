using UnityEngine;
using System.Collections;

public interface ILevel
{
    void StartLevel();
    void EndLevel();
    void ToogleInput(bool flag);
    void CoreLoop();
}
