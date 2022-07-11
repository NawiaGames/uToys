using UnityEngine;

public enum Answer
{
    Fail,
    Win,
    King
}

public class SelectObject : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Answer _answer = Answer.Fail;

    private Transform _transform;
    private Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;
    public Answer Answer => _answer;

    private void Awake()
    {
        _transform = gameObject.transform;
    }

    private void Start()
    {
        _startPosition = gameObject.transform.position;
    }

    public void EnableCollider(bool state) => _collider.enabled = state;

    public void ResetObject()
    {
        gameObject.transform.position = _startPosition; 
        EnableCollider(true);
    }
}