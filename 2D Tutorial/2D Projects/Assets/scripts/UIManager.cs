using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Slider HealthBar;
    public Text HPText;
    public PlayerHealthManager PlayerHealth;
    public Text LevelText;

    private PlayerStats thePS;
    private static bool uIExists;


    // Start is called before the first frame update
    void Start()
    {
        if (!uIExists)
        {
            uIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.maxValue = PlayerHealth.PlayerMaxHealth;
        HealthBar.value = PlayerHealth.PlayerCurrentHealth;
        HPText.text = "HP: " + PlayerHealth.PlayerCurrentHealth + "/" + PlayerHealth.PlayerMaxHealth;
        LevelText.text = "Lvl:" + thePS.CurrentLevel;
    }
}
