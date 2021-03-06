using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public float secondsBeforeAutoCarArrivalReset;
    public bool TimeFrozen = false;
    public bool leftPressed = false;
    public bool rightPressed = false;
    public int SessionSize;

    public bool playerCarReachedTargetInTime;

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
        SessionSize = ExitManager.instance.AllExits.Count;
    }

    public void Progress(Car c)
    {
        CarSpawnerManager.instance.ResetAllAutoCar();
        StopTheResetRoutine();
        if (CarSpawnerManager.instance.GetCarCount() < SessionSize)
        {
            CarSpawnerManager.instance.SpawnNewPlayerCar();
            
        }//else if size = carcount end the session
    }

    public void ResetSession()
    {
        CarSpawnerManager.instance.ResetPositionOfCars();
        StopTheResetRoutine();
        TimeFrozen = true;
    }

    public void ContinueTime()
    {
        TimeFrozen = true;
    }
    public bool CR_running;
    Coroutine cr;
    public void ResetWithDelay()
    {
        
         if(!CR_running)
         cr = StartCoroutine(WaitBeforeResetRoutine());
        
    }
    public void StopTheResetRoutine()
    {
        if(cr != null)
            StopCoroutine(cr);
        CR_running = false;
    }

    public IEnumerator WaitBeforeResetRoutine()
    {
        CR_running = true;
        Debug.Log("waiting before reset");
        yield return new WaitForSecondsRealtime(secondsBeforeAutoCarArrivalReset);
        //reset this session
        Debug.Log("reset session");
        CR_running = false;
        CarSpawnerManager.instance.ResetPositionOfCars();
    }

}
