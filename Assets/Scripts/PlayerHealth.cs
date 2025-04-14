using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour
{


    public TextMeshProUGUI healthText;
    public int health = 100;
    public Image damageFX;

    public bool isActive;
    //private float maxAlpha = 0.7f;

    public AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame


    void ApplyDamage(int damage)
    {
        health -= damage;
        UpdateText();
        if (!isActive && damageFX != null)
        {
            StartCoroutine(SetEffect());
        }

    }

    void UpdateText()
    {
        health = Mathf.Clamp(health, 0, 100);
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }

    void ApplyHeal(int heal)
    {
        health = health + heal;
        UpdateText();
    }

    private IEnumerator SetEffect()
    {
        isActive = true;
        float alpha = damageFX.color.a;
        Color color = damageFX.color;

        damageFX.color = new Color(color.r, color.g, color.b, alpha);

        if (audioClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

        yield return new WaitForSeconds(0.2f);
        damageFX.color = new Color(color.r, color.g, color.b, 0);
        yield return new WaitForSeconds(0.4f);

        isActive = false;

        yield return null;
    }
}
