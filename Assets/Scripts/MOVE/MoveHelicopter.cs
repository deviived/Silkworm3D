using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelicopter : MonoBehaviour
{
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallPointSpawner;
    [SerializeField] float m_BallSpeed;

    [SerializeField] GameObject m_BallPrefab2;
    [SerializeField] Transform m_BallPointSpawner2;
    [SerializeField] float m_BallSpeed2;

    [SerializeField] float m_CoolDownDuration;
    float m_TimeNextShoot;

    [SerializeField] float m_TranslationSpeed = 100f;
    //[SerializeField] float m_RotationSpeed;

    Transform m_Transform;
    Rigidbody m_Rigidbody;

    [SerializeField] Transform playerBody;

    public CharacterController controller;

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
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        bool isFiring = Input.GetButton("Fire1");

        float xRotation = Mathf.Clamp(x, 0f, 0f);

        // m_Rigidbody.MovePosition(m_Rigidbody.transform.localPosition + vInput * m_Transform.up * m_TranslationSpeed * Time.fixedDeltaTime);
        // m_Rigidbody.MovePosition(m_Rigidbody.position + hInput * m_Transform.right * m_TranslationSpeed * Time.fixedDeltaTime);
        Vector3 move = m_Transform.right * x + m_Transform.up * y;
        controller.Move(move * m_TranslationSpeed * Time.deltaTime);
        // transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f)
        // playerBody.Rotate(Vector2.right * x);
        // Quaternion.RotateTowards(m_Rigidbody.rotation, m_Rigidbody.rotation
        //  * Quaternion.AngleAxis(-x*30, Vector3.right), 
        //     45 * Time.deltaTime);
        Quaternion quaternion = Quaternion.Euler(new Vector3(x * 20, 90, 0));
        playerBody.rotation = quaternion;
        // Vector3 move = m_Transform.right * x * m_TranslationSpeed + m_Transform.up * y * m_TranslationSpeed;
        // Vector3 smoothedMovement = Vector3.Lerp(m_Transform.position, move, 0.125f);
        // controller.Move(smoothedMovement);
       // Vector3 smoothedRotation = Vector3.Lerp(playerBody.rotation, new Vector3(x * 20, 90, 0), Easing.Exponential.In);
       // Quaternion quaternion = Quaternion.Euler();
        //playerBody.rotation = quaternion;
    }

    private void FixedUpdate()
    {
        // float vInput = Input.GetAxis("Vertical");
        // float hInput = Input.GetAxis("Horizontal");
        // //float acceleration = 3f;
        // bool isFiring = Input.GetButton("Fire1");

        // //Debug.Log("vector direction" + m_TranslationSpeed * (hInput * 100));

        // Vector3 direction = new Vector3(m_Rigidbody.position.x * hInput * m_TranslationSpeed * Time.fixedDeltaTime, 
        //    m_Rigidbody.position.y * vInput * m_TranslationSpeed * Time.fixedDeltaTime);

        
        // if(y != 0){ss
        //     m_Rigidbody.velocity = m_Rigidbody.velocity + vInput * m_Transform.up * m_TranslationSpeed * Time.fixedDeltaTime;
        // }
        // else if(y == 0){
        //     m_Rigidbody.velocity = new Vector3();
        // }
        // m_Rigidbody.velocity = move * m_TranslationSpeed * Time.fixedDeltaTime;
        //m_Rigidbody.MoveRotation(Quaternion.AngleAxis(hInput * m_RotationSpeed * Time.fixedDeltaTime, Vector3.up) * m_Rigidbody.rotation);

        // m_Rigidbody.MovePosition(direction);

       // m_Rigidbody.AddForce(direction);

        // m_Rigidbody.MovePosition(m_Rigidbody.position + (vInput * m_Transform.up * m_TranslationSpeed * Time.fixedDeltaTime));
        // m_Rigidbody.MovePosition(m_Rigidbody.position +( hInput * m_Transform.right * m_TranslationSpeed * Time.fixedDeltaTime));

        // Debug.Log("vInput : " + vInput);
        //  Debug.Log("hInput : " + hInput);

        /*   if ((hInput > 0 && m_Rigidbody.rotation.z > -0.30) || (hInput < 0 && m_Rigidbody.rotation.z < 0.30))
               m_Rigidbody.MoveRotation(Quaternion.AngleAxis(3f * hInput, Vector3.forward) * m_Rigidbody.rotation);*/

        // m_Rigidbody.rotation = Quaternion.RotateTowards(m_Rigidbody.rotation, Quaternion.AngleAxis(-hInput*30, Vector3.left), 
        //     90 * Time.fixedDeltaTime);
        // Quaternion quaternion = Quaternion.EulerRotation(new Vector3(-x * 30, 0, -x * 30));


        // m_Rigidbody.rotation = Quaternion.RotateTowards(m_Rigidbody.rotation, Quaternion.AngleAxis(-x * 30, Vector3.forward),
        //     90 * Time.fixedDeltaTime);

        // if (hInput > 0 && m_Rigidbody.rotation.z > -0.30)
        // {
        //     m_Rigidbody.MoveRotation(Quaternion.AngleAxis(-3f * hInput, Vector3.forward) * m_Rigidbody.rotation);
        // }
        // if (hInput < 0 && m_Rigidbody.rotation.z < 0.30)
        // {
        //     m_Rigidbody.MoveRotation(Quaternion.AngleAxis(3f, Vector3.forward) * m_Rigidbody.rotation);
        // }
        // if ((hInput != 1 && hInput != -1) && m_Rigidbody.rotation.z > 0.10)
        // {
        //     m_Rigidbody.MoveRotation(Quaternion.AngleAxis(-3f, Vector3.forward) * m_Rigidbody.rotation);
        // }
        // if (hInput != -1 && m_Rigidbody.rotation.z < -0.10)
        // {
        //     m_Rigidbody.MoveRotation(Quaternion.AngleAxis(3f, Vector3.forward) * m_Rigidbody.rotation);
        // }


        // if (isFiring && Time.time > m_TimeNextShoot)
        // {
        //     ShootBall(x);
        //     m_TimeNextShoot = Time.time + m_CoolDownDuration;
        // }
    }

    void ShootBall(float hInput)
    {
        // FIRST CANNON
        GameObject ballGO = Instantiate(m_BallPrefab, m_BallPointSpawner.position, Quaternion.identity, null);
        Rigidbody ballRigidBody = ballGO.GetComponent<Rigidbody>();
        ballRigidBody.MoveRotation(Quaternion.AngleAxis(-90, Vector3.forward));
        Quaternion.RotateTowards(m_Rigidbody.rotation, Quaternion.AngleAxis(-hInput * 30, Vector3.left),
            90 * Time.fixedDeltaTime);
        ballRigidBody.velocity = (m_BallSpeed+45f) * m_BallPointSpawner.forward;

        // SECOND CANNON
        /*GameObject ballGO2 = Instantiate(m_BallPrefab2, m_BallPointSpawner2.position, Quaternion.identity, null);
        Rigidbody ballRigidBody2 = ballGO2.GetComponent<Rigidbody>();
        ballRigidBody2.MoveRotation(Quaternion.AngleAxis(45, Vector3.forward));
        //ballRigidBody2.velocity = m_BallSpeed2 * m_BallPointSpawner2.forward;
        Vector3 firebulletdirection = new Vector3(15*10, -15*10);
        ballRigidBody2.velocity = firebulletdirection;*/
    }
}
