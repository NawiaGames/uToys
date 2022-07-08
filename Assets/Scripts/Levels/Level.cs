using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private SelectObjects _selectObjects;
    [SerializeField] private Platform _platform; 
    public SelectObjects SelectObjects => _selectObjects;
    public Platform Platform => _platform; 
}
