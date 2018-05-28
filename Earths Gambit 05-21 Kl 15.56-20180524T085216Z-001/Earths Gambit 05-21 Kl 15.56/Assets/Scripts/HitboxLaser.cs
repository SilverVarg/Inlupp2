using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxLaser : MonoBehaviour {

    public float dmg;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<NewBehaviourScript>().Harm(dmg);
           

        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<NewBehaviourScript>().Harm(dmg);
           

        }



    }
}
