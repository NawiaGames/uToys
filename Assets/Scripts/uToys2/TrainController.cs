using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private DeleteWagon _deleteWagon;
    [SerializeField] private CreatorLevelq _creatorLevelq;
    [SerializeField] private float _timeStartTutorial = 0.5f;
    [SerializeField] private CameraConstantWidth _cameraConstantWidth; 

    private bool _isFirstStartTutorial = true; 
    
    public MoveTrain MoveTrain => _moveTrain; 

    private void Start()
    {
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

    public void EnableCameraLevel()
    {
        _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].VirtualCamera.enabled = true; 
        _cameraConstantWidth.SetLevelCamera(_creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].VirtualCamera);
    }
    
    public void DisableCameraLevel()
    {
        _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].VirtualCamera.enabled = false;
        _cameraConstantWidth.SetMainCamera();
    }

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
