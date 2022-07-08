using UnityEngine;

public class Raycast
{
    private Camera _camera;
    
    public Raycast(Camera camera)
    {
        _camera = camera;
    }
    
    public SelectObject StartRaycast()
    {
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var raycastHitInfo);

        if(raycastHitInfo.collider == null) return null;
        
        var currentSelectObject = raycastHitInfo.collider.GetComponentInParent<SelectObject>();

        return currentSelectObject;
    }

    public Platform RaycastPlatform()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var raycastHitInfo);
        Debug.DrawRay(ray.origin, ray.direction * 1000f);
        if(raycastHitInfo.collider == null) return null;
        
        var platform = raycastHitInfo.collider.GetComponentInParent<Platform>();

        return platform; 
    }
}
