using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platform : MonoBehaviour
{
    private Renderer _renderer;
    private bool _isEmpty = true;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void StartPlatform()
    {
        _renderer.material.color = Color.green;
    }

    public void EndPlatform()
    {
        _renderer.material.color = Color.gray;
    }

    public bool IsEmpty() => _isEmpty;

    public void SetIsEmpty(bool state) => _isEmpty = state; 
}
