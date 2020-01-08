using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : MonoBehaviour
{
    [SerializeField] float m_TranslationSpeed;

    Transform m_Transform;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Transform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //m_Rigidbody.MovePosition(m_Rigidbody.position + 1 * m_Transform.up * m_TranslationSpeed * Time.fixedDeltaTime);
    }
}
