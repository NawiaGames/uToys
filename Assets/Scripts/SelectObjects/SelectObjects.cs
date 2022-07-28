using UnityEngine;

public class SelectObjects : MonoBehaviour
{
    [SerializeField] private SelectObject[] _selectObjects;

    public SelectObject[] SelectObjectsGame => _selectObjects;
}