using UnityEngine;

[RequireComponent(typeof(ParticleSystemSmoke))]
public class TrainController : MonoBehaviour
{
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private DeleteWagon _deleteWagon;
    [SerializeField] private CreatorLevel _creatorLevel;
    [SerializeField] private CameraConstantWidth _cameraConstantWidth;
    [SerializeField] private float _waitTimeStarTrain = 1f;

    private bool _isFirstStartTutorial = true;
    private ParticleSystemSmoke _particleSystemSmoke;

    public MoveTrain MoveTrain => _moveTrain;

    private void Start()
    {
        _particleSystemSmoke = GetComponent<ParticleSystemSmoke>();
        _moveTrain.StartPositionWagons();
    }

    private void Update()
    {
        if (!_moveTrain.IsStopTrain)
            _moveTrain.MoveWagonsAndHead();
        else if (MoveTrain.IndexCurrentPath == 0 && _isFirstStartTutorial)
            ActivateTutorial();
    }

    public void DeleteLastWagon() => _deleteWagon.DeleteLastWagon();

    public void BeginLevel()
    {
        _particleSystemSmoke.ReduceParticles();
    }

    public void EnableVirtualCamera()
    {
        _creatorLevel.Levels[MoveTrain.IndexCurrentPath].VirtualCamera.enabled = true;
        _cameraConstantWidth.SetLevelCamera(_creatorLevel.Levels[MoveTrain.IndexCurrentPath].VirtualCamera);
    }

    public void EndLevel()
    {
        _creatorLevel.Levels[MoveTrain.IndexCurrentPath].VirtualCamera.enabled = false;
        _cameraConstantWidth.SetMainCamera();

        _particleSystemSmoke.IncreaseParticles();

        _creatorLevel.Levels[MoveTrain.IndexCurrentPath].Lights.EnableGreenColor();

        Invoke("StartTrain", _waitTimeStarTrain);
    }

    private void StartTrain() => MoveTrain.StartTrain();

    private void ActivateTutorial()
    {
        var selectObject = _creatorLevel.Levels[MoveTrain.IndexCurrentPath].SelectObjects.SelectObjectsGame;
        var positions = new Vector3[selectObject.Length];
        for (var i = 0; i < positions.Length; i++)
            positions[i] = selectObject[i].transform.position;
        var positionDragDrop = _creatorLevel.Levels[MoveTrain.IndexCurrentPath].TransformSetToPlace.position;
        EventManager.OnActivatedTutorial(positions, positionDragDrop);

        _isFirstStartTutorial = false;
    }
}