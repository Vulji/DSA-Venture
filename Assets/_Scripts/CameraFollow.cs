using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour, IFollowTarget
{
    [SerializeField] private Transform _target;
    private float _offset = 3.5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    public void UpdatePosition(Vector3 targetPosition)
    {
        Vector3 position = _transform.position;
        position.z = targetPosition.z - _offset;
        _transform.position = position;
    }

    private void LateUpdate()
    {
        UpdatePosition(_target.position);
    }
}
