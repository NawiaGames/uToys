using System.Collections;
using UnityEngine;

public class MoveSelectedObject : MonoBehaviour
{
    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private float _minSpeedDown = 0.1f;
    [SerializeField] private float _distanceTouch = 5f;
    [SerializeField] private ManagerUIPanel _managerUIPanel;
    private Camera _camera;
    private SelectObject _currentSelectObject;

    public void SetCamera(Camera camera) => _camera = camera;

    public void SetSelectObject(SelectObject currentSelectObject) => _currentSelectObject = currentSelectObject;

    public void MoveSelectObject()
    {
        if (_currentSelectObject == null) return;

        StopAllCoroutines();

        var objectTransform = _currentSelectObject.gameObject.transform;
        var positionMouse = Input.mousePosition;
        positionMouse.z = _distanceTouch;
        var worldMousePosition = _camera.ScreenToWorldPoint(positionMouse);
        objectTransform.position =
            Vector3.Lerp(objectTransform.position, worldMousePosition, Time.deltaTime * _speedMove);
    }

    public void StartCoroutineMove(Vector3 position, bool isPlatform = false)
    {
        StopAllCoroutines();
        StartCoroutine(MoveDown(position, isPlatform));
    }

    private IEnumerator MoveDown(Vector3 position, bool isPlatform)
    {
        var objectTransform = _currentSelectObject.gameObject.transform;
        while (position != objectTransform.position)
        {
            var distance = Vector3.Distance(objectTransform.position, position);
            if (distance < _minSpeedDown)
                distance = _minSpeedDown;
            objectTransform.position =
                Vector3.MoveTowards(objectTransform.position, position, Time.deltaTime * distance * _speedMove);
            yield return null;
        }

        if (isPlatform)
            _managerUIPanel.OpenPanelSummary(_currentSelectObject.Answer);

        _currentSelectObject = null;
    }
}