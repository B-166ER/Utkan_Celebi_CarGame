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
            collision.gameObject.GetComponent<Car>().IsReachedTarget = true;
            // player reached target
            // reset all cars and froze time
            Debug.Log("asd "+ collision.gameObject.GetComponent<Car>().IsPlayerCar);
            collision.gameObject.GetComponent<CarBehaviour>().ResetTheCar();
        }
        else if (collision.gameObject.GetComponent<Car>().TargetPoint == this && !collision.gameObject.GetComponent<Car>().IsPlayerCar)
        {
            //if previous car reached wait 3 seconds and reset
            Debug.Log("about to reset");
            StartCoroutine(waitBeforeProgressRoutine());
        }
    }

    public IEnumerator waitBeforeProgressRoutine()
    {

        Debug.Log("waiting before reset");
        yield return new WaitForSecondsRealtime( GameManager.instance.secondsBeforeAutoCarArrivalReset );
        //reset this session
        Debug.Log("reset session");
    }
  
}
