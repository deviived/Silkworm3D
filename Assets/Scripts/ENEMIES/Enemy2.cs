using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    /* ENEMY VARIABLES */
    public float life = 1;

    /* BULLETS VARIABLES */
    public float speed = 6;
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] float m_BallSpeed;

    [SerializeField] float m_CoolDownDuration;
    float m_TimeNextShoot;
    /* °end° */

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
        
    }

    void FixedUpdate()
    {
        EnemyPath();
        if (Time.time > m_TimeNextShoot)
        {
            ShootBall();
            m_TimeNextShoot = Time.time + m_CoolDownDuration;
        }
    }


    
    void ShootBall()
    {
        GameObject ballSpawerPrefab = getChildGameObject(gameObject, "Enemy_spawner_bullet_1");
        GameObject ballGO = Instantiate(m_BallPrefab, ballSpawerPrefab.GetComponent<Transform>().position, Quaternion.identity, null);
        Rigidbody ballRigidBody = ballGO.GetComponent<Rigidbody>();
        ballRigidBody.MoveRotation(Quaternion.AngleAxis(-90, Vector3.forward));
        Vector3 firebulletdirection = new Vector3(-15 * 10, 0);
        FindObjectOfType<AudioManager>().Play("EnemyShoot1");
        StartCoroutine(BulletLifespan(ballGO));
    }

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            // Debug.Log("transform name : "+t.name);
            if (t.gameObject.name == withName) return t.gameObject;
        }
            
        return null;
    }

    private void EnemyPath(){
         Vector3 position = new Vector3(-5f * speed, -0.5f * speed, 0);
        m_Rigidbody.MovePosition(m_Transform.position + (position * Time.deltaTime));
    }

    private IEnumerator BulletLifespan(GameObject GO){
        yield return new WaitForSeconds(1f);
        //Debug.Log("Have waited 1 secs");
        Destroy(GO);
        yield return null;
    }
}
