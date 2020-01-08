using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassB : Singleton<ClassB>
{

    public bool IsReady { get; private set; }

    void LOG(string msg)
    {
        //Debug.Log(Time.frameCount + "-" + this.GetType() + "-" + msg);
    }

    void Awake()
    {
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
        while (!ClassA.Instance.IsReady)
            yield return null;
        yield return new WaitForSeconds(1);
        Debug.Log("Class B singleton has been initialized");
        IsReady = true;
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
