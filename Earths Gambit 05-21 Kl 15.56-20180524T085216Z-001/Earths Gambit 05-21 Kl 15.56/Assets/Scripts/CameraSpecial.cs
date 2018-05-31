using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpecial : MonoBehaviour {
    public float velocityX = 1.2f;
    public GameObject Cam;
    public GameObject Boss;
    public GameObject TentacleSpawnloc, TentacleSpawnloc3, TentacleSpawnloc2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.right * Time.deltaTime * velocityX;
        if (Cam.transform.position.x >= -7.79f)
        {
            BouncyBoss enemyScript = Boss.GetComponent<BouncyBoss>();
            EnemyGun enemyScript2 = TentacleSpawnloc.GetComponent<EnemyGun>();

            EnemyGun enemyScript3 = TentacleSpawnloc2.GetComponent<EnemyGun>();

            EnemyGun enemyScript4 = TentacleSpawnloc3.GetComponent<EnemyGun>();
            enemyScript3.range = 100f;
            enemyScript4.range = 100f;
            enemyScript2.range = 100;
            enemyScript.delta = 2.5f;
            enemyScript.speed = 2f;
            enemyScript.moveSpeed = -0.09f;
            velocityX = 0f;
        }
    }
}
