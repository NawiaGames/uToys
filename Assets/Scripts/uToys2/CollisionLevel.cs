using UnityEngine;

public class CollisionLevel : MonoBehaviour
{
    private LastWagon _currentWagon; 
    private void OnTriggerEnter(Collider other)
    {
        var lastWagon = other.GetComponentInParent<LastWagon>();
        if (lastWagon != null && _currentWagon != lastWagon)
        {
            var train = lastWagon.GetComponentInParent<TrainController>();
            train.MoveTrain.StopTrain();
            train.BeginLevel();
            _currentWagon = lastWagon;
        }
    }
}
