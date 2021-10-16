using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerManager : MonoBehaviour
{
    public static CarSpawnerManager instance;

    public List<Car> Cars = new List<Car>();
    public GameObject CarPrefab;

    public void OnEnable()
    {
        instance = this;
    }
    public void Init()
    {

    }

    public void ResetPositionOfCars()
    {
        foreach (Car car in Cars)
        {
            if (car.IsReachedTarget)
            {
                car.ResetSavedPosIndex();
                car.OnReset();
            }
            else if (car.IsPlayerCar)
            {
                car.transform.position = car.SpawnPoint.transform.position;
                car.transform.rotation = car.SpawnPoint.transform.rotation;
                car.OnReset();
            }
        }
    }

    public void ResetAllAutoCar()
    {
        foreach (Car car in Cars)
        {
            car.IsReachedTarget = true;
            car.IsPlayerCar = false;
            car.ResetSavedPosIndex();
            car.OnReset();
        }
    }
    public void ResetCar(Car c)
    {
        c.IsReachedTarget = true;
        c.IsPlayerCar = false;
        c.ResetSavedPosIndex();
        c.OnReset();
    }
    public Car GetPlayerCar()
    {
        foreach (Car car in Cars)
        {
            if (car.GetComponent<Car>().IsPlayerCar)
            {
                return car;
            }
        }
        return null;
    }
    public int GetCarCount()
    {
        return Cars.Count;
    }
    public void SpawnNewPlayerCar()
    {
        EntrenceBehaviour start = EntrenceManager.instance.GetAvailableEntrence();

        ExitBehaviour exit = ExitManager.instance.GetAvailableExit();

        GameObject newCar = Instantiate(CarPrefab, start.transform.position, start.transform.rotation,gameObject.transform);
        Cars.Add(newCar.GetComponent<Car>());
        
        newCar.GetComponent<Car>().SpawnPoint = start;
        newCar.GetComponent<Car>().TargetPoint = exit;
        newCar.GetComponent<Car>().IsPlayerCar = true;
        newCar.GetComponent<Car>().OnReset();

    }
}
