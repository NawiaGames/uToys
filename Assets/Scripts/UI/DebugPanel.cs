using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    [SerializeField] private MouseController _mouseController; 
    [SerializeField] private TextMeshProUGUI _textScale;
    [SerializeField] private Slider _sliderScale;
    [SerializeField] private TextMeshProUGUI _textScale;
    [SerializeField] private Slider _sliderScale;

    public void OnSliderUpSelectObject(float value)
    {
        _textScale.text = "Up select object: " + value.ToString("F1"); 
        _mouseController.MoveSelectedObject.SetPositionY(value);
    }
}
