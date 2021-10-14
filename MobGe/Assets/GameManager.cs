using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public float secondsBeforeAutoCarArrivalReset;

    void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        ExitManager.instance.Init();
        EntrenceManager.instance.Init();
        CarSpawnerManager.instance.Init();
        CarSpawnerManager.instance.SpawnNewPlayerCar();
    }
}
