using UnityEngine;

public class ManagerUIPanel : MonoBehaviour
{
    [SerializeField] private SummaryScreen summaryScreen;

    public void OpenPanelResult(Answer answer)
    {
        summaryScreen.gameObject.SetActive(true);
        summaryScreen.OpenPanel(answer);
    }
}
