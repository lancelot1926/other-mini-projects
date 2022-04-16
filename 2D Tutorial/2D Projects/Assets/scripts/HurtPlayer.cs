using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int DamageToGive;
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
        currentDamage = DamageToGive - (PS.CurrentDefence * 10 / 100);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            if (currentDamage <= 0)
            {
                currentDamage = 1;
            }
            var clone = (GameObject)Instantiate(DamageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().DamageNumber = currentDamage;

        }
    }
}
