using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCamera : MonoBehaviour {
    public float velocityX = 1.2f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * Time.deltaTime * velocityX;
        if(transform.position.x == -7.79f)
        {
            velocityX = 0f;
        }
    }
}
