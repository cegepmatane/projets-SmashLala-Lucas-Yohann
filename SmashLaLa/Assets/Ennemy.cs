using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{
    public Animator animator;



    public Slider slider;
   public int maxHealth = 100;
  public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
       slider.maxValue = maxHealth;
       slider.value = currentHealth;
    }

   void Update()
    {
        slider.value = currentHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject, 1);
           
        }

    }
        void Die()
        {

             animator.SetBool("mort", true);
            
       
        }
}


