using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum TriggetAction{
    Activated,
    Deactivated,
    Toggle,
}
public abstract class Triggerable : MonoBehaviour
{
   public abstract void Trigger(TriggetAction action); 
    
}
