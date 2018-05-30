﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpTestTentacle : MonoBehaviour {


    private int hp;
    public int hpreal;
    public int scoreValue;
    private CanvasController canvasController;
    public float dmg;


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
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //enemy dies on contact with bullet
    {

        if (other.gameObject.tag == "bullet")
        {
            hp -= 1;
            StartCoroutine(HurtColor());

        }
        else if (other.gameObject.tag == "Backwall")
        {
            hp -= 100;
            if (hp <= 0)
                Destroy(gameObject);
            StartCoroutine(HurtColor());

        }
        else if (other.gameObject.tag == "Bomb")
        {
            hp -= 10;
            StartCoroutine(HurtColor());
        }
        else if (other.gameObject.tag == "Laser")
        {
                Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Laser"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator HurtColor()
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

