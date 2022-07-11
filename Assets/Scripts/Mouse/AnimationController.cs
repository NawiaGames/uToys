using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private LevelsCreate _levelsCreate;
    [SerializeField] private ManagerUIPanel _managerUIPanel;
    private const string AnimationA = "TriggerA";
    private const string AnimationB = "TriggerB";
    private const string AnimationC = "TriggerC";

    public static bool IsPlayingAnimation = true; 

    public void StartAnimationEndLevel(SelectObject selectObject)
    {
        if (_levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator == null)
            return;
        switch (selectObject.Answer)
        {
            case Answer.Fail:
                _levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator.SetTrigger("TriggerA");
                break;
            case Answer.Win:
                _levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator.SetTrigger("TriggerB");
                break;
            case Answer.King:
                _levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator.SetTrigger("TriggerC");
                break;
            default:
                return;
        }

        StopAllCoroutines();
        StartCoroutine(OpenSummaryScreen(selectObject));
    }

    private IEnumerator OpenSummaryScreen(SelectObject selectObject)
    {
        IsPlayingAnimation = true;
        while (IsPlayingAnimation)
        {
            yield return null;
        }
        
        _managerUIPanel.OpenPanelSummary(selectObject.Answer);
    }
}