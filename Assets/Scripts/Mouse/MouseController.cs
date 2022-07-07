using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MoveSelectedObject _moveSelectedObject;

    private SelectObject _currentSelectObject;
    private Platform _currentPlatform;
    private Raycast _raycast;
    private Vector3 _startPosition;
    private bool _canPastSelectObject;

    public MoveSelectedObject MoveSelectedObject => _moveSelectedObject;

    private void Start()
    {
        _raycast = new Raycast(_camera);
        _moveSelectedObject.SetCamera(_camera);
    }

    private void Update()
    {
        MouseHandler();

        if (_currentSelectObject != null)
        {
            _moveSelectedObject.MoveSelectObject();

            _currentSelectObject.EnableCollider(false);

            PlatformHandler();
        }
    }

    private void PlatformHandler()
    {
        _canPastSelectObject = false;

        if (_currentPlatform != null)
            _currentPlatform.EndPlatform();

        _currentPlatform = _raycast.RaycastPlatform();

        if (_currentPlatform != null)
        {
            _canPastSelectObject = true;
            _currentPlatform.StartPlatform();
        }
    }

    private void MouseHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySetSelectObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_currentSelectObject == null) return;

            ResetObjects();
        }
    }

    private void TrySetSelectObject()
    {
        _currentSelectObject = _raycast.StartRaycast(out var _startPosition);
        if (_currentSelectObject != null)
            _moveSelectedObject.SetSelectObject(_currentSelectObject);
    }

    private void ResetObjects()
    {
        if (_canPastSelectObject)
        {
            _moveSelectedObject.StartCoroutineMove(_currentPlatform.gameObject.transform.position);
            _currentPlatform = null;
        }
        else
            _moveSelectedObject.ResetSelectObject(_startPosition);
        _currentSelectObject.EnableCollider(true);
        _currentSelectObject = null;
    }
}