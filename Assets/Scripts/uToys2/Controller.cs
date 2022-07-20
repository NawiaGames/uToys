using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MoveSelectedObject _moveSelectedObject;

    
    private SelectObject _currentSelectObject;
    private Raycast _raycast;

    private void Start()
    {
        _raycast = new Raycast(_camera);
    }

    private void Update()
    {
        MouseHandler();
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

            SetObjects();
        }
    }
    
    private void TrySetSelectObject()
    {
        _currentSelectObject = _raycast.StartRaycast();
        if (_currentSelectObject != null)
            _moveSelectedObject.SetSelectObject(_currentSelectObject);
    }
    
    private void SetObjects()
    {
        _currentSelectObject = null;
    }

}
