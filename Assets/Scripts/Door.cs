using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Door : Triggerable
{

    public float moveSpeed = 5f;
    public Vector3 moveOffset;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _targetPosition;

    private Coroutine _update;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;

        Vector3 offsetLocal = transform.TransformVector(moveOffset);
        _startPosition = transform.position;
        _endPosition = _startPosition + offsetLocal;
    }
    public override void Trigger(TriggerAction action)
    {
        if (action == TriggerAction.Toggle)
        {
            if (_targetPosition == _endPosition)
            {
                _targetPosition = _startPosition;
            }
            else
            {
                _targetPosition = _endPosition;
            }
        }
        else
        {
            if (action == TriggerAction.Deactivate)
            {
                _targetPosition = _startPosition;
            }
            else
            {
                _targetPosition = _endPosition;
            }
        }

        if (_update != null)
        {
            StopCoroutine(_update);
            _update = null;
        }
        _update = StartCoroutine(MoveToTarget());
    }
    IEnumerator MoveToTarget()
    {
        while (true)
        {
            Vector3 offset = _targetPosition - transform.position;
            float distance = offset.magnitude;
            float moveDistance = moveSpeed * Time.deltaTime;

            if (moveDistance < distance)
            {
                Vector3 move = offset.normalized * moveDistance;
                _rigidbody.MovePosition(transform.position + move);
                yield return null;
            }
            else
            {
                break;
            }

        }
        _rigidbody.MovePosition(_targetPosition);
        _update = null;
    }



}
