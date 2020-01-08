using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScrolling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform bgTransform = gameObject.GetComponent<Transform>();
        transform.position += new Vector3(-0.1f, 0 ,0);
    }
}
