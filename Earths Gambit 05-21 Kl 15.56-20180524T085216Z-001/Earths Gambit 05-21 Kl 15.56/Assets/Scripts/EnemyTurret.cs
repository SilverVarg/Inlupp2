using UnityEngine;
using System.Collections;

public class EnemyTurret : MonoBehaviour
{

    public Transform target;
    public float turretSpeed;
    //public float fireRate;
    //public float bulletHeight;
    //public GameObject bullet;
    public float range;
    float distance;
    private float _lastShotTime = float.MinValue;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate turret to look at player.
        if (target != null)
        {
            Vector3 relativePos = target.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(relativePos);
            rotation.y = 0;
            rotation.x = 0;



            // Quaternion Realrotation = Quaternion.RotateTowards(rotation, Quaternion.identity, Time.deltaTime * turretSpeed);


            transform.rotation = Quaternion.Slerp(target.transform.rotation, rotation, Time.deltaTime * turretSpeed);

        } 

            //Fire at player when in range.
        
 

        
        
   
    }

    
}

