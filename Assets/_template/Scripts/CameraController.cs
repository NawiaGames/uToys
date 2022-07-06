using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib.Utilities;
using GameLib.CameraSystem; 

namespace TemplateProject
{
    public class CameraController : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField] CameraAutoTracker cameraFitter = null;
        [Header("Camera Shake")]
        [SerializeField] ObjectShake shakeController = null;
        [SerializeField] ObjectShakePreset defaultShakePreset = null;
        private void OnEnable()
        {
            GameplayController.onGameLoaded += FitCamera;
            GameplayController.onGameplayEnded += TriggerCameraShake;
            DefaultBall.onHit += TriggerCameraShake;
        }
        private void OnDisable()
        {
            GameplayController.onGameLoaded -= FitCamera;
            GameplayController.onGameplayEnded -= TriggerCameraShake;
            DefaultBall.onHit -= TriggerCameraShake;
        }
        void FitCamera(GameplayController sender)
        {
            Debug.Log("Fitting Camera!");
            cameraFitter.RecalculateCamera();
        }
        void TriggerCameraShake(object sender) => shakeController.Shake(defaultShakePreset);
    }
}