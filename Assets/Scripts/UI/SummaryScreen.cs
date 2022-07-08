using GameLib.UI;
using UnityEngine;

public class SummaryScreen : MonoBehaviour
{
    [SerializeField] private UIPanel _failPanel;
    [SerializeField] private UIPanel _winPanel;
    [SerializeField] private UIPanel _kingPanel;


    public void OpenPanel(Answer answer)
    {
        switch(answer)
        {
            case Answer.Fail:
                LevelFail();
                break;
            case Answer.Win:
                LevelWin();
                break;
            case Answer.King:
                LevelKing();
                break;
        }
    }

    private void LevelFail()
    {
        _failPanel.ActivatePanel();
    }

    private void LevelWin()
    {
        _winPanel.ActivatePanel();
    }

    private void LevelKing()
    {
        _kingPanel.ActivatePanel();
    }

    public void DeactivateAllPanel()
    {
        _failPanel.DeactivatePanel();
        _winPanel.DeactivatePanel();
        _kingPanel.DeactivatePanel();
    }
}
