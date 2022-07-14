using DG.Tweening;
using UnityEngine;

public class MoveSelectedObject : MonoBehaviour
{
    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private float _speedDown = 10f;
    [SerializeField] private float _distanceTouch = 5f;
    [SerializeField] private Ease _ease = Ease.InSine;
    [SerializeField] private float _positionY = 1f; 
    private Camera _camera;
    private SelectObject _currentSelectObject;

    public void SetCamera(Camera camera) => _camera = camera;

    public void SetSelectObject(SelectObject currentSelectObject) => _currentSelectObject = currentSelectObject;

    public void MoveSelectObject(Vector3 position)
    {
        if (_currentSelectObject == null) return;

        var objectTransform = _currentSelectObject.gameObject.transform;
        
        objectTransform.position =
            Vector3.Lerp(objectTransform.position, position, Time.deltaTime * _speedMove);

    }

    public void StartCoroutineMove(Vector3 position)
    {
        var objectTransform = _currentSelectObject.gameObject.transform;
        objectTransform.DOMove(position, _speedDown).SetEase(_ease);
    }
}