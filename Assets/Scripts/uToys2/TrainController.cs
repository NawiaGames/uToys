using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] private MoveTrain _moveTrain;

    private void Start()
    {
        _moveTrain.StartPositionWagons();
    }

    private void Update()
    {
        if(!_moveTrain.IsEndPath)
            _moveTrain.MoveWagonsAndHead();
    }
}
