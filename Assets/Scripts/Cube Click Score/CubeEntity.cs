using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace Taho.Game
{
    public class CubeEntity : MonoBehaviour, IPointerDownHandler
    {
        private void Awake()
        {
            CubeEntityManager.Instance.AddCubeEntity(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            int score = Random.Range(1, 29);
            ScoreSystem.Instance.CubeClicked(this, score);
            
            CubeEntityManager.Instance.RemoveCubeEntity(this);
        }
    }
}