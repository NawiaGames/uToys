using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public enum EaseMove
{
    Unset,
    Linear,
    InSine,
    OutSine,
    InOutSine,
    InQuad,
    OutQuad,
    InOutQuad,
    InCubic,
    OutCubic,
    InOutCubic,
    InQuart,
    OutQuart,
    InOutQuart,
    InQuint,
    OutQuint,
    InOutQuint,
    InExpo,
    OutExpo,
    InOutExpo,
    InCirc,
    OutCirc,
    InOutCirc,
    InElastic,
    OutElastic,
    InOutElastic,
    InBack,
    OutBack,
    InOutBack,
    InBounce,
    OutBounce,
    InOutBounce,
    Flash,
    InFlash,
    OutFlash,
    InOutFlash,
}
public class MoveSelectedObject : MonoBehaviour
{
    [SerializeField] private float _speedMove = 5f;
    [SerializeField] private float _speedDown = 10f;
    [SerializeField] private float _minSpeedDown = 0.1f;
    [SerializeField] private float _distanceTouch = 5f;
    [SerializeField] private ManagerUIPanel _managerUIPanel;
    [SerializeField] private EaseMove _ease = EaseMove.InSine;
    private Camera _camera;
    private SelectObject _currentSelectObject;

    public void SetCamera(Camera camera) => _camera = camera;

    public void SetSelectObject(SelectObject currentSelectObject) => _currentSelectObject = currentSelectObject;

    public void MoveSelectObject()
    {
        if (_currentSelectObject == null) return;

   //     StopAllCoroutines();

        var objectTransform = _currentSelectObject.gameObject.transform;
        var positionMouse = Input.mousePosition;
        positionMouse.z = _distanceTouch;
        var worldMousePosition = _camera.ScreenToWorldPoint(positionMouse);
        objectTransform.position =
            Vector3.Lerp(objectTransform.position, worldMousePosition, Time.deltaTime * _speedMove);
    }

    public void StartCoroutineMove(Vector3 position, bool isPlatform = false)
    {
        var objectTransform = _currentSelectObject.gameObject.transform;

        switch (_ease)
        {
            case EaseMove.InSine:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InSine);
                break;
            case EaseMove.OutSine:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutSine);
                break;
            case EaseMove.InOutSine:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutSine);
                break;
            case EaseMove.InQuad:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InQuad);
                break;
            case EaseMove.Flash:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.Flash);
                break;
            case EaseMove.InFlash:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InFlash);
                break;
            case EaseMove.Unset:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.Unset);
                break;
            case EaseMove.Linear:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.Linear);
                break;
            case EaseMove.OutQuad:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutQuad);
                break;
            case EaseMove.InOutQuad:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutQuad);
                break;
            case EaseMove.InCubic:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InCubic);
                break;
            case EaseMove.OutCubic:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutCubic);
                break;
            case EaseMove.InOutCubic:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutCubic);
                break;
            case EaseMove.InQuart:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InQuart);
                break;
            case EaseMove.OutQuart:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutQuart);
                break;
            case EaseMove.InOutQuart:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutQuart);
                break;
            case EaseMove.InQuint:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InQuint);
                break;
            case EaseMove.OutQuint:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutQuint);
                break;
            case EaseMove.InOutQuint:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutQuint);
                break;
            case EaseMove.InExpo:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InExpo);
                break;
            case EaseMove.OutExpo:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutExpo);
                break;
            case EaseMove.InOutExpo:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutExpo);
                break;
            case EaseMove.InCirc:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InCirc);
                break;
            case EaseMove.OutCirc:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutCirc);
                break;
            case EaseMove.InOutCirc:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutCirc);
                break;
            case EaseMove.InElastic:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InElastic);
                break;
            case EaseMove.OutElastic:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutElastic);
                break;
            case EaseMove.InOutElastic:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutElastic);
                break;
            case EaseMove.InBack:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InBack);
                break;
            case EaseMove.OutBack:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutBack);
                break;
            case EaseMove.InOutBack:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutBack);
                break;
            case EaseMove.InBounce:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InBounce);
                break;
            case EaseMove.OutBounce:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutBounce);
                break;
            case EaseMove.InOutBounce:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutBounce);
                break;
            case EaseMove.OutFlash:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.OutFlash);
                break;
            case EaseMove.InOutFlash:
                objectTransform.DOMove(position, _speedDown).SetEase(Ease.InOutFlash);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        //StopAllCoroutines();
        //     StartCoroutine(MoveDown(position, isPlatform));

        if (isPlatform)
        {
            StopAllCoroutines(); 
            StartCoroutine(OpenSummaryScreen(position));
        }
        
    }

    private IEnumerator OpenSummaryScreen(Vector3 position)
    {
        var objectTransform = _currentSelectObject.gameObject.transform;
        
        while (position != objectTransform.position)
        {
            yield return null; 
        }
        
        _managerUIPanel.OpenPanelSummary(_currentSelectObject.Answer);
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
                Vector3.LerpUnclamped(objectTransform.position, position, Time.deltaTime * _speedDown);
            yield return null;
        }

        if (isPlatform)
            _managerUIPanel.OpenPanelSummary(_currentSelectObject.Answer);

        _currentSelectObject = null;
    }
}