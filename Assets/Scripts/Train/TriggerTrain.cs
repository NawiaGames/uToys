using UnityEngine;

public class TriggerTrain : MonoBehaviour
{
    [SerializeField] private TrainController _trainController; 
    private void OnTriggerEnter(Collider other)
    {
        var stopBlock = other.GetComponent<StopBox>();
        if (stopBlock != null)
        {
            _trainController.MoveTrain.StopTrain();
            _trainController.BeginLevel();
        }

        var reduceSpeedBox = other.GetComponent<ReduceSpeedBox>();
        if (reduceSpeedBox != null)
        {
            _trainController.MoveTrain.ReduceMinSpeed();
            _trainController.EnableVirtualCamera();
        }
    }
}
