using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
    public GameObject Boss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Boss == null)
        {
            StartCoroutine("loadCredits");
        }
    }
    IEnumerator loadCredits()
    {
        Debug.Log("Time Iniated");
        yield return new WaitForSeconds(6f);
        Debug.Log("Credits Played");
        SceneManager.LoadScene("Credits");


    }
}
