using PathCreation;
using UnityEngine;

[RequireComponent(typeof(Level))]
public class SpawnRailRoad : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectRail;
    [SerializeField] private float _distance = 0.05f;
    [SerializeField] private CombineMeshe _combineMeshe; 

    private Level _level;
    private float _distanceTravelled;

    private void Start()
    {
        _level = GetComponent<Level>();
        Spawn();
        _combineMeshe.Combine();
    }

    private void Spawn()
    {
        var oldPosition = Vector3.zero;
        
        while (true)
        {
            _distanceTravelled += _distance;
            var position = _level.PathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
            var rotation = _level.PathCreator.path.GetRotationAtDistance(_distanceTravelled,  EndOfPathInstruction.Stop);
            if (oldPosition == position)
            {
                break;
            }
            Instantiate(_gameObjectRail, position, rotation, _combineMeshe.transform);
            oldPosition = position; 
        }
    }
}
