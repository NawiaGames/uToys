using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MoveSelectedObject _moveSelectedObject;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private TrainController _trainController; 
    
    private Platform _currentPlatform;
    private SelectObject _currentSelectObject;
    private Raycast _raycast;
    private bool _canPastSelectObject;

    private void Start()
    {
        _raycast = new Raycast(_camera);
    }

    private void Update()
    {
        MouseHandler();

        if (_currentSelectObject != null)
        {
            var postion = _raycast.GetInputPlanePosition();
            _moveSelectedObject.MoveSelectObject(postion);

            _currentSelectObject.EnableCollider(false);

            PlatformHandler();
        }
    }
    
    private void PlatformHandler()
    {
        _canPastSelectObject = false;

        if (_currentPlatform != null && _currentPlatform.IsEmpty())
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
        if (Input.GetMouseButtonDown(0) && _trainController.MoveTrain.IsEndPath)
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
        if (_canPastSelectObject && _currentPlatform.IsEmpty())
        {
            SetSelectObjectToPlatform();
        }
        else
        {
            ResetSelectObject();
        }


        _currentSelectObject = null;
    }
    
    private void SetSelectObjectToPlatform()
    {
        _moveSelectedObject.StartCoroutineMove(_currentPlatform.gameObject.transform.position);
        _currentPlatform.SetIsEmpty(false);
        _animationController.StartAnimation(_currentSelectObject);
        _currentPlatform = null;
    }

    private void ResetSelectObject()
    {
        _moveSelectedObject.StartCoroutineMove(_currentSelectObject.StartPosition);
        _currentSelectObject.EnableCollider(true);
    }
}
