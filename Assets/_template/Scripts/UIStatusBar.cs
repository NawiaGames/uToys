using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameLib.FSM;
using GameLib.UI;

namespace TemplateProject
{
    public class UIStatusBar : MonoBehaviour
    {
        UIPanel uiPanel;
        [SerializeField] Button restartLevelButton = null;
        [SerializeField] Button pauseButton = null;

        private void Awake()
        {
            uiPanel = GetComponent<UIPanel>();
            GameplayController.onGameplayStarted += ActivateHUD;  
            GameplayController.onGameplayEnded += DeactivateHUD;    
        }
        private void OnDestroy()
        {
            GameplayController.onGameplayStarted -= ActivateHUD;                
        }
        private void OnEnable()
        {
            restartLevelButton.onClick.AddListener(RestartGame);
            pauseButton.onClick.AddListener(PauseGame);
        }
        private void OnDisable()
        {
            restartLevelButton.onClick.RemoveListener(RestartGame);    
            pauseButton.onClick.RemoveListener(PauseGame);

        }
        void ActivateHUD(object sender) => uiPanel.ActivatePanel();
        void DeactivateHUD(object sender) => uiPanel.DeactivatePanel();
        public void RestartGame()
        {
            GameManager.Instance.ActiveGameState?.EvaluateState();
        }
        public void PauseGame()
        {
            GameManager.Instance.TogglePause(!Mathf.Approximately(Time.timeScale, 0f));
        }
    }
}
