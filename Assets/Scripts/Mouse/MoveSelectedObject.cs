using System.Collections;
using UnityEngine;

public class MoveSelectedObject : MonoBehaviour
{
    [SerializeField] private float _positionY = 2f;
    [SerializeField] private float _speedUp = 5f;
    private Camera _camera;
    private int _starScale = 1; 
    
    public void SetCamera(Camera camera) => _camera = camera; 
    
    public void MoveSelectObject(SelectObject currentSelectObject)
    {
        var objectTransform = currentSelectObject.gameObject.transform;
        var positionMouse = Input.mousePosition;
        positionMouse.z =  _camera.transform.position.y; 
        var worldMousePosition = _camera.ScreenToWorldPoint(positionMouse);
        objectTransform.position = new Vector3(worldMousePosition.x, currentSelectObject.gameObject.transform.position.y, worldMousePosition.z);
        currentSelectObject.SetCurrentScaleEnd();
    }

    public void ResetSelectObject(SelectObject currentSelectObject, Vector3 _startPosition)
    {
        var objectTransform = currentSelectObject.gameObject.transform;
        objectTransform.position =
            new Vector3(objectTransform.position.x, _startPosition.y, objectTransform.position.z);
        currentSelectObject.SetCurrentScaleStart();
    }



    public void SetPositionY(float value) => _positionY = value; 
}
