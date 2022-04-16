using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject thePlayer;
    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;
    public float WaitToReload;
    
    public float FlashLength;

    private bool FlashActive;
    private float flashCounter;
    private bool reloading;
    private SpriteRenderer playerSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            reloading = true;
            
        }
        
        
        if (reloading)
        {
            WaitToReload -= Time.deltaTime;
            if (WaitToReload <= 0)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
                reloading = false;


            }


        }
        if (FlashActive)
        {
            if (flashCounter > FlashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }else if (flashCounter > FlashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }else{
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);

                FlashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        PlayerCurrentHealth -= damageToGive;
        FlashActive = true;
        flashCounter = FlashLength;
    }

    public void SetMaxHealth()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
    }
}
