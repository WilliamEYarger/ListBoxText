using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ListBoxText.DataModels
{
    public static class Subjects
    {
        /// <summary>
        /// Stores the number of root subjects
        /// </summary>
         public static int NumberOfRoots { get; set; } = 0;

        public static Dictionary<string, ItemObject> ItemObjectDictionary = new Dictionary<string, ItemObject>();

        public static void AddItemToDictionary(string itemID, ItemObject newItemObject) => ItemObjectDictionary.Add(itemID, newItemObject);

        public static void UpdateDictionaryItem(string itemID, ItemObject newItemObject)
        {
            ItemObjectDictionary[itemID] = newItemObject;
        }


        public static ItemObject ReturnSelectedItemObject(string ItemName)
        {
            return ItemObjectDictionary[ItemName];
        }

    }
}
