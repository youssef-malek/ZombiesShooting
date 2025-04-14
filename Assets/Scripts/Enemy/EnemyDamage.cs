using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int hitNumber;

    private void OnEnable()
    {
        hitNumber = 0;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.transform.CompareTag("bullet"))
        {
            //If the comparison is true, we increase the hit number.
            hitNumber++;
        }
        if (hitNumber == 3)
        {
            gameObject.SetActive(false);
        }
    }
}
