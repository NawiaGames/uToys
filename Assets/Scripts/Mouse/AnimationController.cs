using System;
using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private TrainController _trainController;
    [SerializeField] private CreatorLevelq _creatorLevelq;

    private const string AnimationWin = "Win";
    private const string AnimationFail = "Fail";
    
    public static bool IsPlayingAnimation = true;
    

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
        _trainController.EndLevel();
        
        if (selectObject.Answer == Answer.Fail)
            _trainController.DeleteLastWagon();
    }
}