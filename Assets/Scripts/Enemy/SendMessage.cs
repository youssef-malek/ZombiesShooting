using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessage : MonoBehaviour
{
    void OncollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {

            other.transform.SendMessage("ApplyDamage", 1);
        }
    }
}
