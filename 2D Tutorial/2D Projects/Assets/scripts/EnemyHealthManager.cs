using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;
    public int ExpToGive;

    private PlayerStats thePlayerStats;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
            thePlayerStats.AddExp(ExpToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        EnemyCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }
}
