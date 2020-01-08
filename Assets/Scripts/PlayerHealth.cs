using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Text healthText;

    public int playerHealth;
    public int maxPlayerHealth;

    void Start()
    {
        healthText = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
    }

    void Update()
    {
        healthText.text = playerHealth.ToString();
    }

    public void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }
}
