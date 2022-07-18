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
    [SerializeField] private bool _isRagDollModel;
    private Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;
    public Answer Answer => _answer;
    public bool IsPlayPhysics => _isPlayPhysics;
    public bool IsRagDollModel => _isRagDollModel;

    private void Awake()
    {
        _startPosition = IsRagDollModel ? GetTransformRagDollModel().localPosition : gameObject.transform.position;
    }

    public void EnableCollider(bool state) => _collider.enabled = state;

    public void ResetObject()
    {
        if (IsRagDollModel)
            _collider.gameObject.transform.localPosition = _startPosition;
        else
            gameObject.transform.position = _startPosition;
        
        EnableCollider(true);
    }

    public Transform GetTransformRagDollModel() => _collider.gameObject.transform;

}