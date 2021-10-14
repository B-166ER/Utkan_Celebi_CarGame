using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCar : Car
{
    int i=0;
    public override void ResetTheCar()
    {
        if (IsReachedTarget)
        {
            i = 0;
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = SavedPositions[i];
        gameObject.transform.rotation = SavedQuaternions[i];
        i++;
    }
}
