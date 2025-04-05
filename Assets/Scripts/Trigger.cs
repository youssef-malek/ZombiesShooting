using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void TriggerTargets()
    {

        foreach (Triggerable t in targets)
        {
            if (t != null)
            {

                t.Trigger(action);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawCube(transform.position, Vector3.one * 0.25f);

        if (targets != null)
        {
            foreach (Triggerable t in targets)
            {
                if (t != null)
                {
                    Gizmos.DrawLine(transform.position, t.transform.position);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.matrix = transform.worldToLocalMatrix;
        MeshFilter mf = GetComponent<MeshFilter>();

        if (mf != null)
        {
            Gizmos.DrawWireMesh(mf.sharedMesh, transform.position);
        }
    }
}
