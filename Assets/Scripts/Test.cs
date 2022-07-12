using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float _speed = 5f; 
    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime; 
    }
}
