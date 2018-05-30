using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamecontrollerWallet : MonoBehaviour {

    public GameObject Hazards;
    public Vector3 SpawnValues;
    public int hazardCount;
    public Transform SpawnLocation1;
 
    public float spawnWaitMin;
    public float spawnWaitMax;
    public float startWait;
    public float waveWait;
    private float spawnWaitbefore;
 

    public float MinSpawnYvalue;
    public float MaxSpawnYvalue;
    Transform[] Array;
    private void Start()
    {

     

        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                // Reallocation = Array[Random.Range(0, 10)];

                MoveWallet enemyScript = Hazards.GetComponent<MoveWallet>();
                enemyScript.rotationSpeed = Random.RandomRange(50f, 100f);
                enemyScript.velocityX = Random.RandomRange(-1.5f, -3f);

                float spawnWait = Random.Range(spawnWaitMin, spawnWaitMax);
               


                Vector3 spawnPosition = new Vector3(SpawnLocation1.transform.position.x, Random.Range(MinSpawnYvalue, MaxSpawnYvalue)
                , 0f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Hazards, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                spawnWaitbefore = spawnWait;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}