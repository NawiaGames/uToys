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
    [SerializeField] private bool _isPlayPhysics; 
    private Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;
    public Answer Answer => _answer;
    public bool IsPlayPhysics => _isPlayPhysics; 

    private void Awake()
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