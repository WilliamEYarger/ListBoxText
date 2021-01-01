using ListBoxText.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ListBoxText.Helper_Methods;

namespace ListBoxText
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
        }

        //PRIVATE FIELDS

        string itemsDisplayString;

        private void Click_FileOpen(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open files");
        }

        private void Click_FileSave(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save files");
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_AddRootItem(object sender, RoutedEventArgs e)
        {
            // Get Text string from tbxItemText
            var ThisItemsParentNumberOfChildren = Subjects.NumberOfRoots;
            var ThisItemsText = tbxItemText.Text;
            ItemObject ThisRootObject = new ItemObject();
            ThisRootObject.LeedChar = '-';
            ThisRootObject.ItemText = ThisItemsText;
            ThisRootObject.ItemsNumberOfChildren = 0;
            int thisObjectsParentsNumberOfChildren = Subjects.NumberOfRoots;
            ThisRootObject.ParentsNumberOfChildren = thisObjectsParentsNumberOfChildren;
            var AlphaBase = ThisRootObject.AlphaBase;
            var thisObjectsID = DelimitedStringHelperClass.RetrunAlphaNumberString(thisObjectsParentsNumberOfChildren, AlphaBase);
            ThisRootObject.ItemId = thisObjectsID;
            string ThisChildItemsDisplayString = ThisRootObject.DisplayString;
            ThisRootObject.DisplayString = ThisChildItemsDisplayString;
            // Add this item to the dictionary
            Subjects.AddItemToDictionary(thisObjectsID, ThisRootObject);
            // update the number of roots
            var currentNumberOfRoots = Subjects.NumberOfRoots;
            currentNumberOfRoots += 1;
            Subjects.NumberOfRoots = currentNumberOfRoots;
            // add thisItemsDisplayString to lbxItems 
            lbxItems.Items.Add(ThisChildItemsDisplayString);
            tbxItemText.Text = "";
        }

        private void Click_AddChildItem(object sender, RoutedEventArgs e)
        {
            // Get text of selected item in Tree ListBox
            var ParentsDisplayString = lbxTree.SelectedItem.ToString();
            // Get ParentID
            var ParentID = DelimitedStringHelperClass.RetureItemAtPosition(ParentsDisplayString, '^', 1);
            // Get Parent oldItemObject
            ItemObject ParentItemObject = Subjects.ReturnSelectedItemObject(ParentID);
            // Get the current number of children on this parent object
            var ParentsNumberOfChildren = ParentItemObject.ItemsNumberOfChildren;
            // increment it to reflect this new child element
            var ParentsNewNumberOfChildren = ParentsNumberOfChildren+ 1;

            // Set the Terminal Char depending on wheter the Terminal check box is checxed of not
            char TerminalChar;
            if(ckbxTerminal.IsChecked == true)
            {
                TerminalChar = 'T';
            }
            else
            {
                TerminalChar = 'F';
            }

            // Create a new ChildObject of the Parent
            ItemObject ChildObject = new ItemObject();

            ChildObject.LeedChar = '-';

            ChildObject.ItemText = tbxItemText.Text;

            ChildObject.ItemsNumberOfChildren = 0;
            ChildObject.ParentsNumberOfChildren = ParentsNewNumberOfChildren;


            ChildObject.ParentsID = ParentID;
            var AlphaBase = ParentItemObject.AlphaBase;

            var thisChildsIDAlphaNumber = DelimitedStringHelperClass.RetrunAlphaNumberString(ParentsNumberOfChildren, AlphaBase);


            ChildObject.ItemId = ParentID + thisChildsIDAlphaNumber;

            

            var ThisChildItemsDisplayString = ChildObject.DisplayString;

            // Add this item to the dictionary
            Subjects.AddItemToDictionary(ChildObject.ItemId, ChildObject);


            // Get the display string of the child object
            var ChildListString = ChildObject.DisplayString;

            ChildObject.ParentsNumberOfChildren = ParentsNewNumberOfChildren;

            // Update the ParentObject number of Children
            ParentItemObject.ItemsNumberOfChildren = ParentsNewNumberOfChildren;

            // Update the Parents LeedCharacter
            ParentItemObject.LeedChar = '+';

            //Get the New Parents Dispaly string
            var NewParentsDisplayString = ParentItemObject.DisplayString;

            //A.  Rewrite lbxTree with revised item
            //A.1 create a string array of the items in the lbxTres
            var TreeItemsNumber = lbxTree.Items.Count;
            string[] TreeArray = new string[TreeItemsNumber];
            int TreeCntr = 0;
            int ThisTreeItemsIndex=-1;
            foreach(string displayString in lbxTree.Items)
            {
                TreeArray[TreeCntr] = displayString;
                // get ID in this display string
                var ThisItemID = DelimitedStringHelperClass.RetureItemAtPosition(displayString, '^', 1);
                if (ThisItemID == ParentID)
                {
                    ThisTreeItemsIndex = TreeCntr;
                    
                }
                TreeCntr += 1;
            }
            // Update the Dispaly string at ThisTreeItemsIndex
            TreeArray[ThisTreeItemsIndex] = NewParentsDisplayString;


            // Get the Revised ParentObject
            ParentItemObject = Subjects.ReturnSelectedItemObject(ParentID);

            // Get the Index of the selected item in the Tree List
            var selectedIndex = lbxTree.SelectedIndex;
            //Replace the String in the TreeListbox with the revised string
            string[] clist = lbxTree.Items.OfType<string>().ToArray();
           // clist[selectedIndex] = NewParentsListString;


            lbxTree.Items.Clear();
            foreach(string item in TreeArray)
            {
                lbxTree.Items.Add(item);
            }

            // Add new child to lbxItems
            lbxItems.Items.Add(ThisChildItemsDisplayString);
            // Clear tbxItems
            tbxItemText.Text = "";

        }// End Add Child

        private void Click_MoveToTree(object sender, RoutedEventArgs e)
        {

            //Get the text string of the selected item
            var itemText = lbxItems.SelectedItem.ToString();

            //extract its name = the 1th item in the ^ delimited string
            var ItemName = DelimitedStringHelperClass.RetureItemAtPosition(itemText, '^', 1);
            // Get the item object whose key = ItemName
            ItemObject SelectedItemObject = Subjects.ReturnSelectedItemObject(ItemName);
            // Get the AlphaBase of this item
            var AlphaBase = SelectedItemObject.AlphaBase;
            // Get the item's display string
            var ThisItemsDisplayString = SelectedItemObject.DisplayString;
           
            // Add this string to the tree ListBox
            lbxTree.Items.Add(ThisItemsDisplayString);
            //Create a string array of all items in the lbxTree
            string[] treeArray = new string[lbxTree.Items.Count];
            // add each item in the tree list to the array
            var treeArrayCounter = 0;
            foreach(string item in lbxTree.Items)
            {
                treeArray[treeArrayCounter] = item;
                treeArrayCounter += 1;
            }
            // Clear the tree list
            lbxTree.Items.Clear();
            // cycle thru the treeArray, adjusting its display string and adding it to the tree
            treeArrayCounter = 0;
            foreach (string itemString in treeArray)
            {
                string currentDisplayString = treeArray[treeArrayCounter];
                //get the ID in this string
                var ID = DelimitedStringHelperClass.RetureItemAtPosition(currentDisplayString, '^', 1);
                var IDLength = ID.Length;
                // Calculate length of header spacer
                var LengthHeaderSpacer = ((IDLength - 1) / SelectedItemObject.AlphaBase) * 2;
                // Create Header Spacer
                string HeaderSpacer = new string(' ', LengthHeaderSpacer);
                // Placde HeaderSpacder at front of ThisItemsDisplayString
                currentDisplayString = HeaderSpacer + currentDisplayString;
                treeArrayCounter += 1;
                lbxTree.Items.Add(currentDisplayString);
            }
            // Clear the Items in the Items ListBox
            lbxItems.Items.Clear();
        }// End Move to tree

        private void Click_OpenWorkPage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open selected Items work page");
        }
    }
}
