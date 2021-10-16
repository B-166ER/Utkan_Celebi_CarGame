using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{
    [SerializeField] public bool available = true;
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.GetComponent<Car>().TargetPoint == this && collision.gameObject.GetComponent<Car>().IsPlayerCar)
        {

            // player reached target
            // reset all cars and froze time
            Car car = collision.gameObject.GetComponent<Car>();


            GameManager.instance.Progress(car);
            GameManager.instance.TimeFrozen = true;
        }
        else if (collision.gameObject.GetComponent<Car>().TargetPoint == this && !collision.gameObject.GetComponent<Car>().IsPlayerCar)
        {
            //if previous car reached wait 3 seconds and reset
            if(!GameManager.instance.CR_running)
                GameManager.instance.ResetWithDelay();
        }
    }

  
}
