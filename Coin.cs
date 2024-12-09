// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    public int coinValue = 1; // Value of the coin

    [Header("Floating Settings")]
    public float floatAmplitude = 0.5f; // Height of the floating effect
    public float floatSpeed = 2f;       // Speed of the floating effect

    private Vector3 startPosition;

    private void Start()
    {
        // Store the starting position of the coin
        startPosition = transform.position;
    }

    private void Update()
    {
        // Apply floating effect
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        Debug.Log($"Collected a coin worth {coinValue}!");

        // Find the ScoreManager and add score
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(coinValue);
        }

        // Destroy the coin object
        Destroy(gameObject);
    }
}

