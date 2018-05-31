using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBoss : MonoBehaviour {
    public float delta = 3.0f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    public float moveSpeed = -0.09f;
    private Vector3 startPos;
    private Vector3 v;
    public float dmg;
    private bool Roar = false;
    
    void Start()
    {
        v = transform.position;
        
    }

    void Update()
    {


        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        v.y -= delta * Mathf.Sin(Time.time * speed);
        transform.position += Vector3.left * Time.deltaTime * 1.2f;

        if(delta > 0 && Roar == false)
        {
            AudioSource d = GetComponent<AudioSource>();
            d.Play();
            Roar = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<NewBehaviourScript>().Harm(dmg);

        }
    }

    public void Blink()
    {
        StartCoroutine(HurtColor());
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
