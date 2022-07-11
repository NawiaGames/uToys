using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _panelDebugMenu;
    [SerializeField] private ManagerUIPanel _managerUIPanel; 
    [SerializeField] private LevelsLoad _levelsLoad;

    private bool _isOpenDebugMenu;

    public void OnEnableDebugMenu()
    {
        _isOpenDebugMenu = !_isOpenDebugMenu; 
        _panelDebugMenu.SetActive(_isOpenDebugMenu);
    }
    
    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    [ContextMenu("ResetCurrentLevel")]
    public void ResetCurrentLevel()
    {
        _levelsLoad.ResetCurrentLevel(); 
        _managerUIPanel.ClosePanelSummary();
    }

    [ContextMenu("NextLevel")]
    public void NextLevel()
    {
        _levelsLoad.LoadNextLevel();
        _managerUIPanel.ClosePanelSummary();
    }

    public void ActivateLevelPanel() => _managerUIPanel.LevelPanel.ActivatePanel();

    public void DeactivateLevelPanel() => _managerUIPanel.LevelPanel.DeactivatePanel(); 
    
}
