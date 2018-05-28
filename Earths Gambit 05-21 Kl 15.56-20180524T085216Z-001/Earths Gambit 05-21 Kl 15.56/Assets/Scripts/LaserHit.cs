using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour {
    public float dmg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<NewBehaviourScript>().Harm(dmg);

        }
        else if (collision.CompareTag("wall") || collision.CompareTag("Backwall"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Tentacle") || collision.CompareTag("SpecialTentacle"))
        {
            
            Destroy(gameObject);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tentacle") || collision.CompareTag("SpecialTentacle"))
        {

            Destroy(gameObject);
        }
        else if (collision.CompareTag("wall") || collision.CompareTag("Backwall"))
        {

            Destroy(gameObject);
        }
    }
   
}
