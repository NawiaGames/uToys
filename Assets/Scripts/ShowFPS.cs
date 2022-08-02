using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    [SerializeField] private Text _fpsText;
    private float _deltaTime;

    private void Update()
    {
        _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
        var fps = 1.0f / _deltaTime;
        _fpsText.text = "FPS: " + (int)fps;
    }
}