using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public Vector3 v;
    // Use this for initialization
    void Start () {
}
	
	// Update is called once per frame
	void Update () {
    
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit Collideryee");
        if (other.gameObject.tag == "EnemyShips")
        {
            HPTestEnemyShip enemyScript = other.gameObject.GetComponent<HPTestEnemyShip>();
            enemyScript.Explode();
            Debug.Log("hit Collider");



        }
      
    }
}
