using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAutoguidedMissile1 : MonoBehaviour
{
    // Transform m_Transform;
    // Rigidbody m_Rigidbody;

    [SerializeField] float speed = 5f;

    private void Awake()
    {
        // m_Transform = transform;
        // m_Rigidbody = GetComponent<Rigidbody>();
        //m_Transform.rotation = Quaternion.AngleAxis(-90f, Vector3.right);
    }

    void Start(){
       // m_Transform.rotation = Quaternion.AngleAxis(-180f, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        // Transform Target = GetPlayerTransform();
        // if(Target != null){
        //     Vector3 position = Vector3.MoveTowards(m_Rigidbody.position, Target.position, 0.5f);
        //     Vector3 targetPostion = new Vector3(Target.position.x, m_Rigidbody.position.y, m_Rigidbody.position.z);
        //     m_Rigidbody.MovePosition(position);

        //     // Vector3 direction = Target.position - m_Transform.position;
        //     // Quaternion rotation = Quaternion.LookRotation(-direction, m_Rigidbody.transform.right);
        //     // Quaternion degree = Quaternion.Euler(rotation.x, rotation.y, rotation.z + 90f);
        //     // m_Rigidbody.MoveRotation(Quaternion.RotateTowards(m_Transform.rotation, rotation, 5f));

        //     Vector3 direction = Target.position - m_Transform.position;
        //     Vector3 upwards = new Vector3(0, 90, -90);
        //     Quaternion rotation = Quaternion.LookRotation(upwards, direction);
        //     m_Rigidbody.MoveRotation(
        //         Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.RotateTowards(m_Transform.rotation, rotation, 180f), speed*Time.deltaTime));
        // }
        // else{
        //     Destroy(gameObject);
        // }
        
        // Quaternion thisRotation = Quaternion.Lerp(m_Transform.rotation, Quaternion.AngleAxis(-90f, Vector3.up), 0.5f);
        //m_Transform.localRotation = thisRotation;
        // m_Transform.rotation += Quaternion.RotateTowards(m_Transform.rotation,)
    }

    // private Transform GetPlayerTransform(){
    //     if(GameObject.FindWithTag("Player") == null){
    //         return null;
    //     }
    //     return GameObject.FindWithTag("Player").transform;
    // }

    // private IEnumerator MissileBehavior(){
    //     Transform Target = GetPlayerTransform();
    //     if(Target != null){
    //         MissileMove(Target);
    //         MissileRotate(Target);
    //     }
    //     else{
    //         Destroy(gameObject);
    //     }
    //     yield return null;
    // }

    // private void MissileMove(Transform Target){
    //     Vector3 position = Vector3.MoveTowards(m_Rigidbody.position, Target.position, 0.5f);
    //     Vector3 targetPostion = new Vector3(Target.position.x, m_Rigidbody.position.y, m_Rigidbody.position.z);
    //     m_Rigidbody.MovePosition(position);
    // }

    // private void MissileRotate(Transform Target){
    //     Vector3 direction = Target.position - m_Transform.position;
    //     Vector3 upwards = new Vector3(0, 90, -90);
    //     Quaternion rotation = Quaternion.LookRotation(upwards, direction);
    //     m_Rigidbody.MoveRotation(
    //         Quaternion.Lerp(m_Rigidbody.rotation, Quaternion.RotateTowards(m_Transform.rotation, rotation, 180f), 
    //         speed*Time.deltaTime));
    // }
}
