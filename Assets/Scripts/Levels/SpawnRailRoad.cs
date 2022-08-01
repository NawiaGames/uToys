using PathCreation;
using UnityEngine;
using static PathCreation.EndOfPathInstruction;

public class SpawnRailRoad : MonoBehaviour
{
    [Header("Railway")]
    [SerializeField] private GameObject _gameObjectRailway;
    [SerializeField] private float _distanceRaylway = 0.05f;
    [Header("Plank")] [SerializeField] private GameObject _gameObjectPlank;
    [SerializeField] private float _distancePlank = 0.1f; 
    [Space]
    [SerializeField] private CombineMeshe _combineMeshe;
    [SerializeField] private PathCreator _pathCreator;

    private float _distanceTravelledRailway;
    private float _distanceTravelledPlank; 

    public PathCreator PathCreator => _pathCreator; 

    public void Spawn()
    {
        var oldPositionRailway = Vector3.zero;
        
        while (true)
        {
            _distanceTravelledRailway += _distanceRaylway;
            _distanceTravelledPlank += _distancePlank; 
            
            var positionRailway = _pathCreator.path.GetPointAtDistance(_distanceTravelledRailway, Stop);
            var rotationRailway = _pathCreator.path.GetRotationAtDistance(_distanceTravelledRailway,  Stop);
            
            var positionPlank = _pathCreator.path.GetPointAtDistance(_distanceTravelledPlank, Stop);
           var rotationPlank = _pathCreator.path.GetRotationAtDistance(_distanceTravelledPlank,  Stop);
            
            if (oldPositionRailway == positionRailway)
            {
                break;
            }
            
            Instantiate(_gameObjectRailway, positionRailway, rotationRailway, _combineMeshe.transform);
            Instantiate(_gameObjectPlank, positionPlank, rotationPlank, _combineMeshe.transform);

            oldPositionRailway = positionRailway; 
        }
        
        _combineMeshe.Combine();
    }
}
