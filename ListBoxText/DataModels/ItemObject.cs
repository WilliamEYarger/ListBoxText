using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ListBoxText.DataModels
{
    /// <summary>
    /// This Class will have a default constructor and 
    /// all of its properties will be set by calling the appropriate methods
    /// PROPERTIED: LeedChar, ItemText, ItemId, ParentsID, ItemsNumberOfChildren, ParentsNumberOfChildren,
    /// DisplayString, DataString, IsTerminalBool, AlphaBase, ItemsListString
    /// 
    /// </summary>
    public class ItemObject
    {
        //PROPERTIES
        private char leedChar = '-';
        public char LeedChar
        {
            get { return leedChar; }
            set { leedChar = value; }
        }

        private string itemText = null;
        public string ItemText
        {
            get { return itemText; }
            set { itemText = value; }
        }

        private string itemId = null;
        public string ItemId
        {
            get 
            {

                return itemId;
                //if(ItemsNumberOfChildren >= 0 && ParentsNumberOfChildren >= 0)
                //{
                //    string tempID = returnItemAlphaNumber();
                //    return ParentsID + tempID;
                //}
                //else
                //{
                //    MessageBox.Show("You cannot get the items ID until you have enetered the ParentsID and the Items number of Children");
                //    return "";
                //}

            }
            set { itemId = value; }
        }

        private string parentsID = "";
        public string ParentsID
        {
            get { return parentsID; }
            set { parentsID = value; }
        }

        private int itemsNumberOfChildren =-1;
        public int ItemsNumberOfChildren
        {
            get { return itemsNumberOfChildren; }
            set { itemsNumberOfChildren = value; }
        }

        private int parentsNumberOfChildren =-1;
        public int ParentsNumberOfChildren
        {
            get { return parentsNumberOfChildren; }
            set { parentsNumberOfChildren = value; }
        }

        private string displayString;
        /// <summary>
        /// The display string consists of: the LeedChar, the ItemText expanded to 100 characters, the ItemID 
        /// and the ItemsNumberOfChildren ToString
        /// </summary>

        public string DisplayString
        {
            get
            {  if(ItemText != null && ItemId != null && ItemsNumberOfChildren >= 0)
                {
                    displayString = "";
                    // change ItemText so that it is 100 characters long
                    int LengthOFItemText = ItemText.Length;
                    int addSpacesNumber = 100 - LengthOFItemText;
                    string spacesString = new string(' ', addSpacesNumber);
                    ItemText = ItemText + spacesString;
                    // Create the ItemId
                   
                    displayString = LeedChar+" "+ ItemText + '^' + ItemId + '^' + ItemsNumberOfChildren.ToString();
                    return displayString;
                }
                else
                {
                    MessageBox.Show("You cannot get the display string until you have set the " +
                        "leeding character, the items text and the item's number of children");
                    return displayString;
                }
            }
            set { displayString = value; }
        }

        private string dataString;
        public string DataString
        {
            get { return dataString; }
            set { dataString = value; }
        }

        private bool isTerminalBool;
        public bool IsTerminalBool
        {
            get { return isTerminalBool; }
            set { isTerminalBool = value; }
        }

        private int alphaBase = 1;
        public int AlphaBase
        {
            get { return alphaBase; }
            set { alphaBase = value; }
        }

       



        /// <summary>
        /// The item's ID is determined by calculating its alpha child number equivalesn and 
        /// appending it to the parent's ID
        /// </summary>
        /// <returns></returns>
        //private string returnItemAlphaNumber()
        //{
        //    string itemID = "";
        //    string alphabet = "abcdefghijklmnopqrstuvwxyz";
        //    int numberOfThisChild = ParentsNumberOfChildren;
        //    switch (AlphaBase)
        //    {
        //        //a single letter
        //        case 1:
        //            itemID = alphabet[numberOfThisChild].ToString();
        //            break;
        //        // two letters
        //        case 2:
        //            int firstLetterInt = numberOfThisChild / 26;
        //            int secondLetterInt = numberOfThisChild % 26;
        //            itemID = alphabet[firstLetterInt].ToString() + alphabet[secondLetterInt].ToString();
        //            break;
        //    }
        //    return itemID;
        //}




    }
}
