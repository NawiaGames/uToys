using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class FollowerVan : MonoBehaviour
{
 /*   [SerializeField] private Transform _transformFollower;
    [SerializeField] private float _speedRotation = 5f;
    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private float _distanceFollower = 1f;

    private float _sphereRadius = 0.1f;

    private void Start()
    {
        StartCoroutine(StartPostion()); 
    }

    private void Update()
    {
        if (Vector3.Distance(_transformFollower.position, transform.position) > _distanceFollower)
            MoveVan();
    }

    private IEnumerator StartPostion()
    {
        yield return new WaitForEndOfFrame();
        transform.position = _transformFollower.position;
    }

    private void MoveVan()
    {
        var direction = _transformFollower.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction),
            _speedRotation * Time.deltaTime);
        transform.Translate(Vector3.forward * _speedMove * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_transformFollower.position, _sphereRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _sphereRadius);
    }*/
}