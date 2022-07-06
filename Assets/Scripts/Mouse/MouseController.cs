using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MoveSelectedObject _moveSelectedObject;
    
    private SelectObject _currentSelectObject;
    private Raycast _raycast;
    private Vector3 _startPosition;

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
            _moveSelectedObject.MoveSelectObject(_currentSelectObject);
        }
    }

    private void MouseHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentSelectObject = _raycast.StartRaycast(out var _startPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(_currentSelectObject == null) return;
            _moveSelectedObject.ResetSelectObject(_currentSelectObject, _startPosition);
            _currentSelectObject = null;
        }
    }
}
