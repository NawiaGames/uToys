using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float _force = 5f;
    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            TestPhysics();
    }

    private void TestPhysics()
    {
        _rigidbody.AddTorque(Vector3.left * _force, ForceMode.VelocityChange);
    }
}
