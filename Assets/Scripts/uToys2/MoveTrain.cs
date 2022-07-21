using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class MoveTrain : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private List<Wagon> _wagons;

    private PathCreator[] _pathCreator;
    private float _distanceTravelled;
    private bool _isEndPath;
    private int _indexCurrentPath;

    public bool IsEndPath => _isEndPath;
    public List<Wagon> Wagons => _wagons;
    public int IndexCurrentPath => _indexCurrentPath;

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
                Quaternion.Lerp(vanTransform.rotation, previousRotation, _speed * Time.deltaTime);
            wagon.transform.position = Vector3.Lerp(vanTransform.position, previousPosition, _speed * Time.deltaTime);

            previousPosition = tempPosition;
            previousRotation = tempRotation;
        }

        MoveHeadPath();
    }

    private void MoveHeadPath()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        var nextPosition = _pathCreator[_indexCurrentPath].path
            .GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);

        if (transform.position == nextPosition && _pathCreator.Length > _indexCurrentPath + 1)
        {
            NextPath();
        }
        else if (transform.position == nextPosition)
        {
            StopTrain();
            EventManager.OnOpenedSummary(Answer.Win);
        }

        transform.position = nextPosition;
        transform.rotation = _pathCreator[_indexCurrentPath].path
            .GetRotationAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
    }

    public void StartPositionWagons()
    {
        var position = _pathCreator[_indexCurrentPath].path.GetPointAtDistance(0);
        var rotation = _pathCreator[_indexCurrentPath].path.GetRotationAtDistance(0);
        var backOffset = Vector3.back;
        foreach (var wagon in _wagons)
        {
            var transformWagon = wagon.transform;
            transformWagon.position = position;
            transformWagon.rotation = rotation;
            transformWagon.Translate(backOffset);
            backOffset.z -= 1;
        }
    }

    private void NextPath()
    {
        _indexCurrentPath++;
        _distanceTravelled = 0f;
        StartTrain();
    }

    public void SetPathCreators(PathCreator[] pathCreators)
    {
        _pathCreator = new PathCreator[pathCreators.Length];

        for (var i = 0; i < pathCreators.Length; i++)
            _pathCreator[i] = pathCreators[i];
    }

    public void StopTrain() => _isEndPath = true;

    public void StartTrain() => _isEndPath = false;


}