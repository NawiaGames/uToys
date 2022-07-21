using System;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] private MoveTrain _moveTrain;
    [SerializeField] private DeleteWagon _deleteWagon;
    [SerializeField] private CreatorLevelq _creatorLevelq;
    
    public MoveTrain MoveTrain => _moveTrain; 

    private void Start()
    {
        _moveTrain.StartPositionWagons();
    }

    private void Update()
    {
        if(!_moveTrain.IsEndPath)
            _moveTrain.MoveWagonsAndHead();
    }

    public void DeleteLastWagon() => _deleteWagon.DeleteLastWagon();

    public void EnableCameraLevel()
    {
        _creatorLevelq.Levelqs[_moveTrain.IndexCurrentPath].VirtualCamera.enabled = true; 
    }

    [ContextMenu("Disable Camera")]
    public void DisableCameraLevel()
    {
        _creatorLevelq.Levelqs[_moveTrain.IndexCurrentPath].VirtualCamera.enabled = false;     }
}
