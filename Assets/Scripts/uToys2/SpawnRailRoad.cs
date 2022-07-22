using PathCreation;
using UnityEngine;

[RequireComponent(typeof(Levelq))]
public class SpawnRailRoad : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectRail;
    [SerializeField] private float _distance = 0.05f;
    [SerializeField] private Transform _transformParentRail; 

    private Levelq _levelq;
    private float _distanceTravelled;

    private void Start()
    {
        _levelq = GetComponent<Levelq>();
        Spawn();
    }

    private void Spawn()
    {
        var oldPosition = Vector3.zero;
        var i = 0;
        while (i < 500)
        {
            i++;
            _distanceTravelled += _distance;
            var position = _levelq.PathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
            var rotation = _levelq.PathCreator.path.GetRotationAtDistance(_distanceTravelled,  EndOfPathInstruction.Stop);
            if (oldPosition == position)
            {
                Debug.Log("I am work");
                break;
            }
            Instantiate(_gameObjectRail, position, rotation, _transformParentRail);
            oldPosition = position; 
        }
    }
}
