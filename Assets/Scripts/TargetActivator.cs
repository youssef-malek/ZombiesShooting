using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetActivator : Triggerable
{
    public bool deactivatedOnAwake = true;


    void OnAwake()
    {
        if (deactivatedOnAwake)
        {
            gameObject.SetActive(false);
        }
    }
    public override void Trigger(TriggerAction action)
    {

        if (action == TriggerAction.Activate)
        {
            gameObject.SetActive(true);
        }
        else if (action == TriggerAction.Deactivate)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
