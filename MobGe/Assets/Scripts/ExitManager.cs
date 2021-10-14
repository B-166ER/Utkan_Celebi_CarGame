using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public static ExitManager instance;
    public List<ExitBehaviour> AllExits = new List<ExitBehaviour>();

    private void OnEnable()
    {
        instance = this;
    }
    public void Init()
    {
    }
    public ExitBehaviour GetAvailableExit()
    {

        foreach (var item in AllExits)
        {
            if (item.available == true)
            {
                item.available = false;
                return item;
            }
        }
        return null;
    }
}
