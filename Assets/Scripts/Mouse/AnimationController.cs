using System;
using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private TrainController _trainController;

    private CreatorLevel _creatorLevel;
    private const string AnimationWin = "Win";
    private const string AnimationFail = "Fail";
    
    public static bool IsPlayingAnimation = true;

    public void SetCreatorLevel(CreatorLevel creatorLevel) => _creatorLevel = creatorLevel; 

    public void StartAnimation(SelectObject selectObject)
    {
        StopAllCoroutines();
        StartCoroutine(WaitEndAnimation(selectObject));
    }

    private IEnumerator WaitEndAnimation(SelectObject selectObject)
    {
        IsPlayingAnimation = true; 
   //     Debug.Log("Start animation");
        
        switch (selectObject.Answer)
        {
            case Answer.Fail:
                _creatorLevel.Levels[MoveTrain.IndexCurrentPath].Animator.SetTrigger(AnimationFail);
                break;
            case Answer.Win:
                _creatorLevel.Levels[MoveTrain.IndexCurrentPath].Animator.SetTrigger(AnimationWin);
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
        
        _trainController.EndLevel();
    }
}