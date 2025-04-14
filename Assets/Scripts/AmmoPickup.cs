using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;
    public bool respawn;
    public float delayRespawn = 30;


    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            other.transform.BroadcastMessage("ApplyAmmo", ammoAmount);

            if (respawn)
            {
                Invoke("Respawn", delayRespawn);
            }
        }
    }

    void Respawn()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
