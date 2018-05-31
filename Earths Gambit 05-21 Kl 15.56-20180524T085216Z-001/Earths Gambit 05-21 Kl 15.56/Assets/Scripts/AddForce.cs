﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    public Rigidbody2D rb;
    public float dirX;
    public float dirY;
    public float torque;
   

    // Use this for initialization
    void Start()
    {
        
        dirX = Random.Range(-5, 5);
        dirY = Random.Range(5, 8);
        torque = Random.Range(5, 15);
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}