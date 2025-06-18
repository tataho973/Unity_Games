using System;
using System.Collections.Generic;

namespace Plant_Grow
{
    public class Inventory
    {
        private readonly Dictionary<ItemType, int> items;
        
        /// <summary>
        /// ItemType = le type de l'item | int = quantité ajouté
        /// </summary>
        public event Action<ItemType, int> OnItemAdded; 
        /// <summary>
        /// ItemType = le type de l'item
        /// int = quantité enlevé
        /// </summary>
        public event Action<ItemType, int> OnItemRemoved;
        
        /// <summary>
        /// Constructeur de Inventory
        /// </summary>
        /// <param name="baseItems"></param>
        public Inventory(Dictionary<ItemType, int> baseItems = null)
        {
            // ?? => if null alors fait ça ...
            items = baseItems ?? new Dictionary<ItemType, int>();
        }

        /// <summary>
        /// Ajout d'un certain ItemType et appelle l'event Ajout
        /// </summary>
        /// <param name="item"> Le type de l'item à ajouter</param>
        /// <param name="amount"> Le nombre d'item à ajouter</param>
        public void AddItem(ItemType item, int amount)
        {
            if (!items.TryAdd(item, amount))
            {
                items[item] += amount;
            }

            OnItemAdded?.Invoke(item, items[item]);
        }

        /// <summary>
        /// Enlève un certain ItemType et appelle l'event Enlève
        /// </summary>
        /// <param name="item"> Le type de l'item à enlever</param>
        /// <param name="amount"> Le nombre d'item à enlever</param>
        public void RemoveItem(ItemType item, int amount)
        {
            if (items.ContainsKey(item))
            {
                if (items[item] > 0)
                    items[item]--;
            }
            
            OnItemRemoved?.Invoke(item, items[item]);
        }
    }

    [System.Serializable]
    public enum ItemType
    {
        Plante
    }
}