using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrenceBehaviour : MonoBehaviour
{
    
    [SerializeField] bool free = true;
    private void Start()
    {
        EntrenceManager.instance.AllEntrences.Add(this);
    }
}
