using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEmitter : MonoBehaviour
{
    event Action OnMyEvent;

    public void AddListener(Action listener)
    {
        OnMyEvent += listener;
    }

    void EmitEvent()
    {
        if(OnMyEvent != null)
            OnMyEvent();
    }

    void Start()
    {
        InvokeRepeating("EmitEvent", 1, 1);   
    }

    void Update()
    {
        
    }
}
