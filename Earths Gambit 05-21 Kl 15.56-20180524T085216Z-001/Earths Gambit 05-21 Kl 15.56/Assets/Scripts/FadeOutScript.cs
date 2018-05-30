using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutScript : MonoBehaviour {

    SpriteRenderer sprRender1;

	// Use this for initialization
	void Start () {
        sprRender1 = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        sprRender1.color -= new Color(0, 0, 0, Time.deltaTime);
	}
}
