﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour {
    public float deathTimer;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, deathTimer);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
