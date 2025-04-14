using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseAttacks : MonoBehaviour
{
    public int ammoAmmount = 10;
    public float meleeRepeate = 0.25f;
    public GameObject projectile;
    public GameObject punchMesh;
    public TextMeshProUGUI ammoPanel;
    private bool punchActive;

    void Start()
    {
        UpdateText();
        punchMesh.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoAmmount > 0)
            {
                ammoAmmount--;
                UpdateText();
                var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(clone, 5.0f);
            }
            else
            {
                if (!punchActive)
                {
                    punchActive = true;
                    StartCoroutine(MeleeAtack());
                }
            }
        }
    }

    void ApplyAmmo(int ammo)
    {
        ammoAmmount += ammo;
        UpdateText();
    }
    IEnumerator MeleeAtack()
    {
        punchMesh.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        punchMesh.SetActive(false);
        yield return new WaitForSeconds(meleeRepeate);

        punchActive = false;
        yield return null;
    }

    private void UpdateText()
    {
        if (ammoPanel != null)
        {
            ammoPanel.text = ammoAmmount.ToString();
        }
    }
}
