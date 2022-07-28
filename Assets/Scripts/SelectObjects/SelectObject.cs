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
    private Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;
    public Answer Answer => _answer;


    private void Awake()
    {
        _startPosition = gameObject.transform.position;
    }

    public void EnableCollider(bool state) => _collider.enabled = state;
}