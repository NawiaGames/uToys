using System.Collections;
using GameLib.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private InputOverlayTutorial _inputOverlayTutorial;
    [SerializeField] private float _timeNextStep = 1f;

    private bool _isHoldBack; 

    public void StartTutorial(Vector3[] positions, Vector3 positionDragDrop)
    {
        StopAllCoroutines();
        StartCoroutine(HandlerTutorial(positions, positionDragDrop));
    }

    private IEnumerator HandlerTutorial(Vector3[] positions, Vector3 positionDragDrop)
    {
        var coroutine = StartTutorialCoroutine(positions, positionDragDrop);
        StartCoroutine(coroutine);

        var _timer = 0f;

        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0))
            {
                _isHoldBack = true; 
                _inputOverlayTutorial.Deactivate();
                StopCoroutine(coroutine);
            }

            if (Input.GetMouseButtonUp(0))
                _isHoldBack = false;

            _timer += Time.deltaTime;
            if (_timer >= 10 && !_isHoldBack)
            {
                _timer = 0;
                StopCoroutine(coroutine);
                coroutine = StartTutorialCoroutine(positions, positionDragDrop);
                StartCoroutine(coroutine);
            }
        }
    }

    private IEnumerator StartTutorialCoroutine(Vector3[] positions, Vector3 positionDragDrop)
    {
        yield return new WaitForSeconds(_timeNextStep / 2);

        foreach (var position in positions)
        {
            _inputOverlayTutorial.Activate(position);
            yield return new WaitForSeconds(_timeNextStep);
        }

        var dragDrop = new Vector3[]
        {
            positions[^1],
            positionDragDrop
        };
        _inputOverlayTutorial.Activate(dragDrop);
        yield return new WaitForSeconds(_timeNextStep + 0.5f);
        _inputOverlayTutorial.Deactivate();
    }

    public void StopTutorial()
    {
        StopAllCoroutines();
        _inputOverlayTutorial.Deactivate();
    }
}