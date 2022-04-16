using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int CurrentLevel;
    public int CurrentExp;
    public int[] ToLevelUp;
    public int[] HPLevels;
    public int[] AttackLevels;
    public int[] DefenceLevels;

    public int CurrentHP;
    public int CurrentAttack;
    public int CurrentDefence;

    private PlayerHealthManager theplayerHealth;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HPLevels[1];
        CurrentAttack = AttackLevels[1];
        CurrentDefence = DefenceLevels[1];

        theplayerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentExp >= ToLevelUp[CurrentLevel])
        {
            LevelUp();
        }
    }


    public void AddExp(int experienceToAdd)
    {
        CurrentExp += experienceToAdd;
    }

    public void LevelUp()
    {
        CurrentLevel++;
        CurrentHP = HPLevels[CurrentLevel];
        theplayerHealth.PlayerMaxHealth = CurrentHP;
        theplayerHealth.PlayerCurrentHealth += CurrentHP - HPLevels[CurrentLevel - 1];
        CurrentAttack = AttackLevels[CurrentLevel];
        CurrentDefence = DefenceLevels[CurrentLevel];
    }
}
