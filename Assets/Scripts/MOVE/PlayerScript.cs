using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /* BULLETS VARIABLES */
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallPointSpawner;
    [SerializeField] float m_CoolDownDuration;

    [SerializeField] GameObject m_BallPrefab2;
    [SerializeField] Transform m_BallPointSpawner2;

    [SerializeField] float m_CoolDownDuration2;
    float m_TimeNextShoot;
    float m_TimeNextShoot2;

    /* °end° */

    [Range(-100f, 100f)] public float xLockMin = -50f;
    [Range(-100f, 100f)] public float xLockMax = 50f;
    [Range(-100f, 100f)] public float yLockMin = -50f;
    [Range(-100f, 100f)] public float yLockMax = 50f;
    
    [SerializeField] float m_TranslationSpeed = 100f;
    //[SerializeField] float m_RotationSpeed;

    Transform m_Transform;
    Rigidbody m_Rigidbody;

    [SerializeField] Transform playerBody;

    private void Awake()
    {
        m_Transform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_TimeNextShoot = Time.time;
        m_TimeNextShoot2 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        bool isFiring = Input.GetButton("Fire1");

        float xRotation = Mathf.Clamp(x * 20, -30, 30);
        Move(x, y);
        Rotate(x);

        // Debug.Log("isFiring : "+isFiring);

        if (isFiring && Time.time > m_TimeNextShoot)
        {
            FirstCannon();
            m_TimeNextShoot = Time.time + m_CoolDownDuration;
        }
        if (isFiring && Time.time > m_TimeNextShoot2)
        {
            SecondCannon();
            m_TimeNextShoot2 = Time.time + m_CoolDownDuration2;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void Move(float x, float y){
        Vector3 position = new Vector3(x * m_TranslationSpeed, y * m_TranslationSpeed, 0);
        var pos = m_Transform.position + (position * Time.deltaTime);
        pos.x = Mathf.Clamp(pos.x, xLockMin, xLockMax);
        pos.y = Mathf.Clamp(pos.y, yLockMin, yLockMax);
        m_Rigidbody.MovePosition(pos);
    }

    private void Rotate(float x){
        Quaternion quaternion = Quaternion.Euler(new Vector3(0, 0, -x * 25));
        playerBody.rotation = quaternion;
    }


    private void ShootBall()
    {
        // FIRST CANNON
        FirstCannon();

        // SECOND CANNON
        SecondCannon();
    }

    private void FirstCannon(){
        GameObject ballGO = Instantiate(m_BallPrefab, m_BallPointSpawner.position, Quaternion.Euler(45, 0, -90), null);
        Rigidbody ballRigidBody = ballGO.GetComponent<Rigidbody>();
        FindObjectOfType<AudioManager>().Play("PlayerShoot1");
        StartCoroutine(BulletLifespan(ballGO));
    }

    private void SecondCannon(){
        GameObject ballGO = Instantiate(m_BallPrefab2, m_BallPointSpawner2.position, Quaternion.identity, null);
        Rigidbody ballRigidBody = ballGO.GetComponent<Rigidbody>();
        StartCoroutine(BulletLifespan(ballGO));
    }

    private IEnumerator BulletLifespan(GameObject GO){
        yield return new WaitForSeconds(2f);
        Destroy(GO);
        yield return null;
    }

    public void TakeDamage(){
        Life life = FindObjectOfType<Life>();
        if(life.GetLife() > 0){
            life.SetLife(life.GetLife()-1);
            FindObjectOfType<AudioManager>().Play("Explosion");
            GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
        }
        if(life.GetLife() == 0){
            Die();
        }
    }

    private void Die(){
        FindObjectOfType<AudioManager>().Play("Explosion");
        Destroy(gameObject);
    }
}
