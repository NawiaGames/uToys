using Cinemachine;
using UnityEngine;

public class CameraConstantWidth : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainVirtualCamera;

    public Vector2 DefaultResolution = new Vector2(720, 1280);
    [Range(0f, 1f)] public float WidthOrHeight = 0;

    private Camera componentCamera;

    private float targetAspect;

    private float initialFov;
    private float horizontalFov = 120f;

    private CinemachineVirtualCamera _currentVirtualCamera;

    private void Start()
    {
        componentCamera = GetComponent<Camera>();

        targetAspect = DefaultResolution.x / DefaultResolution.y;

        initialFov = componentCamera.fieldOfView;
        horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);

        SetMainCamera();
    }

    private void Update()
    {
        var constantWidthFov = CalcVerticalFov(horizontalFov, componentCamera.aspect);
        _currentVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(constantWidthFov, initialFov, WidthOrHeight);
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;

        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

        return vFovInRads * Mathf.Rad2Deg;
    }

    public void SetMainCamera() => _currentVirtualCamera = _mainVirtualCamera;

    public void SetLevelCamera(CinemachineVirtualCamera virtualCamera) => _currentVirtualCamera = virtualCamera;
}