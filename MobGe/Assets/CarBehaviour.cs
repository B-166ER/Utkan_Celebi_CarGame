using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    [Range(0f,100f)] [SerializeField] float MoveForwardSpeed;
    bool left,right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 5);
        gameObject.transform.position += gameObject.transform.forward/100*MoveForwardSpeed;
        if (Input.GetKey("a"))
        {
            left = true;
            right = false;
            gameObject.transform.Rotate(Vector3.up, -1, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            right = true;
            left = false;
            gameObject.transform.Rotate(Vector3.up, 1, Space.World);
        }
    }
}
