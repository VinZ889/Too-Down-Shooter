using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    [SerializeField] float gameHealth;
    [SerializeField] int goldPerGain = 20;

    GoldCollect goldCollect;

    //public float IntialHealth;
    //public float IntialHealth1;
    public Slider slider;

    void Start()
    {
        enemyHealth = gameHealth;
        slider.value = UpdateHealth();
        goldCollect = FindObjectOfType<GoldCollect>();
    }
        
    public void TakenDamage(float aurtherDamage)
    {
        enemyHealth -= aurtherDamage;
        GetComponent<Animator>().SetTrigger("Hit");
        slider.value = UpdateHealth();
        if (enemyHealth <= 0)
        {
            Die();
            goldCollect.GoldGain(goldPerGain);
        }
        GetComponent<Animator>().SetBool("Die", false);
    }

   
    private void Die()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<Animator>().SetBool("Die", true);
        Destroy(gameObject); //perviously was using Destroy(gameObject, 6f);
    }

    float UpdateHealth()
    {
        return enemyHealth / gameHealth;
    }
       
}
