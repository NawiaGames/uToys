using UnityEngine;

public enum FallVariants
{
    TorqueRight,
    TorqueRightAndForceBack
}

public class FallTrain : MonoBehaviour
{
    [SerializeField] private float _forceTorque = 10f;
    [SerializeField] private float _forceBack = 2f;
    [SerializeField] private FallVariants _variants = FallVariants.TorqueRight;
    private Rigidbody[] _rigidbodyWagons;

    [ContextMenu("Fall")]
    public void Fall()
    {
        foreach (var wagon in _rigidbodyWagons)
        {
            wagon.isKinematic = false; 
            
            if (_variants == FallVariants.TorqueRightAndForceBack)
                wagon.AddForce(-wagon.transform.forward * _forceBack, ForceMode.VelocityChange);

            wagon.AddTorque(-wagon.transform.forward * _forceTorque, ForceMode.VelocityChange);
        }
    }

    public void SetRigidbodyWagons(Wagon[] wagons)
    {
        _rigidbodyWagons = new Rigidbody[wagons.Length];
        for (var i = 0; i < wagons.Length; i++)
        {
            _rigidbodyWagons[i] = wagons[i].Rigidbody;
        }
    }
}