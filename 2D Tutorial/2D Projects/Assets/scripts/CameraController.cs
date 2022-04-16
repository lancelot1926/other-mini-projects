using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject FollowTarget;
    public float MoveSpeed;


    private Vector3 targetPosition;
    private static bool camExist;

    void Start()
    {
        if (!camExist)
        {
            camExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    void Update()
    {
        targetPosition = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, MoveSpeed*Time.deltaTime);
    }
}
