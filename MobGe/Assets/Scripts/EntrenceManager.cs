﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrenceManager : MonoBehaviour
{
    public static EntrenceManager instance;
    public List<EntrenceBehaviour> AllEntrences = new List<EntrenceBehaviour>();

    public void Init()
    {
        instance = this;
    }

     
}