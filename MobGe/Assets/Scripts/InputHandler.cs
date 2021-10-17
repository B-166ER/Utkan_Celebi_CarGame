using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public static List<RaycastResult> results;
    public void Update()
    {
        GameManager.instance.rightPressed = false;
        GameManager.instance.leftPressed = false;
        if ( IsPointerOverUIObject() && Input.GetMouseButton(0))
        {
            if(results[0].gameObject.name == "Right touch area")
            {
                GameManager.instance.rightPressed = true;
                GameManager.instance.leftPressed = false;
                GameManager.instance.TimeFrozen = false;
            } 
            else if (results[0].gameObject.name == "Left touch area")
            {
                GameManager.instance.rightPressed = false;
                GameManager.instance.leftPressed = true;
                GameManager.instance.TimeFrozen = false;
            }
        }
    }
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
