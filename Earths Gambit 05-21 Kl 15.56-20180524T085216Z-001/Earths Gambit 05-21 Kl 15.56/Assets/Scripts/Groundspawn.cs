using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundspawn : MonoBehaviour {
    public GameObject Ground;
    public Transform Spawnposition, Spawnrotation;
    private Vector3 v;
    public float Move;
    private float width;
	// Use this for initialization
	void Start () {
        v = transform.position;
        width = Ground.GetComponent<SpriteRenderer>().bounds.size.x;
       
      if (Move == 1)
        {

            v.x += width * 2;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.position = v;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit Ground trigger");
        if (collision.gameObject.tag == "GroundSpawn")
        {
            Debug.Log("ITS A THIS A BIG" + width);
            
                v.x += width * 4;
            
             
            
            
          
        }
    }
}
