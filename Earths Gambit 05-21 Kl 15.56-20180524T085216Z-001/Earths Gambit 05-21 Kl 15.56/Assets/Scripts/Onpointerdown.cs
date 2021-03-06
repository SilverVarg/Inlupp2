﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Onpointerdown : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject Player;
    public float fireRate;
    public float nextFire;
    bool flag = false;
    public void Update()
    {
        

        if (flag)
        {
            if (Time.time > nextFire)
            {
                
                if (Player != null)
                {
                    nextFire = Time.time + fireRate;
                    Player.GetComponent<NewBehaviourScript>().startFire();
                }
            }
            
           
        }
    }
    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
        flag = true;
    }

    //Do this when the mouse click on this selectable UI object is released.
    public void OnPointerUp(PointerEventData eventData)
    {
        flag = false;
    }
}