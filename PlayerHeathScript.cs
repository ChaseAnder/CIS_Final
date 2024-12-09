// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Player health at start
    public HealthBarScript healthBarScript; // Reference to the HealthBarScript
    private float currentHealth; // players current health as the game goes on

    void Start()
    {
        currentHealth = maxHealth;  // makes the current health set to max health
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // updates current health
        healthBarScript.UpdateHealthBar((float)currentHealth / (float)maxHealth); // uses healthBarScript reference to update the health bar
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Player Health: {currentHealth}"); // this send the players current health in the console so I could tell when the player was actually getting hit

        if (currentHealth <= 0)
        {
            Die(); // if player health is less than or equal to 0 player dies
        }
    }

    // player dies function 
    private void Die()
    {
        Debug.Log("Player is dead!"); // shows me in the console when player dies
        
    }
}

