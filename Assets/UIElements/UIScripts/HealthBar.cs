using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected PlayerStats playerStats;
    [SerializeField] protected Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = playerStats._playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerStats._playerHealth;
    }
}
