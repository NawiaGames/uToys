using System.Collections;
using GameLib.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private InputOverlayTutorial _inputOverlayTutorial;
    [SerializeField] private float _timeNextStep = 1f;

    public void StartTutorial(Vector3[] positions, Vector3 positionDragDrop)
    {
        StopAllCoroutines();
        StartCoroutine(StartTutorialCoroutine(positions, positionDragDrop));
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
}