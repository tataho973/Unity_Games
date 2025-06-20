using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plant_Grow
{
    public class Plante : MonoBehaviour, IPointerDownHandler
    {
        [ SerializeField] private PlanteData Data;
        [ SerializeField] private SpriteRenderer SR;
        [ SerializeField] private SpriteRenderer Outline; 
        
        public bool IsHarvestable => growthStage >= Data.MaxGrowthStage && !IsHarvested;
        public bool IsHarvested;

        private int growthStage;
        private float currentTimer;

        public void Initialize()
        {
            UpdateSprite();
        }

        public void Refresh()
        {
            currentTimer += Time.deltaTime;// + Random.Range(-0.02f, 0.02f);
            if (currentTimer >= Data.GrowthTime && !IsHarvestable && !IsHarvested)
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
            if (IsHarvestable)
            {
                Outline.DOFade(1f, 0.6f).SetLoops(-1, LoopType.Yoyo);
                Outline.gameObject.SetActive(true); 
            }
        }

        private void UpdateSprite()
        {
            SR.sprite = Data.GrowthSprites[growthStage];
        }

        /// <summary>
        /// fonction appelé p récuperer plante (click du joueur)
        /// </summary>
        /// <returns>si il a réussi à récupérer</returns>
        public bool TryToHarvest()
        {
            if (IsHarvestable)
            {
                IsHarvested = true;
                SR.sprite = Data.HarvestedSprite;
                Destroy(gameObject, 2f);
                Outline.gameObject.SetActive(false);
                Player.Instance.Inventory.AddItem(Data.ItemType, 1 );
                return true;
            }

            return false; 
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            bool success = TryToHarvest();
        }

        private void OnDestroy()
        {
            Outline.DOKill();
        }
    } 
}