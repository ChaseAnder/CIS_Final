// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform.
    public float followDistance = 10f; // Maximum distance at which the enemy follows the player.
    public float moveSpeed = 3f; // Speed at which the enemy moves.
    public float rotationSpeed = 5f; // Speed at which the enemy rotates.

    private void Update()
    {
        if (player == null) return;

        // Calculate the distance between the enemy and the player.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Follow the player only if within the specified distance.
        if (distanceToPlayer <= followDistance)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        // Calculate the direction to the player.
        Vector3 direction = (player.position - transform.position).normalized;

        // Rotate towards the player smoothly.
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move forward in the direction the enemy is facing.
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
