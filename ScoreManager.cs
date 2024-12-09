// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Use this for TextMeshPro, or UnityEngine.UI for standard Text

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText; // Drag your TextMeshPro object here in the Inspector

    private int currentScore = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Coins: {currentScore}";
    }
}
