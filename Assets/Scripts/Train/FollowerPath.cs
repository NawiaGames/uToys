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
    [SerializeField] private ParticleSystem _particleSystemSmoke;
    
    private Vector3 _startPositionPath;
    private Quaternion _startRotationPath;
    private Vector3[] _startPositions;
    private Quaternion[] _startRotations;
    private float _distanceTravelled;
    private bool _isEndPath;

    public ParticleSystem ParticleSystemSmoke => _particleSystemSmoke;
    public bool IsEndPath => _isEndPath;
    public FallTrain FallTrain => _fallTrain;

    private void Awake()
    {
        _fallTrain.SetRigidbodyWagons(_wagons, _wagonHead);
        SaveStartPositionAndRotationWagons();
    }

    private void SaveStartPositionAndRotationWagons()
    {
        var size = _wagons.Length + 1;
        _startPositions = new Vector3[size];
        _startRotations = new Quaternion[size];

        for (var i = 0; i < size - 1; i++)
        {
            _startPositions[i] = _wagons[i].transform.position;
            _startRotations[i] = _wagons[i].transform.rotation; 
        }

        _startPositions[^1] = transform.position;
        _startRotations[^1] = transform.rotation; 
    }


    [ContextMenu("StartMove")]
    public void StartMoveTrain()
    {
        _particleSystemSmoke.Play();
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
        _startPositionPath = _pathCreator.path.GetPointAtDistance(0);
        _startRotationPath = _pathCreator.path.GetRotationAtDistance(0);
        SetWagonsPositionRotationToPath();
    }

    private void SetWagonsPositionRotationToPath()
    {
        foreach (var van in _wagons)
        {
            van.Rigidbody.isKinematic = true;
            van.transform.position = _startPositionPath;
            van.transform.rotation = _startRotationPath;
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

    [ContextMenu("Reset")]
    public void ResetTrain()
    {
        SetStarPositionTrain();
    }

    private void SetStarPositionTrain()
    {
        _isEndPath = false; 
        
        for (var i = 0; i < _startPositions.Length - 1; i++)
        {
            _wagons[i].Rigidbody.isKinematic = true;
            _wagons[i].Rigidbody.transform.localPosition = Vector3.zero;
            _wagons[i].Rigidbody.transform.rotation = new Quaternion(0,0,0, 0);
            _wagons[i].transform.position = _startPositions[i];
            _wagons[i].transform.rotation = _startRotations[i]; 
        }

        _wagonHead.Rigidbody.isKinematic = true;
        _wagonHead.Rigidbody.transform.localPosition = Vector3.zero;
        _wagonHead.Rigidbody.transform.localRotation = Quaternion.identity;
        transform.position = _startPositions[^1];
        transform.rotation = _startRotations[^1];
        _distanceTravelled = 0;
    }
}