using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Trigger))]
[RequireComponent(typeof(MeshRenderer))]
public class Switch : MonoBehaviour
{

    public Material activeMaterial;
    public Material inactiveMaterial;

    private Trigger _trigger;
    private MeshRenderer _meshRenderer;

    private bool _pressed = false;
    private void Awake()
    {
        _trigger = GetComponent<Trigger>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _meshRenderer.sharedMaterial = activeMaterial;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (!_pressed && other.gameObject.CompareTag("Player"))
        {
            _trigger.TriggerTargets();
            _meshRenderer.sharedMaterial = inactiveMaterial;
            _pressed = true;
        }
    }

}
