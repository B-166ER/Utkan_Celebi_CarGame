using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnEnable()
    {
        ExitManager.instance.Init();
        EntrenceManager.instance.Init();
    }

}
