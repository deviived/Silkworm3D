using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMissiles : MonoBehaviour
{
    [SerializeField] GameObject m_Missile;
    [SerializeField] Transform spawner;
    public float life = 3;
    [SerializeField] float interval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Launch());
    }

    private IEnumerator Launch(){
        InvokeRepeating("SpawnMissile", 2f, interval);
        yield return null;
    }

    private void SpawnMissile(){
        GameObject missileGO = Instantiate(m_Missile, spawner.position, Quaternion.identity, null);
    }

    private void OnTriggerEnter(Collider collider){
        Life life = FindObjectOfType<Life>();
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerScript>().TakeDamage();
            Destroy(gameObject);
        }
    }

}
