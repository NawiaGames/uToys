using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _transformFollow;
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _transformFollow.position, _speed * Time.deltaTime);
    }
}
