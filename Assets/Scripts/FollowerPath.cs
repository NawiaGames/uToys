using UnityEngine;
using PathCreation;

public class FollowerPath : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed = 5f;
    
    private float _distanceTravelled;

    private void Update()
    {
        MoveToPath();
    }

    private void MoveToPath()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }
}