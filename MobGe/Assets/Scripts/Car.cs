using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public EntrenceBehaviour SpawnPoint;
    public ExitBehaviour TargetPoint;
    public bool IsPlayerCar = true;
    public bool IsReachedTarget;

    public List<Vector3> SavedPositions = new List<Vector3>();
    public List<Quaternion> SavedQuaternions = new List<Quaternion>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Car>() != null)
            GameManager.instance.ResetSession();
    }

    [Range(0f, 100f)] [SerializeField] float MoveForwardSpeed;

    Color clr;
    MeshRenderer mr;

    //when cars get reset
    public void OnReset()
    {
        MeshRenderer mr = TargetPoint.gameObject.GetComponent<MeshRenderer>();
        Debug.Log("i got reset");
        if (IsPlayerCar)
        {
            //switch colors of exit and restart saved path
            clr = mr.material.color;
            clr.a = 1f;
            mr.material.color = clr;
            SavedPositions.Clear();
            SavedQuaternions.Clear();
        }
        else
        {
            clr = mr.material.color;
            clr.a = 0.2f;
            mr.material.color = clr;
        }
            
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 5);


        if (!GameManager.instance.TimeFrozen)
        {
            //move with player input
            if (IsPlayerCar)
            {
                gameObject.transform.position += gameObject.transform.forward / 100 * MoveForwardSpeed;

                SavedPositions.Add(gameObject.transform.position);
                SavedQuaternions.Add(gameObject.transform.rotation);

                if (GameManager.instance.leftPressed)
                {
                    gameObject.transform.Rotate(Vector3.up, -1, Space.Self);
                }
                if (GameManager.instance.rightPressed)
                {
                    gameObject.transform.Rotate(Vector3.up, 1, Space.World);
                }
            }
            //move auto by saved positions
            else
            {
                if (i < SavedPositions.Count)
                {
                    gameObject.transform.position = SavedPositions[i];
                    gameObject.transform.rotation = SavedQuaternions[i];
                    i++;
                }
            }
        }

    }

    int i;
    // reset for autocar movement
    public virtual void ResetSavedPosIndex() 
    {
        i = 0;
    }

}
