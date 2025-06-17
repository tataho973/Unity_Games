using UnityEngine;
using UnityEngine.EventSystems;

namespace Taho.Poussetheet
{
    public class Plante : MonoBehaviour, IPointerDownHandler
    {
        public PlanteData Data;
        public SpriteRenderer SR;

        public bool IsHarvestable => growthStage >= Data.MaxGrowthStage && !IsHarvested;
        public bool IsHarvested;

        private int growthStage;
        private float currentTimer;

        private void Awake()
        {
            UpdateSprite();
        }

        private void Update()
        {
            SR.color = IsHarvestable ? Color.green : Color.white;
            
            currentTimer += Time.deltaTime + Random.Range(-0.02f, 0.02f);
            if (currentTimer >= Data.GrowthTime && !IsHarvested)
            {
                //Debug.Log($"Growing plant: {name} => {currentTimer}");
                currentTimer = 0f;
                Grow();
            }
        }

        private void Grow()
        {
            if (!IsHarvestable)
            {
                growthStage++;
                UpdateSprite();
            }
        }

        private void UpdateSprite()
        {
            SR.sprite = Data.GrowthSprites[growthStage];
        }

        public bool TryToHarvest()
        {
            if (IsHarvestable)
            {
                IsHarvested = true;
                SR.sprite = Data.HarvestedSprite;
                Destroy(gameObject, 2f);
                return true;
            }

            return false; 
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            bool success = TryToHarvest();
        }
    }
}