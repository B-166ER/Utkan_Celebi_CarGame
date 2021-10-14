using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
    public EntrenceBehaviour SpawnPoint;
    public ExitBehaviour TargetPoint;
    public bool IsPlayerCar;
    public bool IsReachedTarget;

    public List<Vector3> SavedPositions = new List<Vector3>();
    public List<Quaternion> SavedQuaternions = new List<Quaternion>();

    public abstract void ResetTheCar(); 

}
