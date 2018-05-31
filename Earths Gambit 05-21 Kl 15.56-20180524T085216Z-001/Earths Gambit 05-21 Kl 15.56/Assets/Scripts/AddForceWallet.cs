using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceWallet : MonoBehaviour {
    public Rigidbody2D rb;
    public float dirX;
    public float dirY;
    public float torque;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 5);
    }
}