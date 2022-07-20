using UnityEngine;

public class CollisionLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var train = other.GetComponentInParent<MoveTrain>();
        if (train != null)
            train.StopTrain();
    }
}
