using UnityEngine;

[RequireComponent(typeof(LevelsCreate))]
public class LevelsLoad : MonoBehaviour
{
    [SerializeField] private int _currentLevel = 0;
    [SerializeField] private Tutorial _tutorial;

    private LevelsCreate _levelsCreate;

    public static int CurrentLevel = 0;

    private void Awake()
    {
        CurrentLevel = _currentLevel;
    }

    private void Start()
    {
        _levelsCreate = GetComponent<LevelsCreate>();
        ActivateLevel(_currentLevel);
    }

    private void ActivateLevel(int index)
    {
        var levels = _levelsCreate.LevelsContainer;

        if (index >= levels.Length)
            index = 0;

        for (var i = 0; i < levels.Length; i++)
            levels[i].gameObject.SetActive(i == index);

        _currentLevel = index;
        CurrentLevel = _currentLevel;
        ResetCurrentLevel();

        if (_currentLevel == 0)
            ActivateTutorial();
    }

    public void ResetCurrentLevel()
    {
        _levelsCreate.LevelsContainer[_currentLevel].SelectObjects.ResetObject();
        _levelsCreate.LevelsContainer[_currentLevel].Platform.SetIsEmpty(true);
        _levelsCreate.LevelsContainer[_currentLevel].FollowerPath.ResetTrain();
    }

    public void LoadNextLevel()
    {
        ActivateLevel(_currentLevel + 1);
    }

    public void LoadIndexLevel(int index)
    {
        ActivateLevel(index);
    }

    private void ActivateTutorial()
    {
        var objects = _levelsCreate.LevelsContainer[_currentLevel].SelectObjects.SelectObjectsGame;
        var positions = new Vector3[objects.Length];
        for (var i = 0; i < positions.Length; i++)
            positions[i] = objects[i].transform.position;
        var positionDragDrop = _levelsCreate.LevelsContainer[_currentLevel].FollowerPath.GetVector3EndPath();
        _tutorial.StartTutorial(positions, positionDragDrop);
    }
}