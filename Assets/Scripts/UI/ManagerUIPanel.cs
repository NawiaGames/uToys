using UnityEngine;

public class ManagerUIPanel : MonoBehaviour
{
    [SerializeField] private PanelResult _panelResult;

    public void OpenPanelResult(Answer answer)
    {
        _panelResult.gameObject.SetActive(true);
        _panelResult.OpenPanel(answer);
    }
}
