using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Levelq _levelq; 
    private bool _isEmpty = true;

    public void IsPlatform()
    {
        //_renderer.material.color = Color.green;
        _levelq.Outline.OutlineWidth = _levelq.WidthOutline; 
    }

    public void FreePlatform()
    {
        //_renderer.material.color = Color.gray;
        _levelq.Outline.OutlineWidth = 0; 
    }

    public bool IsEmpty() => _isEmpty;

    public void SetIsEmpty(bool state) => _isEmpty = state; 
}
