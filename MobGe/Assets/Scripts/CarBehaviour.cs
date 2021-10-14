using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : Car
{
    [Range(0f,100f)] [SerializeField] float MoveForwardSpeed;

    public override void ResetTheCar()
    {
        // prepare autocar object
        if (IsReachedTarget)
        {
            gameObject.GetComponent<AutoCar>().enabled = true;
            gameObject.GetComponent<AutoCar>().IsPlayerCar = false;
            gameObject.GetComponent<AutoCar>().SavedPositions = SavedPositions;
            gameObject.GetComponent<AutoCar>().SavedQuaternions = SavedQuaternions;
            this.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 5);

        SavedPositions.Add(gameObject.transform.position);
        SavedQuaternions.Add(gameObject.transform.rotation);

        Debug.Log("saved car size "+SavedPositions.Count);
        gameObject.transform.position += gameObject.transform.forward/100*MoveForwardSpeed;
        if (Input.GetKey("a"))
        {
            gameObject.transform.Rotate(Vector3.up, -1, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            gameObject.transform.Rotate(Vector3.up, 1, Space.World);
        }
    }

}
