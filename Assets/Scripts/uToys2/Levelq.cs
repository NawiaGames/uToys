using Cinemachine;
using PathCreation;
using UnityEngine;

public class Levelq : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera; 

    public PathCreator PathCreator => _pathCreator;
    public CinemachineVirtualCamera VirtualCamera => _virtualCamera; 
}
