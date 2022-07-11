using UnityEngine;

public class LevelsCreate : MonoBehaviour
{
    [SerializeField] private Level[] _levels;
    [SerializeField] private ManagerUIPanel _managerUIPanel; 

    private Level[] _levelsContainer;

    public Level[] LevelsContainer => _levelsContainer;

    private void Awake()
    {
        InitializationLevel();
        _managerUIPanel.LevelPanel.InitializePanel(_levels.Length);
    }

    private void InitializationLevel()
    {
        var size = _levels.Length;
        _levelsContainer = new Level[size];
        
        for (var i = 0; i < size; i++)
        {
            _levelsContainer[i] = Instantiate(_levels[i], gameObject.transform);
            _levelsContainer[i].gameObject.SetActive(false);
        }
    }
}
