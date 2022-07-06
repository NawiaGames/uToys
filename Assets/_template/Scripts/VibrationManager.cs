using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib.Haptics;

namespace TemplateProject
{
    public class VibrationManager : HapticsManager
    {
        [SerializeField] HapticsPreset defaultVibrationPreset = null;

        private void OnEnable()
        {
            DefaultBall.onHit += TriggerVibration;    
        }
        private void OnDisable()
        {
            DefaultBall.onHit -= TriggerVibration;                
        }
        
        void TriggerVibration(object sender) => HapticsSystem.Vibrate(defaultVibrationPreset);
    }
}
