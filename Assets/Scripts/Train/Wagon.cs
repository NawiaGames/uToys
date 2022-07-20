using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _forceUp = 6f;
    [SerializeField] private float _torque = 3f;
    public Rigidbody Rigidbody => _rigidbody;
    
    public void Explosion()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _forceUp, ForceMode.VelocityChange);
        _rigidbody.AddTorque(-transform.forward * _torque, ForceMode.VelocityChange);
    }
}