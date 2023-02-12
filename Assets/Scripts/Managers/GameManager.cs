using System;
using UnityEngine;


namespace TestTask
{
    public class GameManager : MonoBehaviour
    {
        public static event Action GamePlayStarted;
        public static event Action GameLosed;




        private void OnEnable()
        {
            Picture.LevelBuilded += StartGameplay;
            ExitZone.OnExitZoneEntered += GameLose;
        }
        private void OnDisable()
        {
            Picture.LevelBuilded -= StartGameplay;
            ExitZone.OnExitZoneEntered -= GameLose;
        }

        private void StartGameplay()
        {
            GamePlayStarted?.Invoke();
        }
        private void GameLose()
        {
            GameLosed?.Invoke();
        }
    }
}

