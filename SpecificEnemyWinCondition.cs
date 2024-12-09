// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossDefeat : MonoBehaviour
{
    [Header("Final Boss Settings")]
    public int bossHealth = 100; // Set the health of the final boss

    [Header("Scene Transition Settings")]
    public string winSceneName = "WinScene"; // Name of the win scene
    public float delayBeforeTransition = 1.0f; // Delay before transitioning

    private bool bossDefeated = false; // Track if the boss has been defeated

    void Update()
    {
        // Check if the boss's health is 0 or below and if not already defeated
        if (bossHealth <= 0)
        {
            bossDefeated = true; // Mark boss as defeated to prevent multiple triggers
            StartCoroutine(TransitionToWinScene());
        }
    }

    // Function to apply damage to the boss
    public void TakeDamage(int damage)
    {
        bossHealth -= damage;
        if (bossHealth < 0)
            bossHealth = 0; // Ensure health doesn't go negative
    }

    // Coroutine to handle the delay and transition to the win scene
    private IEnumerator TransitionToWinScene()
    {
        Debug.Log("Boss defeated! Transitioning to WinScene...");
        yield return new WaitForSeconds(delayBeforeTransition);
        SceneManager.LoadScene(winSceneName);
    }
}
