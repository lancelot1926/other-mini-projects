using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public GameObject DamageBurst;
    public int DamageToGive;
    public Transform HitPoint;
    public GameObject DamageNumber;


    private PlayerStats PS;
    private int currentDamage;


    // Start is called before the first frame update
    void Start()
    {
        PS = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDamage = PS.CurrentAttack;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(DamageBurst, HitPoint.position, HitPoint.rotation);
            var clone = (GameObject) Instantiate(DamageNumber, HitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().DamageNumber = currentDamage;
            
        }
    }
}
