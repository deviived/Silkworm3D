using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMiss : MonoBehaviour
{
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallPointSpawner;
    [SerializeField] float m_BallSpeed;

    [SerializeField] float m_CoolDownDuration;
    float m_TimeNextShoot;

    [SerializeField] float m_TranslationSpeed;
    [SerializeField] float m_RotationSpeed;

    [SerializeField] MeshRenderer m_BodyMR;
    [SerializeField] LayerMask m_Layermask;

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
        m_TimeNextShoot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int layerMask = (1 << LayerMask.NameToLayer("Ceiling")) + (1 << LayerMask.NameToLayer("Enemy"));
        /*if (Physics.Raycast(m_Transform.position, Vector3.up, out hit, float.PositiveInfinity, layerMask))
        {
            m_BodyMR.material.color = Random.ColorHSV();
        }*/
        if (Physics.Raycast(m_Transform.position, Vector3.up, out hit, float.PositiveInfinity, m_Layermask))
        {
            m_BodyMR.material.color = Random.ColorHSV();
        }
    }

    private void FixedUpdate()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
        bool isFiring = Input.GetButton("Fire1");

        m_Rigidbody.MovePosition(m_Rigidbody.position + vInput * m_Transform.forward * m_TranslationSpeed * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(Quaternion.AngleAxis(hInput * m_RotationSpeed * Time.fixedDeltaTime, Vector3.up) * m_Rigidbody.rotation);

        if (isFiring && Time.time > m_TimeNextShoot)
        {
            ShootBall();
            m_TimeNextShoot = Time.time + m_CoolDownDuration;
        }
    }

    void ShootBall()
    {
        GameObject ballGO = Instantiate(m_BallPrefab, m_BallPointSpawner.position, Quaternion.identity, null);
        Rigidbody ballRigidBody = ballGO.GetComponent<Rigidbody>();
        ballRigidBody.velocity = m_BallSpeed * m_BallPointSpawner.forward;
    }
}
