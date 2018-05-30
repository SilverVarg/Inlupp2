using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTestEnemyShip : MonoBehaviour
{
    private int hp;
    public int hpreal;
    public int scoreValue;
    private CanvasController canvasController;
    public GameObject explosionAlienship, alienshipGun, alienshipNose, alienshipWing;
    private bool Key = false;
    public float dmg = 10;
    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("CanvasController");
        if (gameControllerObject != null)
        {
            canvasController = gameControllerObject.GetComponent<CanvasController>();
        }
        if (canvasController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        hp = hpreal;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if (Key == false)
            {
                canvasController.addScore(scoreValue);
            }
            Key = true;
            BouncyEnemy enemyScript = GetComponent<BouncyEnemy>();
            enemyScript.Fall += -0.005f;
            enemyScript.rotationSpeed = 40;
            enemyScript.moveSpeed -= 0.0005f;
      //      enemyScript.moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
            enemyScript.delta = 0f;
            enemyScript.speed = 0f;

        }
    }
    private void OnTriggerEnter2D(Collider2D other) //enemy dies on contact with bullet
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= 1;


        }
        else if (other.gameObject.tag == "Backwall")
        {
            
            Explode();

        }
        else if (other.gameObject.tag == "Bomb")
        {
            hp -= 5;

        }
        else if (other.gameObject.tag == "turret")
        {
            Explode();

        }
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<NewBehaviourScript>().Harm(dmg);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Backwall" )
        {
            
                Debug.Log("hit Collider");
                Explode();
            

        }
        if (other.gameObject.tag == "bullet")
        {
            hp -= 1;


        }if (other.gameObject.tag == "turret")
        {
            Explode();
        }
        if  (other.gameObject.tag == "Player") {
            GameObject Player = GameObject.FindWithTag("Player");
            if (Player != null)
            {
                Player.GetComponent<NewBehaviourScript>().Harm(dmg);
            }
            Explode();
            
             //   other.GetComponent<NewBehaviourScript>().Harm(dmg);

       }
            else
        {
          //  Explode();
        }
    }
    public void Explode()
    {

      
        Instantiate(explosionAlienship, transform.position, Quaternion.identity);
        Instantiate(alienshipGun, transform.position, Quaternion.identity);
        Instantiate(alienshipNose, transform.position, Quaternion.identity);
        Instantiate(alienshipWing, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}

