using System.Collections;
using UnityEngine;
using PathCreation;

public class FollowerPath : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Wagon[] _wagons;
    [SerializeField] private Wagon _wagonHead; 
    [SerializeField] private FallTrain _fallTrain;
    private float _distanceTravelled;
    private bool _isEndPath;

    public bool IsEndPath => _isEndPath;
    public FallTrain FallTrain => _fallTrain; 

    private void Awake()
    {
        _fallTrain.SetRigidbodyWagons(_wagons, _wagonHead);
    }

    [ContextMenu("StartMove")]
    public void StartMoveTrain()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTrain());
    }

    private IEnumerator MoveTrain()
    {
        SetStartPositionWagons();
        
        while (!_isEndPath)
        {
            MoveWagonsAndHead();
            yield return null;
        }

    }
    

    private void SetStartPositionWagons()
    {
        foreach (var van in _wagons)
        {
            van.transform.position = _pathCreator.path.GetPointAtDistance(0);
            van.transform.rotation = _pathCreator.path.GetRotationAtDistance(0);
        }
    }

    private void MoveWagonsAndHead()
    {
        var previousPosition = transform.position;
        var previousRotation = transform.rotation;
        
        foreach (var van in _wagons)
        {
            var vanTransform = van.transform;
            var tempRotation = vanTransform.rotation;
            var tempPosition = vanTransform.position;
            van.transform.rotation =
                Quaternion.Lerp(vanTransform.rotation, previousRotation, _speed * Time.deltaTime);
            van.transform.position = Vector3.Lerp(vanTransform.position, previousPosition, _speed * Time.deltaTime);

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