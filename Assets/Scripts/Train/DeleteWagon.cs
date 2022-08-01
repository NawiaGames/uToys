using System;
using System.Linq;
using Unity.VisualScripting;
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
    private void DeleteLastWagon()
    {
        _moveTrain.Wagons.Last().Explosion();
        _moveTrain.Wagons.Remove(_moveTrain.Wagons.Last());
        if (_moveTrain.Wagons.Count > 0)
            _moveTrain.Wagons.Last().AddComponent<LastWagon>();
        
        if (_moveTrain.Wagons.Count != 0) return;
        
        TheEndGame();
    }

    private void TheEndGame()
    {
        _moveTrain.StopTrain();
        EventManager.OnOpenedSummary(Answer.Fail);
    }

    private void OnEnable()
    {
        EventManager.DeleteWagon += DeleteLastWagon;
    }

    private void OnDisable()
    {
        EventManager.DeleteWagon -= DeleteLastWagon;
    }
}