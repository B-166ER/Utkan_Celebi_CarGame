using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public static ExitManager instance;
    public List<ExitBehaviour> AllExits = new List<ExitBehaviour>();

    public void Init()
    {
        instance = this;
    }
}
