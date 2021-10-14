using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrenceManager : MonoBehaviour
{
    public static EntrenceManager instance;
    public List<EntrenceBehaviour> AllEntrences = new List<EntrenceBehaviour>();
    private void OnEnable()
    {
        instance = this;
    }
    public void Init()
    {
    }
    public EntrenceBehaviour GetAvailableEntrence()
    {
        foreach (var item in AllEntrences)
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
