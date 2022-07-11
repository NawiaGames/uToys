using GameLib.UI;
using UnityEngine;
using UnityEngine.Events;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private ButtonGameUI _buttonGameUI; 
    [SerializeField] private UIPanel _levels;
    [Header("Button level")]
    [SerializeField] private LevelButton _buttonLevel;
    [SerializeField] private Transform _buttonsLevelTransform;

    private UnityAction _buttonCallback; 

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
        _buttonCallback = null;
        _buttonCallback = () => _buttonGameUI.LoadIndexLevel(index); 
        buttonLevel.Button.onClick.AddListener(_buttonCallback);
    }

    public void ActivatePanel() => _levels.ActivatePanel();

    public void DeactivatePanel() => _levels.DeactivatePanel(); 
}
