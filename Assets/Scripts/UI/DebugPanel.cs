using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    [SerializeField] private MouseController _mouseController; 
    [SerializeField] private TextMeshProUGUI _textUpSelectObject;
    [SerializeField] private Slider _sliderUpSelectObject;

    public void OnSliderUpSelectObject(float value)
    {
        _textUpSelectObject.text = "Up select object: " + value.ToString("F1"); 
        Debug.Log(value);
        _mouseController.MoveSelectedObject.SetPositionY(value);
    }
}
