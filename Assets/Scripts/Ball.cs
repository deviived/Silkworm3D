using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 firebulletdirection;
    [SerializeField] string bulletType;
    // Start is called before the first frame update
    void Start()
    {
        switch(bulletType){
            case "front":
                firebulletdirection = new Vector3(3.5f, 0);
                break;
            case "diagonal":
                firebulletdirection = new Vector3(1.5f, -1f);
                break;
            default:
                firebulletdirection = new Vector3(3.5f, 0);
                break;
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Score score = FindObjectOfType<Score>();
        
        // IDENTIFICATION BY LAYER
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if(collision.gameObject.GetComponent<Enemy1>() && collision.gameObject.GetComponent<Enemy1>().life == 0){
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Explosion");
                score.SetScore((score.GetScore() + 100).ToString());
            }
            if(collision.gameObject.GetComponent<Enemy1>() && collision.gameObject.GetComponent<Enemy1>().life > 0){
                collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
                collision.gameObject.GetComponent<Enemy1>().life -= 1;
                FindObjectOfType<AudioManager>().Play("Degat");
                FindObjectOfType<AudioManager>().Play("ExplosionMin");
                score.SetScore((score.GetScore() + 30).ToString());
            }
            if(collision.gameObject.GetComponent<Enemy2>() && collision.gameObject.GetComponent<Enemy2>().life == 0){
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Explosion");
                score.SetScore((score.GetScore() + 150).ToString());
            }
            if(collision.gameObject.GetComponent<Enemy2>() && collision.gameObject.GetComponent<Enemy2>().life > 0){
                collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
                collision.gameObject.GetComponent<Enemy2>().life -= 1;
                FindObjectOfType<AudioManager>().Play("Degat");
                FindObjectOfType<AudioManager>().Play("ExplosionMin");
                score.SetScore((score.GetScore() + 40).ToString());
            }
            if(collision.gameObject.GetComponent<Enemy3>() && collision.gameObject.GetComponent<Enemy3>().life == 0){
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Explosion");
                score.SetScore((score.GetScore() + 70).ToString());
            }
            if(collision.gameObject.GetComponent<Enemy3>() && collision.gameObject.GetComponent<Enemy3>().life > 0){
                collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
                collision.gameObject.GetComponent<Enemy3>().life -= 1;
                FindObjectOfType<AudioManager>().Play("Degat");
                FindObjectOfType<AudioManager>().Play("ExplosionMin");
                score.SetScore((score.GetScore() + 20).ToString());
            }
            if(collision.gameObject.GetComponent<LaunchMissiles>() && collision.gameObject.GetComponent<LaunchMissiles>().life == 0){
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Explosion");
                score.SetScore((score.GetScore() + 250).ToString());
            }
            if(collision.gameObject.GetComponent<LaunchMissiles>() && collision.gameObject.GetComponent<LaunchMissiles>().life > 0){
                collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
                collision.gameObject.GetComponent<LaunchMissiles>().life -= 1;
                FindObjectOfType<AudioManager>().Play("Degat");
                FindObjectOfType<AudioManager>().Play("ExplosionMin");
                score.SetScore((score.GetScore() + 25).ToString());
            }
            if(collision.gameObject.GetComponent<AutoguidedMissile>()){
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        gameObject.transform.position += firebulletdirection;
    }
}
