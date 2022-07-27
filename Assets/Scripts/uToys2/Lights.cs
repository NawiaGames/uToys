using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    [ContextMenu("EnableRedColor")]
    public void EnableRedColor()
    {
        _renderer.materials[0].EnableKeyword("_EMISSION");
        _renderer.materials[1].DisableKeyword("_EMISSION");
    }
    
    [ContextMenu("EnableGreenColor")]
    public void EnableGreenColor()
    {
        _renderer.materials[1].EnableKeyword("_EMISSION");
        _renderer.materials[0].DisableKeyword("_EMISSION");
    }
}
