using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offsett;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offsett;
    }
}
