using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{

    public string PointName;
    
    private PlayerController2 thePlayer;
    private CameraController theCamera;


    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController2>();
        theCamera = FindObjectOfType<CameraController>();

        if (thePlayer.StartPoint == PointName)
        {
            
            thePlayer.transform.position = transform.position;

            
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
