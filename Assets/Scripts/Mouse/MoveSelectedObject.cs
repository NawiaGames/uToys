using System.Collections;
using UnityEngine;

public enum  ControllerMove {Scale, MoveUP, MoveUpAndFinger}
public class MoveSelectedObject : MonoBehaviour
{
    [SerializeField] private float _positionY = 2f;
    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private float _distanceTouch = 5f; 
    [SerializeField] private ControllerMove _controllerMove = ControllerMove.Scale; 
    private Camera _camera;
    private int _starScale = 1;
    private SelectObject _currentSelectObject;
    
    public void SetCamera(Camera camera) => _camera = camera;

    public void SetSelectObject(SelectObject currentSelectObject) => _currentSelectObject = currentSelectObject;
    
    public void MoveSelectObject()
    {
        if(_currentSelectObject == null) return;

        var objectTransform = _currentSelectObject.gameObject.transform;
        var positionMouse = Input.mousePosition;
        Vector3 worldMousePosition;
        Vector3 positionMove;
        StopAllCoroutines();
        
        switch (_controllerMove)
        {
            case ControllerMove.Scale:
                positionMouse.z =  _camera.transform.position.y; 
                worldMousePosition = _camera.ScreenToWorldPoint(positionMouse);
                objectTransform.position = new Vector3(worldMousePosition.x, _currentSelectObject.gameObject.transform.position.y, worldMousePosition.z);
                _currentSelectObject.SetCurrentScaleEnd();
                break;
            case ControllerMove.MoveUP:
                positionMouse.z =  _camera.transform.position.y; 
                worldMousePosition = _camera.ScreenToWorldPoint(positionMouse);
                positionMove = new Vector3(worldMousePosition.x, _positionY, worldMousePosition.z);
                objectTransform.position =
                    Vector3.Lerp(objectTransform.position, positionMove, Time.deltaTime * _speedMove); 
                break;
            case ControllerMove.MoveUpAndFinger:
                positionMouse.z =  _distanceTouch; 
                worldMousePosition = _camera.ScreenToWorldPoint(positionMouse);
                positionMove = new Vector3(worldMousePosition.x, worldMousePosition.y, worldMousePosition.z);
                objectTransform.position =
                    Vector3.Lerp(objectTransform.position, positionMove, Time.deltaTime * _speedMove); 
                break;
        }

    }

    public void ResetSelectObject(Vector3 _startPosition)
    {
        var objectTransform = _currentSelectObject.gameObject.transform;
        objectTransform.position =
            new Vector3(objectTransform.position.x, _startPosition.y, objectTransform.position.z);
        _currentSelectObject.SetCurrentScaleStart();
        _currentSelectObject = null; 
    }

    public void SetPositionY(float value) => _positionY = value;

    public void StartCoroutineMove(Vector3 position)
    {
        StopAllCoroutines();
        StartCoroutine(MovePlatform(position));
    }

    private IEnumerator MovePlatform(Vector3 position)
    {
        var objectTransform = _currentSelectObject.gameObject.transform; 
        while (position != objectTransform.position)
        {
            objectTransform.position = Vector3.MoveTowards(objectTransform.position, position, Time.deltaTime * _speedMove);
            yield return null; 
        }

        _currentSelectObject = null;
    }
}
