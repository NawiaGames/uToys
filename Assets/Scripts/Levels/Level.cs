using Cinemachine;
using PathCreation;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Animator _animator;
    [SerializeField] private SelectObjects _selectObjects;
    [SerializeField] private Transform _transformSetToPlace;
    [SerializeField] private Lights _lights;
    [SerializeField] private Platform _platform; 

    public PathCreator PathCreator => _pathCreator;
    public CinemachineVirtualCamera VirtualCamera => _virtualCamera;
    public Animator Animator => _animator;
    public SelectObjects SelectObjects => _selectObjects;
    public Transform TransformSetToPlace => _transformSetToPlace;
    public Lights Lights => _lights;
    public Platform Platform => _platform;
}
