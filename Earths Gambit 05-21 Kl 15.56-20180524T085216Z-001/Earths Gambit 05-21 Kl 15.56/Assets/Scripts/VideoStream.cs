using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using UnityEngine.Video;
public class VideoStream : MonoBehaviour {
    public Image Rawimage;
    public GameObject RawImage;
    public VideoSource videoSource;
    public AudioSource audioSource;
    public VideoPlayer VideoPlayer;

    // Use this for initialization
    void Start () {
        Application.runInBackground = true;
       // StartCoroutine(playVideo);
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
