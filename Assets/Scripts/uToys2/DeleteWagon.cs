using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MoveTrain))]
public class DeleteWagon : MonoBehaviour
{
    private MoveTrain _moveTrain;

    private void Start()
    {
        _moveTrain = GetComponent<MoveTrain>();
    }

    [ContextMenu("DeleteWagon")]
    public void DeleteLastWagon()
    {
        _moveTrain.Wagons.Last().Explosion();
        _moveTrain.Wagons.Remove(_moveTrain.Wagons.Last());

        if (_moveTrain.Wagons.Count != 0) return;

        _moveTrain.StopTrain();
        EventManager.OnOpenedSummary(Answer.Fail);
    }
}