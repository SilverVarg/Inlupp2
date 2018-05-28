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
            StartCoroutine("HurtColor");


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
            StartCoroutine("HurtColor");


        }
        if (other.gameObject.tag == "turret")
        {
            Explode();
        }
        else
        {
          //  Explode();
        }
    }
    public void Explode()
    {

        canvasController.addScore(scoreValue);
        Instantiate(explosionAlienship, transform.position, Quaternion.identity);
        Instantiate(alienshipGun, transform.position, Quaternion.identity);
        Instantiate(alienshipNose, transform.position, Quaternion.identity);
        Instantiate(alienshipWing, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator HurtColor()
    {
        for (int i = 0; i < 3; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 1f); //Red, Green, Blue, Alpha/Transparency
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().color = Color.white; //White is the default "color" for the sprite, if you're curious.
            yield return new WaitForSeconds(.1f);
        }
    }


}

