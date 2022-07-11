using GameLib.UI;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private UIPanel _levels;
    [SerializeField] private LevelButton _buttonLevel;
    [SerializeField] private Transform _buttonsLevelTransform; 

    public void InitializePanel(int size)
    {
        for (var i = 0; i < size; i++)
        {
            CreateButtonLevel(i);
        }
    }

    private void CreateButtonLevel(int index)
    {
        var buttonLevel = Instantiate(_buttonLevel, _buttonsLevelTransform);
        buttonLevel.Text.text = (index + 1).ToString();
    }

    public void ActivatePanel() => _levels.ActivatePanel();

    public void DeactivatePanel() => _levels.DeactivatePanel(); 
}
