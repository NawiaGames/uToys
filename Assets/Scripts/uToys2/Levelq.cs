using PathCreation;
using UnityEngine;

public class Levelq : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;

    public PathCreator PathCreator => _pathCreator; 
}
