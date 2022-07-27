using UnityEngine;

[RequireComponent(typeof(ParticleSystemSmoke))]
public class TrainController : MonoBehaviour
{
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private DeleteWagon _deleteWagon;
    [SerializeField] private CreatorLevelq _creatorLevelq;
    [SerializeField] private float _timeStartTutorial = 0.5f;
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
        if(!_moveTrain.IsEndPath)
            _moveTrain.MoveWagonsAndHead();
        else if (MoveTrain.IndexCurrentPath == 0 && _isFirstStartTutorial)
            Invoke("ActivateTutorial", _timeStartTutorial);
    }

    public void DeleteLastWagon() => _deleteWagon.DeleteLastWagon();

    public void BeginLevel()
    {
        _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].VirtualCamera.enabled = true; 
        _cameraConstantWidth.SetLevelCamera(_creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].VirtualCamera);
        
        _particleSystemSmoke.ReduceParticles();
        
        
    }
    
    public void EndLevel()
    {
        _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].VirtualCamera.enabled = false;
        _cameraConstantWidth.SetMainCamera();
        
        _particleSystemSmoke.IncreaseParticles();
        
        _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].Lights.EnableGreenColor();
        
        Invoke("StartTrain", _waitTimeStarTrain);
    }

    private void StartTrain() => MoveTrain.StartTrain();

    private void ActivateTutorial()
    {
        var selectObject = _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].SelectObjects.SelectObjectsGame;
        var positions = new Vector3[selectObject.Length];
        for (var i = 0; i < positions.Length; i++)
            positions[i] = selectObject[i].transform.position;
        var positionDragDrop = _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].TransformSetToPlace.position;
        EventManager.OnActivatedTutorial(positions, positionDragDrop);

        _isFirstStartTutorial = false;
    }
}
