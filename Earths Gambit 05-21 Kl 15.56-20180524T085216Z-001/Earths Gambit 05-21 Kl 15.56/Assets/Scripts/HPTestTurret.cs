using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTestTurret : MonoBehaviour
{
    private int hp;
    public int hpreal;
    public int scoreValue;
    private CanvasController canvasController;
    public GameObject TurretExplosion, turretBody, turretBrains, turretGun, turretLeg, turretNub;
    public float dmg;
    public int ExtraScore = 30;

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
            canvasController.addScore(scoreValue);
            Debug.Log("bullet hit");
            Instantiate(TurretExplosion, transform.position, Quaternion.identity);
            Instantiate(turretBody, transform.position, Quaternion.identity);
            Instantiate(turretBrains, transform.position, Quaternion.identity);
            Instantiate(turretGun, transform.position, Quaternion.identity);
            Instantiate(turretLeg, transform.position, Quaternion.identity);
            Instantiate(turretNub, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //enemy dies on contact with bullet
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= 1;
            StartCoroutine("HurtColor");


        }
        
        else if (other.gameObject.tag == "Bomb")
        {
            hp -= 5;
            StartCoroutine("HurtColor");

        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<NewBehaviourScript>().Harm(dmg);

        }else if(other.gameObject.tag == "EnemyShips")
        {
            Debug.Log("Collider enter turret");
            Explode();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collider enter turret");
        if (other.gameObject.tag == "EnemyShips")
        {
            Explode();
        }
    }
   public void Explode()
    {
        canvasController.addScore(ExtraScore);
        Debug.Log("bullet hit");
        Instantiate(TurretExplosion, transform.position, Quaternion.identity);
        Instantiate(turretBody, transform.position, Quaternion.identity);
        Instantiate(turretBrains, transform.position, Quaternion.identity);
        Instantiate(turretGun, transform.position, Quaternion.identity);
        Instantiate(turretLeg, transform.position, Quaternion.identity);
        Instantiate(turretNub, transform.position, Quaternion.identity);
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

