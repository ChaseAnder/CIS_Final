// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator; // Reference to the Animator controlling the sword.
    public float damageAmount = 25f;  // The amount of damage dealt to the enemy.

    void Update()
    {
        // Check if the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0)) // 0 = Left mouse button
        {
            PlaySwordSwingAnimation();
        }
    }

    private void PlaySwordSwingAnimation()
    {
        if (animator != null)
        {
            // Trigger the "SwingSword" animation.
            animator.SetTrigger("SwingSword");
        }
        else
        {
            Debug.LogWarning("Animator is not assigned to the PlayerCombat script!");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that the BoxCollider hits is tagged as "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component from the enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // If the enemy has the EnemyHealth component, apply damage
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }
}

