using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoguidedMissile3 : MonoBehaviour
{
    Transform m_Transform;
    Rigidbody m_Rigidbody;

    [SerializeField] float speed = 5f;

    private void Awake()
    {
        m_Transform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
        //m_Transform.rotation = Quaternion.AngleAxis(-90f, Vector3.right);
    }

    void Start(){
       // m_Transform.rotation = Quaternion.AngleAxis(-180f, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        MissileBehavior();
    }

    private Transform GetPlayerTransform(){
        if(GameObject.FindWithTag("Player") == null){
            return null;
        }
        return GameObject.FindWithTag("Player").transform;
    }

    private IEnumerator MissileBehavior(){
        Transform Target = GetPlayerTransform();
        if(Target != null){
            MissileMove(Target);
            MissileRotate(Target);
        }
        else{
            Destroy(gameObject);
        }
        yield return null;
    }

    private void MissileMove(Transform Target){
        Vector3 position = Vector3.MoveTowards(m_Rigidbody.position, Target.position, 0.5f);
        Vector3 targetPostion = new Vector3(Target.position.x, m_Rigidbody.position.y, m_Rigidbody.position.z);
        m_Rigidbody.MovePosition(position);
    }

    private void MissileRotate(Transform Target){
        Vector3 direction = Target.position - m_Transform.position;
        Vector3 upwards = new Vector3(0, 90, -90);
        Quaternion rotation = Quaternion.LookRotation(upwards, direction);
        m_Rigidbody.MoveRotation(
            Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.RotateTowards(m_Transform.rotation, rotation, 180f), 
            speed*Time.deltaTime));
    }
}
