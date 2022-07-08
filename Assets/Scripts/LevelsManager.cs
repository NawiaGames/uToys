using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private Level[] _levels;

    private Level[] _levelsContainer;

    public Level[] LevelsContainer => _levelsContainer;

    private void Awake()
    {
        InitializationLevel();
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
