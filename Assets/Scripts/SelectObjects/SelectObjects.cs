using UnityEngine;

public class SelectObjects : MonoBehaviour
{
    [SerializeField] private SelectObject[] _selectObjects;
    [SerializeField] private float _scaleEnd = 1.5f;
    [SerializeField] private float _speedScale = 5f;

    
    private void Start()
    {
        SetScaleAndSpeed();
    }

    public void SetScale(float value)
    {
        _scaleEnd = value; 
        SetScaleAndSpeed();
    }

    public void SetSpeed(float value)
    {
        _speedScale = value; 
        SetScaleAndSpeed();
    }

    private void SetScaleAndSpeed()
    {
        foreach (var select in _selectObjects)
        {
            select.SetScaleEnd(_scaleEnd);
            select.SetSpeedScale(_speedScale);
        }
    }
}
