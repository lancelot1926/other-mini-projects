﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponenet;
    private int superJumpsRemaining;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponenet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
            
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    //FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        rigidBodyComponenet.velocity = new Vector3(horizontalInput, rigidBodyComponenet.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f,playerMask).Length == 0)
        {
            return;
        }
        
        
        if (jumpKeyWasPressed)
        {
            float jumpPower = 8f;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidBodyComponenet.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }

}
