using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * this is a dummy client I had to make because my partner was not able to use my server code and did not provide me with a Client UI that I could use in any way 
 * The UI is extremely basic and I have not commented the code as much as I would have liked
 * Some data handling is done here but I had anticipated my partner dealing with event handling code - he informed me 2 days before due date that all he was going to do was design the UI.
 * 
 * This page responds to button clicks. A session variable instance of my Server class is made and calls the appropriate functions from 
 * Server.cs
 * Where necessary, data retrieved from Server.cs is stored in variables and used to display on screen.
 * 
 * Author: Tim Williams
 */

public partial class ServerDemoPage : System.Web.UI.Page
{

    Server server;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        server = (Server)System.Web.HttpContext.Current.Session["server"];  
    }

    /**************************************************************************/

    protected void Totaltems_Click(object sender, EventArgs e)
    {

        totalItemsTextBox.Text = server.getItemCount().ToString();  // print number of items in colletction

    }

    /**************************************************************************/

    protected void searchHistoryButton_Click(object sender, EventArgs e)
    {

        string[] history = server.getSearchHistory();  // get array of search history
        for (int i = 0; i < history.Length; i++)
        {
            SearchHistoryDropDownList.Items.Add(history[i]);  // loop array and print search history to list box
        }

    }
       
    /**************************************************************************/

    protected void SetCategoryButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(CatIdTextBox.Text);
        string category = SetCategoryDropDownList.SelectedValue;  // parse user input

        Item itm = server.getItemFromId(id);  // get item from id input
        itm.setCategory(category);      // set item category with category input
    }

    /**************************************************************************/

    protected void GetCategoryButton_Click(object sender, EventArgs e)
    {
        GetCategoryListBox.Items.Clear();
        int id = Int32.Parse(GetCategoryTextBox.Text);
        string[] categories = server.getItemCategory(id);

        for (int i = 0; i < categories.Length; i++)
        {
            GetCategoryListBox.Items.Add(categories[i]);  // get item from id and display it's category

        }
    }

    /**************************************************************************/

    protected void SerachTypeKwordButton_Click(object sender, EventArgs e)
    {
        SearchTypeKwordListBox.Items.Clear();  // clear list box
        string type = TypeDropDownList.SelectedValue.ToString();   // parse user input, type and keyword
        string kword = KeywordTextBox.Text;
        Item[] results = server.searchByTypeAndKeyword(type, kword); // get an array of results from search
              
        for (int i = 0; i < results.Length; i++)  // loop result array and print results
        {
            SearchTypeKwordListBox.Items.Add(results[i].printItem());
        }
    }

    /**************************************************************************/

    protected void SearchCategoryButton_Click(object sender, EventArgs e)
    {
        SearchCategoryListBox.Items.Clear();
        string cat = SearchByCategoryDropDownList.SelectedValue;  // parse input, category
        Item[] results = server.searchByCategory(cat);    // get an array of results from search

        for (int i = 0; i < results.Length; i++) // loop result array and print results
        {
            SearchCategoryListBox.Items.Add(results[i].printItem());
        }
    }

    /**************************************************************************/

    protected void getNumItemsByPlayerButton_Click(object sender, EventArgs e)
    {
        string fname = FirstNameTextBox.Text;  // parse input, player names
        string lname = LasttNameTextBox.Text;
        GetNumItemsByPlayerlabel.Text = server.getNumItemsByPlayer(fname, lname).ToString(); ;  // print number of items associated with player
    }

    /**************************************************************************/

    protected void GetNumItemsByTypeButton_Click(object sender, EventArgs e)
    {
        string type = GetItemsByTypeDropDownList.SelectedValue.ToString();     // get and print number of items of chosen type
        GetNumItemsByTypeLabel.Text = server.getNumItemsByType(type).ToString();
    }

    /**************************************************************************/

    protected void GetNumItemsByCategoryButton_Click(object sender, EventArgs e)
    {
        string cat = getNumItemsByCategoryDropDownList.SelectedValue;        // get and print number of items of chosen category
        GetNumItemsByCategoryLabel.Text = server.getNumItemsByCategory(cat).ToString();
    }

    /**************************************************************************/

    protected void GetTotalValueButton_Click(object sender, EventArgs e)
    {
        GetTotalValueTextBox.Text = server.getTotalValue().ToString();   // print total value of collection - only current values, not past year values
    }

    /**************************************************************************/

    protected void UpdateConditionButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(IdTextBox.Text.ToString());   // parse input id
        bool dedication = Boolean.Parse(DedicationDropDownList.SelectedValue);  // boolean has dedication
        string condition = ConditionDropDownList1.SelectedValue;    // item condition from droplist
        decimal value = Decimal.Parse(ValueTextBox.Text);       // current value

        server.updateCondition(id, dedication, condition, value);  // update item condition
    }

    /**************************************************************************/

    protected void UpdateCurrentValueButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(currentValueIdTextBox.Text);
        server.updateCurrentValue(id, Decimal.Parse(CurrentValueTextBox.Text));  // updates current value of item with given id
    }

    /**************************************************************************/

    protected void GetItemFromIdButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(GetItemFromIdTextBox.Text);   // retrieve and print item details of item with given id
        Item itm = server.getItemFromId(id);
        GetItemByIdLabelLabel.Text = itm.printItem();
    }

    /**************************************************************************/

    protected void AddCommentButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(AddCommentIdTextBox.Text);  // add a comment to the list of comments of an item with given id
        string comment = CommentTextBox.Text;
        server.addComment(id, comment);
    }

    /**************************************************************************/

    protected void GetCommentsButton_Click(object sender, EventArgs e)
    {
        GetCommentsListBox.Items.Clear();
        int id = Int32.Parse(GetCommentsIDTextBox.Text);   // retrieve array of comments from item
        string[] comments = server.getComments(id);
        for (int i = 0; i < comments.Length; i++)           // loop array and print all comments
        {

            GetCommentsListBox.Items.Add(comments[i].ToString());
        }
    }

    /**************************************************************************/

    protected void CheckForDuplicatesButton_Click(object sender, EventArgs e)
    {
        DuplicatesListBox.Items.Clear();
        Item[] duplicates = server.checkForAllDuplicates();  // checks entire data set for duplicates 
        NumDupsLabel.Text = duplicates.Length.ToString();   // print number of duplicates
        for (int i = 0; i < duplicates.Length; i++)         // print all duplicates
        {
            DuplicatesListBox.Items.Add(duplicates[i].printItem());
        }
    }

    /**************************************************************************/

    protected void CheckDuplicateByItemButton_Click(object sender, EventArgs e)
    {
        CheckDupByItemListBox.Items.Clear();
        int id = Int32.Parse(CheckDupByItemTextBox.Text);       // as above, but checks for duplicate/s of a selected item
        Item[] duplicates = server.checkForItemDuplicate(id);

        for (int i = 0; i < duplicates.Length; i++)  // print any duplicates found.
        {
            CheckDupByItemListBox.Items.Add(duplicates[i].printItem());
        }
    }

    /**************************************************************************/

    protected void GetItemAvailableYearsButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(GetAvailYearsIDTextBox.Text);      // retrieve and print the available years of a chosen item. in format: start year - current year
        YearsAvailLabel.Text = server.getItemsAvailableYears(id);
    }

    /**************************************************************************/

    protected void updateValueByYearButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(UpdateValByYearIdTextBox.Text);   // updates the value of a chosen item in a selected year
        int year = Int32.Parse(updateValYearTextBox.Text);
        decimal val = Decimal.Parse(updateValYearValueTextBox.Text);

        server.updateValueByYear(id, year, val);
    }

    /**************************************************************************/

    protected void getAllValuesButton_Click(object sender, EventArgs e)
    {
        GetAllYearValuesListBox.Items.Clear();
        int id = Int32.Parse(GetAllValuesIdTextBox.Text);                // retrieve and print all year values of an item
        Item itm = server.getItemFromId(id);
        int year = itm.getCurrentYear()-1;                              // get year to display next to value in print
        decimal[] values = server.getItemFromId(id).getYearValues();     // array of values, length = age of item
        for (int i = 0; i < values.Length; i++)                         // print all values
        {
            GetAllYearValuesListBox.Items.Add(year + " : $" + values[i].ToString());
            year--;      // decrement year counter
        }
    }
    protected void getItemValueButton_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(getItemValueTextBox.Text);
        GetItemValueLabel.Text = server.getItemValue(id).ToString();
    }
}