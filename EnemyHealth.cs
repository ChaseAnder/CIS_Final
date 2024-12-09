// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health Settings")]
    public float health = 50f;  // The enemy's health
    public float deathDelay = 2f; // Time before enemy is destroyed after death
    private float currentHealth;

    void Start()
    {
        currentHealth = health;
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        health -= damage; // Reduce health by damage amount
        Debug.Log("Enemy Health: " + currentHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle enemy's death
    void Die()
    {
        // Here you can play an animation or sound before the enemy is destroyed
        Debug.Log("Enemy has died!");

        // Destroy the enemy after a delay to allow for death animations or effects
        Destroy(gameObject, deathDelay);
    }
}