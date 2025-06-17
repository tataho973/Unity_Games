using System;
using LTX.Singletons;
using UnityEngine;

namespace Taho.Game
{
    public class ScoreSystem : MonoSingleton<ScoreSystem>
    {
        public GameObject endPanel;
        
        private int score;
        
        private void OnEnable()
        {
            CubeEntityManager.Instance.OnCubeEntityCleared += CubeCleared;
        }
        private void OnDisable()
        {
            CubeEntityManager.Instance.OnCubeEntityCleared -= CubeCleared;
        }
        
        public void CubeClicked(CubeEntity cube, int CubScore)
        {
            score += CubScore;
            Debug.Log($"Cube clicked! Score: {score}");
        }
        
        private void CubeCleared()
        {
            endPanel.SetActive(true);
        }
    }
}