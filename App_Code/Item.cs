/*
 * Item class. An Item represents a row of data from the data file. Has operations to return, get, set fields of Item. 
 * Interacts with Server.cs to create the "database"
 * 
 * Author: Tim Williams 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* 
 * Item class
 * Each item in the collection is an instance of this class.  
 */
public class Item
{

    int currentYear;
    //  **fields to hold details of item **
    // values to be read from file
    int itemId;
    string fName;
    string lName;
    string sport;
    string itemType;
    int itemYear;
    string yearsActive;
    string team;
    int firstProYear;
    string dob;
    string placeOfBirth;
    bool alive;
    // values to be set by user
    string condition;
    decimal currentValue;
    decimal[] yearValues; // array of values for different years
    bool dedication;
    List<string> comments; // list of comments, user can add to this
    string[] categories;  // list of categoris
    int numCategories = 4; // can be changed as categories are added

    // constructor for empty Item, used for checking and filling arrays in server class
    public Item() {
        this.itemId = -1;
    } 
    // constructor
    public Item(int itemId, string fName, string lName, string sport, string itemType, int itemYear, string yearsActive, string team, int firstProYear, string dob, string placeOfBirth, bool alive)
    {
        // set item values from constructor input
        this.itemId = itemId;
        this.fName = fName;
        this.lName = lName;
        this.sport = sport;
        this.itemType = itemType;
        this.itemYear = itemYear;
        this.yearsActive = yearsActive;
        this.team = team;
        this.firstProYear = firstProYear;
        this.dob = dob;
        this.placeOfBirth = placeOfBirth;
        this.alive = alive;

        categories = new string[numCategories]; // there are only 4 categories available in the project

        currentYear = 2015; 
        yearValues = new decimal[currentYear - (this.itemYear)];  // make size of year value array the size of number years between itemYear and now
        comments = new List<string>();

        // initialise year values array to 0's
        for (int i = 0; i < yearValues.Length; i++)
        {
            yearValues[i] = 0;
        }

    }
    private int setCurrentYear()  // sets the current year
    {
        System.DateTime now = new System.DateTime();
        int year = now.Year;
        return year;
    }
    /*
     Getter functions for obtaining information about Item
     */
    public int getItemId()
    {
        return itemId;
    }
    public string getFName()
    {
        return fName;
    }
    public string getLName()
    {
        return lName;
    }
    public string getSport()
    {
        return sport;
    }
    public string getType()
    {
        return itemType;
    }
    public int getItemYear()
    {
        return itemYear;
    }
    public string getYearsActive()
    {
        return yearsActive;
    }
    public string getTeam()
    {
        return team;
    }
    public int getFirstYearPro()
    {
        return firstProYear;
    }
    public string getDob()
    {
        return dob;
    }
    public string getPlaceOfBirth()
    {
        return placeOfBirth;
    }
    public bool getAlive()
    {
        return alive;
    }
    public string getCondition()
    {
        return condition;
    }
    public void setCondition(string updateCondition) // set condition of item
    {
        condition = updateCondition;
    }
    public decimal getCurrentValue()
    {
        return currentValue;
    }
    public void setCurrentValue(decimal val)
    {
        currentValue = val;
    }
    public decimal getYearValue(int year)  // returns a value for a specified year
    {
        
        if (year < currentYear && year >= itemYear)
        {
            int index = currentYear - year; // set index to match array ie if itemYear is 1990 and value wanted is 1991 index will be 1
            return yearValues[index];         // so the value returned will be at index 1 (2nd year of item existing) 
        }
        else throw new IndexOutOfRangeException("that year is not available for this item");
    }
    public void setYearValue(decimal v, int year)
    {
        int index = currentYear - year; // set array index, see above
        yearValues[index-1] = v;
    }
    public decimal[] getYearValues()  // return array of values for all years
    {
        return yearValues;
    }
    public int getAvailableYears()  // returns the number of years item has been around.
    {
        return currentYear - itemYear;
    }
    public bool getDedication(){
        return dedication;
    }
    public void setDedication(bool ddctn)
    {
        this.dedication = ddctn;
    }
    public int getCurrentYear()
    {
        return currentYear;
    }
    public void setComment(string cmt)
    {
        comments.Add(cmt);  // add a comment to the comment list
    }
    public List<string> getComments()
    {
        return comments;  // return list of comments
    }
    public string[] getCategory()
    {
        return categories;
    }
    public void setCategory(string category)
    {
        for (int i = 0; i < numCategories; i++)
        {
            if(categories[i] != null && categories[i].ToLower().Equals(category)) break; // do not add duplicate category if item already has this category in it's array

            if (categories[i] == null)  // search for the first available (null) space in categories list
            {
                this.categories[i] = category;  // assign category 
                break;      // break out of loop
            }
        }
    }
    public int compare(Item item2)  // compare item calling function agains item2, if first name last, name, sport, item type, item year return 1, if not return 0
    {
        if (this.getFName().Equals(item2.getFName()) && this.getLName().Equals(item2.getLName()) && this.getSport().Equals(item2.getSport()) && this.getType().Equals(item2.getType()) && this.getItemYear().Equals(item2.getItemYear()))
        {
            return 1;
        }
        else return 0;
    }
    public string printItem() // print out details of item
    {
        return this.itemId.ToString() + " " + this.fName + " " + this.lName + " " + this.sport + " " + this.itemType + " " + this.itemYear.ToString() + " " +
            this.yearsActive + " " + this.team + " " + this.firstProYear.ToString() + " " + this.dob + " " + this.placeOfBirth.ToString();
    }

}