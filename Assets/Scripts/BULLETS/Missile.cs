using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Vector3 firebulletdirection;
    // Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        firebulletdirection = new Vector3(-1f, 0);
    }

    private void OnTriggerEnter(Collider collider){
        // Life life = FindObjectOfType<Life>();
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerScript>().TakeDamage();
            // if(collider.gameObject.GetComponent<PlayerScript>().life > 0){
            //     FindObjectOfType<AudioManager>().Play("Explosion");
            //     collider.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
            //     collider.gameObject.GetComponent<PlayerScript>().life--;
            // }
            // if(collider.gameObject.GetComponent<PlayerScript>().life == 0){
            //     FindObjectOfType<AudioManager>().Play("Explosion");
            //     Destroy(collider.gameObject);
            // }
            // life.SetLife(collider.gameObject.GetComponent<PlayerScript>().life.ToString());
            Destroy(gameObject);
            
        }
    }
    
    private void FixedUpdate()
    {
        gameObject.transform.position += firebulletdirection;
    }
}
