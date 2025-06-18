using TMPro;
using UnityEngine;

namespace Plant_Grow
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text planteText;
        
        private void OnEnable()
        {
            Player.Instance.Inventory.OnItemAdded += OnItemAdded;
        }

        private void OnDisable()
        {
            Player.Instance.Inventory.OnItemAdded -= OnItemAdded;
        }
        
        private void OnItemAdded (ItemType itemType, int count)
        {
            UpdateText(count);
        }

        private void UpdateText(int count)
        {
            planteText.text = "Plante : " + count;
        }
    }
}
