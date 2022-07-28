using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameUI : MonoBehaviour
{
    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}