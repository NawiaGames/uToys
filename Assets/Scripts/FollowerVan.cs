using UnityEngine;

public class FollowerVan : MonoBehaviour
{
    [SerializeField] private Transform _transformFollower;
    [SerializeField] private float _speedRotation = 5f;
    [SerializeField] private float _speedMove = 5f; 

    private void Update()
    {
        MoveVan();
    }

    private void MoveVan()
    {
        var direction = _transformFollower.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction),
            _speedRotation * Time.deltaTime);
        transform.Translate(Vector3.forward * _speedMove * Time.deltaTime);
    }
}
