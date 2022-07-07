using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _panelDebugMenu;

    private bool _isOpenDebugMenu;

    public void OnEnableDebugMenu()
    {
        _isOpenDebugMenu = !_isOpenDebugMenu; 
        _panelDebugMenu.SetActive(_isOpenDebugMenu);
    }
    
    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}
