using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameLib;
using GameLib.FSM;
using GameLib.InputSystem;

namespace TemplateProject
{
    public class GameplayController : GameState
    {
        public static System.Action<GameplayController> onGameLoaded, onGameplayStarted, onGameplayEnded;
        ActivatableObject[] GetActivatableObjects() => GetComponentsInChildren<ActivatableObject>();
        bool AnySubSystemIsProcessing() => GetComponentsInChildren<GameSystem>().Any(x => x.IsProcessing);
        GameSystem[] subSystems = new GameSystem[]{};
        

        [Header("Input")]
        [SerializeField] float inputDetectionRange = 1f;

        [Header("Systems")]
        [SerializeField] LevelManager levelManager = null;
        [SerializeField] int levelSpawnAnimationStep = 4;
        public Vector3[] GetLevelSize() => levelManager.GetLevelSize();


        [SerializeField] Vector2Int boardWidthRange = new Vector2Int(2,6);
        [SerializeField] Vector2Int boardHeightRange = new Vector2Int(2,6); 


        private void Awake() {
            
        }

        private void OnEnable()
        {
            TouchInputData.onInputEnded += ProcessInputEnd;
        }

        private void OnDisable()
        {
            TouchInputData.onInputEnded -= ProcessInputEnd;            
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.R)) this.EvaluateState();
        }

        void ProcessInputEnd(TouchInputData inputData)
        {
            inputData.GetClosestObjectInRange<DefaultBall>(inputDetectionRange)?.Interact();
        }

        protected override IEnumerator EnterStateSequence()
        {
            yield return null;

            yield return new WaitWhile(() => IsProcessing);

            onGameLoaded?.Invoke(this);

            IsProcessing = true;
            subSystems = GetComponentsInChildren<GameSystem>();

            levelManager.SpawnBoard(boardWidthRange.GetRandomValueInRange(), boardHeightRange.GetRandomValueInRange());

            var activatableObjects = GetActivatableObjects();
            int objectIndex = 0;
            for (int i = 0; i < activatableObjects.Length; i+=levelSpawnAnimationStep)
            {
                for (int j = 0; j < levelSpawnAnimationStep; j++)
                {
                    objectIndex = i + j;
                    if (objectIndex >= activatableObjects.Length) break;
                    activatableObjects[objectIndex].ActivateObject();
                }
                yield return GameManager.defaultDelay;
            }

            yield return new WaitWhile(() => subSystems.Any(x => x.IsProcessing));
            Debug.Log("Game Started");

            IsProcessing = false;
            this.enabled = true;
            onGameplayStarted?.Invoke(this);
        }
        protected override IEnumerator ExitStateSequence()
        {
            yield return null;

            onGameplayEnded?.Invoke(this);

            this.enabled = false;
            IsProcessing = true;

            subSystems = GetComponentsInChildren<GameSystem>();

            var activatableObjects = GetActivatableObjects();
            int objectIndex = 0;
            for (int i = 0; i < activatableObjects.Length; i+=levelSpawnAnimationStep)
            {
                for (int j = 0; j < levelSpawnAnimationStep; j++)
                {
                    objectIndex = i + j;
                    if (objectIndex >= activatableObjects.Length) break;
                    activatableObjects[objectIndex].DeactivateObject();
                }
                yield return GameManager.defaultDelay;
            }
            yield return null;

            yield return new WaitWhile(() => subSystems.Any(x => x.IsProcessing));

            levelManager.ClearLevel();

            yield return new WaitForSeconds(1f);

            IsProcessing = false;
            Debug.Log("Game Ended");
        }
    }
}