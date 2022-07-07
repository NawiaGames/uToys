using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platform : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void StartPlatform()
    {
        _renderer.material.color = Color.green;
 //       Debug.Log("Color green");
    }

    public void EndPlatform()
    {
        _renderer.material.color = Color.gray;
  //      Debug.Log("Color default");
    }
}
