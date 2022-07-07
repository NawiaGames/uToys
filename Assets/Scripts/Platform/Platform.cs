using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private bool _isEmpty = true;

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
