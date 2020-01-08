using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    Vector3 firebulletdirection;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        firebulletdirection = new Vector3(-1, 0);
        /*rb.velocity = firebulletdirection;*/
    }

    private void OnCollisionEnter(Collision collision)
    {

       
        //gameObject.

        // IDENTIFICATION BY TAG
        /*if (collision.gameObject.CompareTag("Recolor"))
            collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();*/

        // IDENTIFICATION BY LAYER
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && gameObject.name != "FireBullet Prefab(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        // IDENTIFICATION BY NAME
        /* if (collision.gameObject.name.CompareTo("Cube") == 0)
         {
             Rigidbody rb = collision.rigidbody;
             if (rb) rb.AddForce(Vector3.up * 40, ForceMode.Impulse);
         }*/

        // IDENTIFICATION BY COMPONENT
        /* if (collision.gameObject.GetComponent<Enemy>())
             Destroy(collision.gameObject);*/

        // IDENTIFICATION BY INTERFACE
        /*IPropel propel = collision.gameObject.GetComponent<IPropel>();
        if(propel != null)
        {
            Destroy(collision.gameObject);
        }*/



        //Destroy(gameObject);
        //collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
        //collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();

        /*Destroy(gameObject);*/
        //collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
    }

    private void FixedUpdate()
    {
        /*rb = gameObject.GetComponent<Rigidbody>();*/
        gameObject.transform.position += firebulletdirection;
    }
}
