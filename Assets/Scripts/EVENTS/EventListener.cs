using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    private void Awake()
    {
        
    }

    void EventCallback()
    {
        Debug.Log(name + " reacting to event");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<EventEmitter>().AddListener(EventCallback);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
