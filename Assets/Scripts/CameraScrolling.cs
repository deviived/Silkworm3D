using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrolling : MonoBehaviour
{

    [SerializeField] Transform m_EndPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody cameraBody = gameObject.GetComponent<Rigidbody>();
        Transform cameraTransform = gameObject.GetComponent<Transform>();
        Vector3 direction = new Vector3(cameraBody.position.x + 1 * 5 * Time.fixedDeltaTime,
            cameraBody.position.y + 1 * 5 * Time.fixedDeltaTime);
        cameraBody.MovePosition(direction);
    }

}
