﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTestAsteroid : MonoBehaviour
{
    private int hp;
    public int hpreal;
    public int scoreValue;
    private CanvasController canvasController;
    public GameObject explosionAsteroid, partAsteroid4, partAsteroid5;
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
        if (hp == 0)
        {
            canvasController.addScore(scoreValue);
            Debug.Log("bullet hit");
            Instantiate(explosionAsteroid, transform.position, Quaternion.identity);
            Instantiate(partAsteroid4, transform.position, Quaternion.identity);
            Instantiate(partAsteroid5, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
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
            hp -= 100;
            if (hp <= 0)
                Destroy(gameObject);

        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<NewBehaviourScript>().Harm(dmg);
            Explode();

        }
    }

    public void Explode() {
        Instantiate(explosionAsteroid, transform.position, Quaternion.identity);
        Instantiate(partAsteroid4, transform.position, Quaternion.identity);
        Instantiate(partAsteroid5, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}

