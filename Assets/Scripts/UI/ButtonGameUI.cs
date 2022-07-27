using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameUI : MonoBehaviour
{
    [SerializeField] private ManagerUIPanel _managerUIPanel;
    
    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}