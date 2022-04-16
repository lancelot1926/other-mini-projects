using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    // Start is called before the first frame update
    public string LevelToLoad;
    public string ExitPoint;

    private PlayerController2 thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(LevelToLoad);
            thePlayer.StartPoint = ExitPoint;
        }
    }
}
