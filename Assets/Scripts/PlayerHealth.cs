using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int currentHealth;
    public int maxHealth;

    public float invincLength = 1f;
    public float invincCounter;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
        DamagePlayer(1);
    }

    public void DamagePlayer(int damageAmount)
    {
        if(invincCounter < 0)
        {
            currentHealth -= damageAmount;

            invincCounter = invincLength;

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);

                Instantiate(deathEffect, transform.position, transform.rotation);
            }
        }   
    }
}
