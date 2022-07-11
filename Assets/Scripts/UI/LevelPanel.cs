using GameLib.UI;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private UIPanel _levels;

    public void ActivatePanel() => _levels.ActivatePanel();

    public void DeactivatePanel() => _levels.DeactivatePanel(); 
}
