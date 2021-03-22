using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ennemy : MonoBehaviour
{
    public Animator animator;
    public static Ennemy instance;



    public Slider slider;

    public int maxHealth = 100;
    public int currentHealth;

    public bool jeMeurt = false;

    public void Awake()
    {

        DontDestroyOnLoad(this);
        instance = this;

    }

    void Start()
    {
        StartVie();
    }

   void Update()
    {
        slider.value = currentHealth;
    }

    public void StartVie()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;



        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject, 1);
            jeMeurt = true;
            

        }
        

    }
    public void Die()
    {

        animator.SetBool("mort", true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}


