using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barf : MonoBehaviour {
    public float barf = 0;
    private float go;
    private float stop = 0;
    public GameObject hazards;
    public Transform SpawnLocation1;
   
    public float spawnWait;
   
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (go == 5)
        {
            Debug.Log("start barf");
            stop = 1;
            StartCoroutine(SpawnWaves());
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hi bart");
        if (collision.gameObject.tag == "bullet" && stop == 0)
        {
            Debug.Log("hi bullet");
            barf++;
            go = Random.Range(0, 10);
        }
    }
    IEnumerator SpawnWaves()
    {
        if (barf > 6)
        {
            barf = 6;
        }
            for (int i = 0; i < barf; i++)
            {
                // Reallocation = Array[Random.Range(0, 10)];

               
                
                        
           


                Vector3 spawnPosition = new Vector3(SpawnLocation1.transform.position.x, SpawnLocation1.transform.position.y
                , SpawnLocation1.transform.position.z);
                Quaternion spawnRotation = Quaternion.Euler(0,0,Random.Range(64,118));
                AlienShipBullet enemyScript = hazards.GetComponent<AlienShipBullet>();
                enemyScript.velocityX = Random.Range(10, 20);
            enemyScript.velocityY = Random.Range(-5, 5);
            Instantiate(hazards, spawnPosition, spawnRotation);
                
                yield return new WaitForSeconds(spawnWait);
                
            }
        stop = 0;
        barf = 0;
           
        }
    
}
