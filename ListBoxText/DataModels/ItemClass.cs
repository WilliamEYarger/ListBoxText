using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListBoxText.DataModels;

namespace ListBoxText
{
    /// <summary>
    /// This class creates and manages an ItemObject
    /// Each object of the class is created with the parent object's ID,
    /// the parent Objects number of children
    /// an alpha number which is used to create the ID
    /// and a string entered by the user which will help displat the item in a listbox
    /// </summary>
    public class ItemObject
    {
        //LOCAL FIELDS

        /// <summary>
        /// ParentID is an alpha number equivalent where
        /// 0 = a, 1 = b ...
        /// </summary>
        string ParentId;

        /// <summary>
        /// The number of children of this item's parent
        /// </summary>
        int ParentNumberOfChildren;

        /// <summary>
        /// The identifying text typed in by the user which will appear in a ListBox
        /// </summary>
        string ItemText;

     
        /// <summary>
        /// The alphanumber ID for this item
        /// </summary>
        string ThisItemID;

        int ItemsNumberOfChildren;

        string ItemsDataString;

        //CONSTRUCTOR

        /// <summary>
        /// Constructor create a new item whose ItemID will be calculated from
        /// the parent's ID, the parent's number of chidren and alpha number
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="parentNumberOfChildren"></param>
        /// <param name="thisItemText"></param>
        public ItemObject(string parentID, int parentNumberOfChildren,  string thisItemText)
        {
            this.ParentId = parentID;
            this.ParentNumberOfChildren = parentNumberOfChildren;
            ItemText = thisItemText;
            // Create this items alpha ID number
            ThisItemID = parentID+returnItemAlphaNumber();
            //  create the string to show in the list boxes for this item
            ThisItemsListString = returnItemListString();
            this.ItemsDataString = "";
            this.ItemsNumberOfChildren = 0;
            addItemToDictionary();


        }

        


        //PROPERTIES

        //The number on children of this item initially 0 on creation
        public int CurrentItemsNumberOfChildren { get; set; } = 0;       

        /// <summary>
        /// AlphaBase is the base of the alpha numberind system if base 1 then
        /// 26 items per lever if 2 676 items per level etc
        /// This Number will be stored is the data file and 
        /// updated when the calling program opens the data
        /// files
        /// </summary>
        private int alphaBase =1;

        public int AlphaBase
        {
            get { return alphaBase; }
            set { alphaBase = value; }
        }


        /// <summary>
        /// This is the string that will appear in a ListBox
        /// "- This is the ites's Name ...^Item'sID^Items number of children"
        /// It will be called by the calling program to provide a string
        /// to displah in a ListB ox
        /// </summary>
        public string ThisItemsListString { get; }



        /// <summary>
        /// This string will be used to store other delimited 
        /// data such as url's, hyperlinks etc associated with 
        /// this data item
        /// </summary>
        private string thisItemsDataString;

        public string ThisItemsDataString
        {
            get { return thisItemsDataString; }
            set { thisItemsDataString = value; }
        }


        //PRIVATE METHODS

        /// <summary>
        /// The item's ID is determined by calculating its alpha child number equivalesn and 
        /// appending it to the parent's ID
        /// </summary>
        /// <returns></returns>
        private string returnItemAlphaNumber()
        {
            string itemID = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int numberOfThisChild = ParentNumberOfChildren;
            switch (AlphaBase)
            {
                //a single letter
                case 1:
                    itemID =alphabet[numberOfThisChild].ToString();
                    break;
                // two letters
                case 2:
                    int firstLetterInt = numberOfThisChild / 26;
                    int secondLetterInt = numberOfThisChild % 26;
                    itemID = alphabet[firstLetterInt].ToString() + alphabet[secondLetterInt].ToString();
                    break;
            }
            return itemID;
        }


        /// <summary>
        /// Creates the string to display in ListBoxes
        /// the Leading character is a + or minus indicating whether this item has children or not
        /// The Text typed by the user appears next expanded to fill 100 charahcters so that the 
        /// remainder of the stirng does not show
        /// it then contains 2 '^' delimited items
        /// the Item's ID and the items number of children
        /// </summary>
        /// <returns></returns>
        private string returnItemListString()
        {
            string thisItemsListString;
            if (CurrentItemsNumberOfChildren > 0)
            {
                thisItemsListString = "+ ";
            }
            else
            {
                thisItemsListString = "- ";
            }
            int LengthOFItemText = ItemText.Length;
            int addSpacesNumber = 100 - LengthOFItemText;
            string spacesString = new string(' ', addSpacesNumber);
            thisItemsListString = thisItemsListString  + ' ' + ItemText + addSpacesNumber + '^' + ThisItemID + '^' + CurrentItemsNumberOfChildren.ToString();            

            return thisItemsListString;
        }

        private void sendItemToItemDictionary()
        {
            // Items in string array: itemID, ItemText, AlphaBase, NumberOfChildrenString, delimitedDataString

            string[] itemStringArray = { ThisItemID, ItemText, AlphaBase.ToString(), ItemsNumberOfChildren.ToString(), ItemsDataString };
        
        }

        private void addItemToDictionary()
        {
            Subjects.AddItemToDictionary(ThisItemID, this);
        }

    }// End class
}
