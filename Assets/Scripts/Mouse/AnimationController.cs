using System;
using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private TrainController _trainController;
    [SerializeField] private LevelsCreate _levelsCreate;
    [SerializeField] private ManagerUIPanel _managerUIPanel;
    [SerializeField] private CreatorLevelq _creatorLevelq;
    [SerializeField] private float _timaWaitPhysics = 3f;

    private const string AnimationA = "TriggerA";
    private const string AnimationB = "TriggerB";
    private const string AnimationC = "TriggerC";

    private const string AnimationWin = "Win";
    private const string AnimationFail = "Fail";
    
    public static bool IsPlayingAnimation = true;

    public void StartAnimationEndLevel(SelectObject selectObject, FollowerPath trainPath)
    {
        trainPath.StartMoveTrain();
        StopAllCoroutines();
        StartCoroutine(WaitTrainPath(selectObject, trainPath));
    }

    private IEnumerator WaitTrainPath(SelectObject selectObject, FollowerPath trainPath)
    {
        while (!trainPath.IsEndPath)
        {
            yield return null;
        }

        if (selectObject.IsPlayPhysics)
        {
            trainPath.ParticleSystemSmoke.Stop();
            trainPath.FallTrain.Fall();
            yield return new WaitForSeconds(_timaWaitPhysics);
            StartCoroutine(OpenSummaryScreen(selectObject, true));
            yield break;
        }

        if (_levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator == null)
            yield break;

        switch (selectObject.Answer)
        {
            case Answer.Fail:
                _levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator.SetTrigger(AnimationA);
                break;
            case Answer.Win:
                _levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator.SetTrigger(AnimationB);
                break;
            case Answer.King:
                _levelsCreate.LevelsContainer[LevelsLoad.CurrentLevel].Animator.SetTrigger(AnimationC);
                break;
            default:
                yield break;
        }

        StartCoroutine(OpenSummaryScreen(selectObject, false, trainPath));
    }

    private IEnumerator OpenSummaryScreen(SelectObject selectObject, bool isPhysics = false,
        FollowerPath trainPath = null)
    {
        if (!isPhysics)
        {
            IsPlayingAnimation = true;
            while (IsPlayingAnimation)
            {
                yield return null;
            }
        }

        trainPath?.ParticleSystemSmoke.Stop();
        _managerUIPanel.OpenPanelSummary(selectObject.Answer);
    }

    public void StartAnimation(SelectObject selectObject)
    {
        StopAllCoroutines();
        StartCoroutine(WaitEndAnimation(selectObject));
    }

    private IEnumerator WaitEndAnimation(SelectObject selectObject)
    {
        IsPlayingAnimation = true; 
        Debug.Log("start animation");
        
        switch (selectObject.Answer)
        {
            case Answer.Fail:
                _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].Animator.SetTrigger(AnimationFail);
                break;
            case Answer.Win:
                _creatorLevelq.Levelqs[MoveTrain.IndexCurrentPath].Animator.SetTrigger(AnimationWin);
                break;
            case Answer.King:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        while (IsPlayingAnimation)
        {
            yield return null;
        }
        
        _trainController.MoveTrain.StartTrain();
        _trainController.DisableCameraLevel();
        
        if (selectObject.Answer == Answer.Fail)
            _trainController.DeleteLastWagon();
    }
}