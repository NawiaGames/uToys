using TMPro;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    [SerializeField] private SelectObjects _selectObjects; 
    [Header("Scale")]
    [SerializeField] private TextMeshProUGUI _textScale;
    [Header("Scale speed")]
    [SerializeField] private TextMeshProUGUI _textScaleSpeed;

    public void OnSliderScale(float value)
    {
        _textScale.text = "Scale: " + value.ToString("F1"); 
        _selectObjects.SetScale(value);
    }
    
    public void OnSliderScaleSpeed(float value)
    {
        _textScaleSpeed.text = "Scale speed: " + value.ToString("F1"); 
        _selectObjects.SetSpeed(value);
    }
}
