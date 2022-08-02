using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PathCreation;
using UnityEngine;

public class MoveTrain : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _minSpeed = 2f;
    [SerializeField] private float _speedChange = 8f; 
    [SerializeField] private List<Wagon> _wagons;

    private PathCreator _pathCreator; 
    private float _distanceTravelled;
    private bool _isStopTrain;
    private int _indexCurrentPath;
    private Vector3 _maxPositionPath;
    private float _currentSpeed = 2f; 

    public bool IsStopTrain => _isStopTrain;
    public List<Wagon> Wagons => _wagons;
    
    public static int IndexCurrentPath;

    private void Awake()
    {
        _currentSpeed = _minSpeed;
        IndexCurrentPath = _indexCurrentPath; 
        _maxPositionPath = _pathCreator.path.GetPoint(_pathCreator.path.NumPoints - 1);
    }

    private void Start()
    {
        IncreaseMaxSpeed(); 
    }

    public void MoveWagonsAndHead()
    {
        var previousPosition = transform.position;
        var previousRotation = transform.rotation;

        foreach (var wagon in _wagons)
        {
            var vanTransform = wagon.transform;
            var tempRotation = vanTransform.rotation;
            var tempPosition = vanTransform.position;
            wagon.transform.rotation =
                Quaternion.Lerp(vanTransform.rotation, previousRotation, _currentSpeed * Time.deltaTime);
            wagon.transform.position = Vector3.Lerp(vanTransform.position, previousPosition, _currentSpeed * Time.deltaTime);

            previousPosition = tempPosition;
            previousRotation = tempRotation;
        }

        MoveHeadPath();
    }

    private void MoveHeadPath()
    {
        _distanceTravelled += _currentSpeed * Time.deltaTime;
        var nextPosition = _pathCreator.path
            .GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
        
        transform.position = nextPosition;
        transform.rotation = _pathCreator.path
            .GetRotationAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
        
        if (transform.position == _maxPositionPath)
        {
            FinishPath();
        }
    }

    private void FinishPath()
    {
        StopTrain();
        EventManager.OnOpenedSummary(Answer.Win);
    }

    public void StartPositionWagons()
    {
        var position = _pathCreator.path.GetPointAtDistance(0);
        var rotation = _pathCreator.path.GetRotationAtDistance(0);
        var backOffset = Vector3.back;
        foreach (var transformWagon in _wagons.Select(wagon => wagon.transform))
        {
            transformWagon.position = position;
            transformWagon.rotation = rotation;
            transformWagon.Translate(backOffset);
            backOffset.z -= 1;
        }
    }

    public void SetPathCreator(PathCreator pathCreators)
    {
        _pathCreator = new PathCreator();
        _pathCreator = pathCreators;
    }

    public void StopTrain() => _isStopTrain = true;

    public void StartTrain()
    {
        if (_wagons.Count >= 1)
        {
            _isStopTrain = false;
        }
        IncreaseMaxSpeed(); 
    } 

    public void ReduceMinSpeed()
    {
        StopAllCoroutines();
        StartCoroutine(ReduceSpeedCoroutine());
    }

    private IEnumerator ReduceSpeedCoroutine()
    {
        _currentSpeed = _maxSpeed; 

        while (_currentSpeed >= _minSpeed)
        {
            yield return null;
            _currentSpeed -= Time.deltaTime * _speedChange; 
        }
    }

    private void IncreaseMaxSpeed()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseSpeedCoroutine());
    }

    private IEnumerator IncreaseSpeedCoroutine()
    {
        _currentSpeed = _minSpeed; 
        while (_currentSpeed <= _maxSpeed)
        {
            yield return null;
            _currentSpeed += Time.deltaTime * _speedChange; 
        }
    }

    public void IncreaseIndexCurrentPath()
    {
        _indexCurrentPath ++; 
        IndexCurrentPath = _indexCurrentPath;
    }
    
}