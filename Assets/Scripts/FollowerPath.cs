using System;
using UnityEngine;
using PathCreation;

public class FollowerPath : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private FollowerVan[] _followerVans;
    [SerializeField] private float _speedVan = 5f;
    [SerializeField] private Vector3 _offsetIocomotive = Vector3.zero; 
    private float _distanceTravelled;
    private bool _isEndPath;


    private void Start()
    {
        foreach (var van in _followerVans)
        {
            van.transform.position =  _pathCreator.path.GetPointAtDistance(0, EndOfPathInstruction.Stop);
            van.transform.rotation = _pathCreator.path.GetRotationAtDistance(0, EndOfPathInstruction.Stop);
        }
    }

    private void Update()
    {
        if (!_isEndPath)
            MoveVans();
    }

    private void MoveVans()
    {
        var previousPosition = transform.position;
        var previousRotation = transform.rotation;
        previousPosition += _offsetIocomotive; 
        
        foreach (var van in _followerVans)
        {
            var vanTransform = van.transform;
            var tempRotation = vanTransform.rotation;
            var tempPosition = vanTransform.position;
            van.transform.rotation =
                Quaternion.Lerp(vanTransform.rotation, previousRotation, _speedVan * Time.deltaTime);
            van.transform.position = Vector3.Lerp(vanTransform.position, previousPosition, _speedVan * Time.deltaTime);

            previousPosition = tempPosition;
            previousRotation = tempRotation;
        }

        MoveHeadPath();
    }

    private void MoveHeadPath()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        var nextPosition = _pathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
        
        if (transform.position == nextPosition)
            _isEndPath = true;
        
        transform.position = nextPosition;
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
    }
}