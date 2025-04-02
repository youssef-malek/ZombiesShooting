using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public TriggerAction action = TriggerAction.Activate;

    public Triggerable[] targets;



    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            TriggerTargets();
        }
    }

    void TriggerTargets()
    {

        foreach (Triggerable t in targets)
        {
            if (t != null)
            {

                t.Trigger(action);
            }
        }
    }
}
