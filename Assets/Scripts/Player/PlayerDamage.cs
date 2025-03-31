using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDamage : MonoBehaviour
{
    public TextMeshProUGUI healthPanel;
    public int health = 100;


    void Start()
    {
        ApplyDamage(0);
    }

    void ApplyDamage(int damage)
    {


        if (healthPanel != null && health > 0)
        {
            health = health - damage;

            healthPanel.text = health.ToString();
        }
    }
}
