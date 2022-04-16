using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float MoveSpeed;
    public float TimeBetweenMove;
    public float TimeToMove;
    

    private Rigidbody2D rigBody;
    private Vector3 moveDirection;
    private bool moving;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        //timeBetweenMoveCounter = TimeBetweenMove;
        //timeToMoveCounter = TimeToMove;
        timeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(TimeToMove * 0.75f, TimeToMove * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.fixedDeltaTime;
            rigBody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = TimeBetweenMove;
                timeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.fixedDeltaTime;
            rigBody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = TimeToMove;
                timeToMoveCounter = Random.Range(TimeToMove * 0.75f, TimeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * MoveSpeed, Random.Range(-1f, 1f) * MoveSpeed, 0f);
            }
        }
        
    }

}
