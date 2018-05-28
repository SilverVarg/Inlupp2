using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float velocityX = 5.0f;
    public float velocityY = 0;
    Rigidbody2D rb;
    public float dmg;

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, GetComponent<Rigidbody2D>().velocity.y);
        //rb.velocity = new Vector2(velocityX, velocityY);
        
    }
    private void OnCollisionEnter2D(Collision2D collision) //bullet dies on contact with wall
    {
        if (collision.gameObject.tag == "Bouncer")
        {
            velocityX = -10.0f;
            velocityY = 0f;
            gameObject.layer = 12;

            if (collision.gameObject.GetComponent<Collider>() != null)
            {
                transform.position = Vector3.Reflect(collision.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position), Vector3.right);
               // collision.gameObject.layer = 12;
                gameObject.AddComponent<PolygonCollider2D>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<NewBehaviourScript>().Harm(dmg);
            Destroy(gameObject);

        }


    }
    private void OnTriggerEnter2D(Collider2D other) //bullet dies on contact with wall
    {
        //if(collision.gameObject.tag == "wall")
        Destroy(gameObject);
    }
}
