using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 4f; 
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2d;
    bool canMove = true; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();  
    } 

    
    void Update()
    {
       if (canMove)
      {
        RotatePlayer();
        RespondToBoost();
      }

    }

    public void DisableControls()
    {
        canMove = false; 
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
      {
        surfaceEffector2d.speed = boostSpeed;
      }  
        else
      {
        surfaceEffector2d.speed = baseSpeed; 
      }
      
    }


    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}

