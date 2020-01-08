using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_enemy : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] float m_BallSpeed;

    [SerializeField] float m_CoolDownDuration;
    float m_TimeNextShoot;

    // Start is called before the first frame update
    void Start()
    {
        m_TimeNextShoot = Time.time;
        /*GameObject pathEnemyGO = Instantiate(pathEnemy1.gameObject, m_PlaneSpawner.GetComponent<Transform>().position, Quaternion.identity, null);
        pathEnemy1 = pathEnemyGO.GetComponent<PathCreator>();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Debug.Log("gameObject name : " + gameObject.name);
        //PathCreator pathCreator = getChildGameObject(gameObject, "PATH_Enemy_1").GetComponent<PathCreator>();
        // distanceTravelled += speed * Time.deltaTime;
        //PathCreator pathEnemy2 = Instantiate(pathEnemy1, pathEnemy1.GetComponent<Transform>().position, Quaternion.identity, null);
        //Vector3 decalage = new Vector3(pathEnemy1.GetComponent<Transform>().position.x * 2f, m_PlaneSpawner.position.y);
        //pathEnemy1.GetComponent<Transform>().position += decalage;
        // transform.position = pathEnemy1.path.GetPointAtDistance(distanceTravelled);
        //PathCreator pathCreator = getChildGameObject(gameObject, "PATH_Enemy_1").GetComponent<PathCreator>();
        /* distanceTravelled += speed + Time.deltaTime;
        transform.position = pathEnemy1.path.GetPointAtDistance(distanceTravelled);*/
        //EnemyPath();
        if (Time.time > m_TimeNextShoot)
        {
            ShootBall();
            m_TimeNextShoot = Time.time + m_CoolDownDuration;
        }
    }


    
    void ShootBall()
    {
        // FIRST CANNON
        GameObject ballSpawerPrefab = getChildGameObject(gameObject, "Enemy_spawner_bullet_1");
        GameObject ballGO = Instantiate(m_BallPrefab, ballSpawerPrefab.GetComponent<Transform>().position, Quaternion.identity, null);
        Rigidbody ballRigidBody = ballGO.GetComponent<Rigidbody>();
       /* ballRigidBody.MoveRotation(Quaternion.AngleAxis(-90, Vector3.forward));
        Vector3 firebulletdirection = new Vector3(-15 * 10, 0);*/
        //ballRigidBody.transform.position += firebulletdirection;
        //ballRigidBody.AddForce(Vector3.right * -140, ForceMode.Impulse);

        // SECOND CANNON
        /*GameObject ballGO2 = Instantiate(m_BallPrefab2, m_BallPointSpawner2.position, Quaternion.identity, null);
        Rigidbody ballRigidBody2 = ballGO2.GetComponent<Rigidbody>();
        ballRigidBody2.MoveRotation(Quaternion.AngleAxis(45, Vector3.forward));
        //ballRigidBody2.velocity = m_BallSpeed2 * m_BallPointSpawner2.forward;
        Vector3 firebulletdirection = new Vector3(15 * 10, -15 * 10);
        ballRigidBody2.velocity = firebulletdirection;*/
    }

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            Debug.Log("transform name : "+t.name);
            if (t.gameObject.name == withName) return t.gameObject;
        }
            
        return null;
    }

    private void EnemyPath(){
        
    }
}
