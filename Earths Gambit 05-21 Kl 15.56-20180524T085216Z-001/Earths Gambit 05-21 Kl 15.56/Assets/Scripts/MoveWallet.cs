using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallet : MonoBehaviour {

    public float velocityX = 0f;
    public float rotationSpeed = 0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        transform.position += Vector3.right * Time.deltaTime * velocityX;
    }
}
