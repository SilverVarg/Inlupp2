using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    private float addScale;
    public float MinusScale;
    public float MinusX;
    private Vector3 v;
    public float Stop;
     GameObject BossEye;
    GameObject eye;
    public float dmg;
    // Use this for initialization
    void Start () {
        v = transform.position;
        eye = GameObject.Find("Eye (Hitbox to kill), Also TentacleController");
        addScale -= MinusScale;
        transform.position = eye.transform.position;
        transform.rotation = eye.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        float Scale = transform.localScale.x;
        Scale += addScale;
        if (Scale > Stop)
        {
            Debug.Log("hi");
            Destroy(gameObject);
        }
        transform.localScale = new Vector3(Scale, transform.localScale.y, transform.localScale.z);
        v.x -= MinusX;
        transform.position = v;
        
        transform.position = new Vector3(transform.position.x, eye.transform.position.y, eye.transform.position.z);        // Quaternion.identity = transform.Rotate(0, 0, BossEye.transform.rotation.z); //rotates 50 degrees per second around z axis

       
    }
   
}
