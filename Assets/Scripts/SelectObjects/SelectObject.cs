using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private Transform _transform;
    private float _speedScale = 5f;
    private float _scaleEnd = 1f;
    private float _scaleStart = 1f;
    private float _scaleCurrent; 

    private void Awake()
    {
        _transform = gameObject.transform;
        _scaleStart = _transform.localScale.x;
        _scaleCurrent = _scaleStart;
    }

    private void Update()
    {
        UpdateScale();
    }

    private void UpdateScale()
    {
        if (_transform.localScale.x != _scaleCurrent)
        {
            var scale = Mathf.Lerp(_transform.localScale.x, _scaleCurrent, _speedScale * Time.deltaTime);
            _transform.localScale = new Vector3(scale, scale, scale); 
        }
    }

    public void SetCurrentScaleEnd() => _scaleCurrent = _scaleEnd;

    public void SetCurrentScaleStart() => _scaleCurrent = _scaleStart; 
    
    public void SetScaleEnd(float value) => _scaleEnd = value;

    public void SetSpeedScale(float value) => _speedScale = value; 
}
