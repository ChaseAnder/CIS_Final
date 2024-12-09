// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image healthBar;
    
    // function to update the health bar as the player gets hit
    public void UpdateHealthBar(float fraction)
    {
        healthBar.fillAmount = fraction;
    }
}
