using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerManager : MonoBehaviour
{
    public static CarSpawnerManager instance;

    List<GameObject> Cars = new List<GameObject>();
    public GameObject CarPrefab;

    public void OnEnable()
    {
        instance = this;
    }
    public void Init()
    {

    }

    public void SpawnNewPlayerCar()
    {
        EntrenceBehaviour start = EntrenceManager.instance.GetAvailableEntrence();

        ExitBehaviour exit = ExitManager.instance.GetAvailableExit();

        GameObject newCar = Instantiate(CarPrefab, start.transform.position, start.transform.rotation);
        newCar.GetComponent<CarBehaviour>().SpawnPoint = start;
        newCar.GetComponent<CarBehaviour>().TargetPoint = exit;
        newCar.GetComponent<CarBehaviour>().IsPlayerCar = true;
    }
}
