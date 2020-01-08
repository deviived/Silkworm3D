using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject PlaneUp;
    [SerializeField] GameObject PlaneDown;
    [SerializeField] GameObject PlaneRandom;
    [SerializeField] GameObject CannonLauncher;
    int numberOfEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        //yield return new WaitForSeconds(0.2f);
        // Debug.Log("DDDgameObject name : " + gameObject.name);
        //InvokeRepeating("LevelOne", 3f, 13f);
       // LaunchCoroutine();
        StartCoroutine(LevelOne());
        //yield return null;
    }

    // private void LaunchCoroutine()
    // {
    //     StartCoroutine(FirstWave());
    // }

    private IEnumerator LevelOne(){
        // StartCoroutine(FourthWave());
        // yield return new WaitForSeconds(9f);
        StartCoroutine(FirstWave());
        yield return new WaitForSeconds(5f);
        StartCoroutine(SecondWave());
        yield return new WaitForSeconds(6f);
        StartCoroutine(ThirdWave());
        yield return new WaitForSeconds(8f);
        StartCoroutine(FourthWave());
        yield return new WaitForSeconds(6f);
        StartCoroutine(ThirdWave());
        yield return new WaitForSeconds(3f);
        StartCoroutine(FourthWave());
    }

    private IEnumerator FirstWave()
    {
        if(numberOfEnemies < 5){
            for(int i = 0; i < 5; i++){
                SpawnEnemy("PlaneUp");
                yield return new WaitForSeconds(1.5f);
            }
        }
        
        numberOfEnemies = 5;
        yield return null;
    }

    private IEnumerator SecondWave()
    {
        if(numberOfEnemies < 7){
            for(int i = 0; i < 7; i++){
                SpawnEnemy("PlaneDown");
                yield return new WaitForSeconds(1.5f);
            }
        }
        
        numberOfEnemies = 5;
        yield return null;
    }

    private IEnumerator ThirdWave()
    {
        if(numberOfEnemies < 15){
            for(int i = 0; i < 10; i++){
                SpawnEnemy("PlaneRandom");
                yield return new WaitForSeconds(1f);
            }
        }
        
        numberOfEnemies = 5;
        yield return null;
    }

    private IEnumerator FourthWave()
    {
        if(numberOfEnemies < 25){
            for(int i = 0; i < 10; i++){
                switch(i){
                    case 2: 
                        SpawnEnemy("CannonLauncher");
                        break;
                    case 8: 
                        SpawnEnemy("CannonLauncher");
                        break;
                    default: 
                        SpawnEnemy("PlaneUp");
                        break;
                }
                
                yield return new WaitForSeconds(0.75f);
            }
        }
        
        numberOfEnemies = 5;
        yield return null;
    }

    private void SpawnEnemy(string enemyType){
        Transform ground = GetGroundTransform();
        if(enemyType.Equals("PlaneUp")){
            GameObject planeUpGO = Instantiate(PlaneUp, gameObject.transform.position, Quaternion.identity, null);
            StartCoroutine(EnemyLifespan(planeUpGO));
        }
        if(enemyType.Equals("PlaneDown")){
            GameObject planeDownGO = Instantiate(PlaneDown, gameObject.transform.position, Quaternion.identity, null);
            StartCoroutine(EnemyLifespan(planeDownGO));
        }
        if(enemyType.Equals("PlaneRandom")){
            GameObject planeRandomGO = Instantiate(PlaneRandom, gameObject.transform.position, Quaternion.identity, null);
            StartCoroutine(EnemyLifespan(planeRandomGO));
        }
        if(enemyType.Equals("CannonLauncher")){
            Vector3 position;
            if(ground != null){
                position = ground.position;
                position.x = gameObject.transform.position.x;
                position.z = gameObject.transform.position.z;
            }
            else position = gameObject.transform.position;
            GameObject cannonGO = Instantiate(CannonLauncher, position, Quaternion.identity, null);
            StartCoroutine(EnemyLifespan(cannonGO, 30f));
        }
    }

    private IEnumerator EnemyLifespan(GameObject GO, float duration = 6f){
        yield return new WaitForSeconds(duration);
        Destroy(GO);
        yield return null;
    }

    private Transform GetGroundTransform(){
        if(GameObject.FindWithTag("Ground") == null){
            return null;
        }
        return GameObject.FindWithTag("Ground").transform;
    }


}
