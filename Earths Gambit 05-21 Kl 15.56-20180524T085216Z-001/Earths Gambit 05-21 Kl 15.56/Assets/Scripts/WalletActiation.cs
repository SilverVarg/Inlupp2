﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletActiation : MonoBehaviour {
    public GameObject Canvas;
    public float Goal;
    GameControllerWallet2 script;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CanvasController enemyScript = Canvas.GetComponent<CanvasController>();
       if(enemyScript.getScore() > Goal)
        {
            Debug.Log("REACHED IT");
            script = GetComponentInChildren<GameControllerWallet2>();
            script.enabled = true;
        }
    }
}
