using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hptestboss : MonoBehaviour {

    private int hp;
    public int hpreal;
    public int scoreValue;
    private CanvasController canvasController;
    public float dmg;
    public Transform Tentaclelocation, TentaclelocationRoof;
    public GameObject TentacleAttackPhase2, TentacleAttackRoofPhase2, TentacleAttackGroundPhase3, TentacleAttackRoofPhase3, TentacleAttackGroundPhase4, TentacleAttackRoofPhase4, Boss,
        Boss_Explosion, Boss_eye, Boss_sporethingy01, Boss_Tentical01, Boss_Tentical02, Boss_Tentical03, Boss_Tentical04, Boss_tooth01, Boss_tooth02, Boss_tooth03,
        Boss_tooth04, Boss_tooth05, Boss_tooth06, Boss_tooth07, Boss_tooth08, Boss_tooth09, Boss_tooth10, Boss_tooth11, Boss_tooth12, Boss_upperjaw;
    private bool UnlockComplete = false;
    private bool UnlockComplete2 = false;
    private bool UnlockComplete3 = false;
    public float StartPhase2WhenHp, StartPhase3WhenHp, StartPhase4WhenHp;
    GameControllerLaser script;
    public Sprite newSprite, originalSprite;
    private bool Destroyed = false;

    // Use this for initialization
    void Start()
    {
        hp = hpreal;
        Debug.Log("hp = " + hp);
        GameObject gameControllerObject = GameObject.FindWithTag("CanvasController");
        if (gameControllerObject != null)
        {
            canvasController = gameControllerObject.GetComponent<CanvasController>();
        }
        if (canvasController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
       

    }

    // Update is called once per frame
    void Update()
    {

        
        if (hp < 0 && Destroyed == false)
        {
            Debug.Log("Boss Destroyed");
            canvasController.addScore(scoreValue);
            Debug.Log("bullet hit");
            GameObject Boss = GameObject.FindGameObjectWithTag("Boss");
            Instantiate(Boss_Explosion, transform.position, Quaternion.identity);
            Instantiate(Boss_eye, transform.position, Quaternion.identity);
            Instantiate(Boss_sporethingy01, transform.position, Quaternion.identity);
            Instantiate(Boss_Tentical01, transform.position, Quaternion.identity);
            Instantiate(Boss_Tentical02, transform.position, Quaternion.identity);
            Instantiate(Boss_Tentical03, transform.position, Quaternion.identity);
            Instantiate(Boss_Tentical04, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth01, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth02, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth03, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth04, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth05, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth06, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth07, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth08, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth09, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth10, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth11, transform.position, Quaternion.identity);
            Instantiate(Boss_tooth12, transform.position, Quaternion.identity);
            Instantiate(Boss_upperjaw, transform.position, Quaternion.identity);
            Destroy(Boss);
            Destroy(GameObject.Find("GameController Tentacle Ground Phase 4(Clone)"));
            Destroy(GameObject.Find("Tentacle Gamecontroller Roof Phase 4(Clone)"));
            Debug.Log("Boss Destroyed Set true");

        }
    
        else if (hp == StartPhase2WhenHp)
        {
            if (UnlockComplete == false)
            {
                Phase2();
                UnlockComplete = true;
            }
            
        }else if(hp == StartPhase3WhenHp)
        {
            if (UnlockComplete2 == false)
            {
                Phase3();
                UnlockComplete2 = true;
            }
        }
        else if (hp == StartPhase4WhenHp)
        {
            if (UnlockComplete3 == false)
            {
                Phase4();
                UnlockComplete3 = true;
            }
        }

        
    }
    private void OnCollisionEnter2D(Collision2D other) //enemy dies on contact with bullet
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= 1;
            StartCoroutine("EyeMad");
            StartCoroutine("HurtColor");
            Boss.GetComponent<BouncyBoss>().Blink();
            GetComponent<SpriteRenderer>().sprite = newSprite;
            Debug.Log("minus hp" + hp);

        }

        else if (other.gameObject.tag == "Bomb")
        {
            hp -= 5;
            StartCoroutine("HurtColor");
            Boss.GetComponent<BouncyBoss>().Blink();
        }
        else if (other.gameObject.tag == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            Player.GetComponent<NewBehaviourScript>().Harm(dmg);

        }
    }
    private void OnTriggerEnter2D(Collider2D other) //enemy dies on contact with bullet
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= 1;

            Debug.Log("minus hp Trigger");

        }

        else if (other.gameObject.tag == "Bomb")
        {
            hp -= 5;
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<NewBehaviourScript>().Harm(dmg);

        }
    }
    void Phase2()
    {
        Instantiate(TentacleAttackPhase2, Tentaclelocation.transform.position, Tentaclelocation.transform.rotation);
        Instantiate(TentacleAttackRoofPhase2, TentaclelocationRoof.transform.position, TentaclelocationRoof.transform.rotation);
        script = GetComponent<GameControllerLaser>();
        script.enabled = true;
    }
    void Phase3()
    {
        Destroy(GameObject.Find("Tentacle GameController ground Phase 2(Clone)"));
        Destroy(GameObject.Find("Tentacle Gamecontroller Roof Phase 2(Clone)"));
        Instantiate(TentacleAttackGroundPhase3, Tentaclelocation.transform.position, Tentaclelocation.transform.rotation);
        Instantiate(TentacleAttackRoofPhase3, TentaclelocationRoof.transform.position, TentaclelocationRoof.transform.rotation);
    }
    void Phase4()
    {
        Destroy(GameObject.Find("Tentacle GameController ground Phase 3(Clone)"));
        Destroy(GameObject.Find("Tentacle Gamecontroller Roof Phase 3(Clone)"));
        Instantiate(TentacleAttackGroundPhase4, Tentaclelocation.transform.position, Tentaclelocation.transform.rotation);
        Instantiate(TentacleAttackRoofPhase4, TentaclelocationRoof.transform.position, TentaclelocationRoof.transform.rotation);
    }

  
    IEnumerator EyeMad()
    {

        GetComponent<SpriteRenderer>().sprite = newSprite;
            yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().sprite = originalSprite;
           
    }
    public void StartTHatShiet()
    {
        if (Destroyed == false)
        {
            StartCoroutine("loadCredits");
            Destroyed = true;
            Debug.Log("HIII");
        }
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
    IEnumerator loadCredits()
    {
        Debug.Log("Time Iniated");
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Credits Played");
        SceneManager.LoadScene("Credits");


    }


}