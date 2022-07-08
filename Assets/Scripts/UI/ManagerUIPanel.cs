using UnityEngine;

public class ManagerUIPanel : MonoBehaviour
{
    [SerializeField] private SummaryScreen _summaryScreen;

    public void OpenPanelSummary(Answer answer)
    {
        _summaryScreen.gameObject.SetActive(true);
        _summaryScreen.OpenPanel(answer);
    }

    public void ClosePanelSummary() => _summaryScreen.DeactivateAllPanel(); 
}
