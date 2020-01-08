using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassA : Singleton<ClassA>
{

    public bool IsReady { get; private set; }

    void LOG(string msg)
    {
        //Debug.Log(Time.frameCount + "-" + this.GetType() + "-" + msg);
    }

    protected override void Awake()
    {
        base.Awake();
        IsReady = false;
        
        LOG("AWAKE");
    }

    void OnEnable()
    {
        LOG("OnEnable");
    }

    void OnDestroy()
    {
        LOG("OnDestroy");
    }

    private void OnDisable()
    {
        LOG("OnDisable");
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {  
        LOG("START");
        yield return new WaitForSeconds(2);
        IsReady = true;
        Debug.Log("Class A singleton has been initialized");
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        LOG("UPDATE");
    }

    void FixedUpdate()
    {
        LOG("fixedUPDATE");
    }
    void LateUpdate()
    {
        LOG("lateUPDATE");
    }
}
