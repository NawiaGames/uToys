using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TemplateProject
{
    public class EffectsManagerConfetti : MonoBehaviour
    {
        [SerializeField] ParticleSystem confetti = null;
        private void OnEnable()
        {   
            GameplayController.onStateExited += PlayGameSummaryFX;
        }
        private void OnDisable()
        {
            GameplayController.onStateExited -= PlayGameSummaryFX;
        }    
        void PlayGameSummaryFX(MonoBehaviour sender) => confetti.Play();

    }
}