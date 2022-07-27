using Cinemachine;
using PathCreation;
using UnityEngine;

public class Levelq : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Animator _animator;
    [SerializeField] private SelectObjects _selectObjects;
    [SerializeField] private Transform _transformSetToPlace;
    [Header("Outline")]
    [SerializeField] private Outline _outline;
    [SerializeField] private Color _colorOutline = Color.green;
    [SerializeField] private float _widthOutline = 3f; 

    public PathCreator PathCreator => _pathCreator;
    public CinemachineVirtualCamera VirtualCamera => _virtualCamera;
    public Animator Animator => _animator;
    public SelectObjects SelectObjects => _selectObjects;
    public Transform TransformSetToPlace => _transformSetToPlace;
    public Outline Outline => _outline;
    public float WidthOutline => _widthOutline; 

    private void Awake()
    {
        if (_outline != null)
            SetParametersOutline();
    }

    private void SetParametersOutline()
    {
        _outline.OutlineColor = _colorOutline;
        _outline.OutlineWidth = 0;
    }
}
