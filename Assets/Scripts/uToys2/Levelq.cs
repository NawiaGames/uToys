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

    public PathCreator PathCreator => _pathCreator;
    public CinemachineVirtualCamera VirtualCamera => _virtualCamera;
    public Animator Animator => _animator;
    public SelectObjects SelectObjects => _selectObjects;
    public Transform TransformSetToPlace => _transformSetToPlace; 
}
