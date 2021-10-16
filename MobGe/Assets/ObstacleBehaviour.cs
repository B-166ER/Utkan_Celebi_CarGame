using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.ResetSession();
    }
}
