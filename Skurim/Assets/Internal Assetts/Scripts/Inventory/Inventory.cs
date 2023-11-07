using System.Collections.Generic;
using UnityEngine;




public class Inventory : MonoBehaviour
{

    public List<ItemModel> items = new();
    public void AddItem(ItemModel ItemToAdd)
    {
        items.Add(ItemToAdd);
    }
    public void RemoveItem(ItemModel ItemToRemove)
    {
        items.Remove(ItemToRemove);
    }

}

