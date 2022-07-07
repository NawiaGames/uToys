using UnityEngine;

public class Raycast
{
    private Camera _camera;
    
    public Raycast(Camera camera)
    {
        _camera = camera;
    }
    
    public SelectObject StartRaycast(out Vector3 startPosition)
    {
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var raycastHitInfo);

        startPosition = Vector3.zero;
        if(raycastHitInfo.collider == null) return null;
        
        var currentSelectObject = raycastHitInfo.collider.GetComponentInParent<SelectObject>();

        if (currentSelectObject != null)
        {
            startPosition = currentSelectObject.gameObject.transform.position;
        }

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
