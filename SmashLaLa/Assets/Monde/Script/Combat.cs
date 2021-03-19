    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat instance;
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;


    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public bool jAttaque = false;


    public void Awake()
    {

        DontDestroyOnLoad(this);
        instance = this;

    }



    void Update()
    {

        jAttaqueMechant();

    }


    public void jAttaqueMechant()
    {
        Debug.Log("je suis dans jAttaqueMechant script combat");
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<Ennemy>().TakeDamage(attackDamage);
        }

        jAttaque = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
