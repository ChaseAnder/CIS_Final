// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 10f; // Damage dealt to the player.
    private bool isInPlayerCollider = false; // Track if the enemy is inside the player's collider.

    // Update is called once per frame
    void Update()
    {
        // If the enemy is inside the player's collider, deal damage.
        if (isInPlayerCollider)
        {
            DealDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player.
        if (other.CompareTag("Player"))
        {
            isInPlayerCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When the enemy leaves the player's collider, stop dealing damage.
        if (other.CompareTag("Player"))
        {
            isInPlayerCollider = false;
        }
    }

    private void DealDamage()
    {
        // Access the player's health system and apply damage.
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }

    public float knockbackForce = 5f; // The force of the knockback.
    public float knockbackDuration = 0.2f; // How long the knockback lasts.

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collided with the player.
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Calculate the knockback direction (away from the enemy).
                Vector3 knockbackDirection = (collision.gameObject.transform.position - transform.position).normalized;

                // Apply knockback force to the player's Rigidbody.
                playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}