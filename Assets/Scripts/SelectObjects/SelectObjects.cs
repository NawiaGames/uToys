using UnityEngine;

public class SelectObjects : MonoBehaviour
{
    [SerializeField] private SelectObject[] _selectObjects;

    public void ResetObject()
    {
        foreach (var select in _selectObjects)
        {
            select.ResetObject();
        }
    }
}
