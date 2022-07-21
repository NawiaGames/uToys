using UnityEngine;

public class CollisionLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var trainHead = other.GetComponentInParent<MoveTrain>();
        if (trainHead != null)
        {
            trainHead.StopTrain();
            var train = trainHead.GetComponentInParent<TrainController>(); 
            train.EnableCameraLevel();
        }
    }
}
