using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public int damageToDeal;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageToDeal);
            Instantiate(hitEffect, transform.position, transform.rotation);
        }
    }
}
