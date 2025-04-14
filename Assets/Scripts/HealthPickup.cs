using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthAmount = 10;
    public bool respawn;
    public float delayRespawn = 3;


    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //respawn = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            other.transform.SendMessage("ApplyHeal", healthAmount);


            if (respawn)
            {
                Invoke(nameof(Respawn), delayRespawn);

            }
        }
    }


    void Respawn()
    {

        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;




    }
}
