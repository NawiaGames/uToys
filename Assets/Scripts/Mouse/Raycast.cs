using UnityEngine;

public class Raycast
{
    private Camera _camera;
    private LayerMask _layerMaskInputPlane;


    public Raycast(Camera camera)
    {
        _camera = camera;
        _layerMaskInputPlane = LayerMask.GetMask("InputPlane");
    }

    public SelectObject StartRaycast()
    {
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var raycastHitInfo, Mathf.Infinity,
            ~_layerMaskInputPlane);

        if (raycastHitInfo.collider == null) return null;

        var currentSelectObject = raycastHitInfo.collider.GetComponentInParent<SelectObject>();
        return currentSelectObject;
    }

    public Platform RaycastPlatform()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var raycastHitInfo, Mathf.Infinity, LayerMask.GetMask("SetSelectObject") );
        Debug.DrawRay(ray.origin, ray.direction * 1000f);
        if (raycastHitInfo.collider == null) return null;

        var platform = raycastHitInfo.collider.GetComponentInParent<Platform>();

        return platform;
    }

    public Vector3 GetInputPlanePosition()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var raycastHitInfo, Mathf.Infinity,_layerMaskInputPlane);

        if (raycastHitInfo.collider == null) return Vector3.zero;
        if (raycastHitInfo.collider.GetComponent<InputPlane>() == null) return Vector3.zero;

        return raycastHitInfo.point;
    }
}