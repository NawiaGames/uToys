using UnityEngine;

public class ManagerUIPanel : MonoBehaviour
{
    [SerializeField] private SummaryScreen _summaryScreen;
    [SerializeField] private LevelPanel _levelPanel;

    public LevelPanel LevelPanel => _levelPanel; 

    public void OpenPanelSummary(Answer answer)
    {
        _summaryScreen.OpenPanel(answer);
    }

    public void ClosePanelSummary() => _summaryScreen.DeactivateAllPanel(); 
}
