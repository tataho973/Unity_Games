using UnityEngine;

namespace Plant_Grow
{
    [CreateAssetMenu(fileName = "PlanteData", menuName = "ScriptableObjects/PlanteData", order = 1)]
    public class PlanteData : ScriptableObject
    {
        public Sprite[] GrowthSprites;

        public Sprite HarvestedSprite;

        public float GrowthTime = 3.5f;

        public int MaxGrowthStage = 2;

        public Plante PlantePrefab;
        [field: SerializeField] public ItemType ItemType { get; private set; }
    }
}