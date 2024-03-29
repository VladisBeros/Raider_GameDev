using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    public GameObject slime;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Slime is dead!");

        animator.SetBool("IsDead", true);

        Destroy(slime);
        /*
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        */
    }
}