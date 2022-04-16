using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal")>0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime,0f,0f));

        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime, 0f));

        }


    }

    private void FixedUpdate()
    {
        
    }

}

