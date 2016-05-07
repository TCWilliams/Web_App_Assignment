/* 
 * Server Class. Reads data from file and creates a list of Items. Performs functions on Items. Functions return values to Client to use 
 * in event handling methods such as button clicks. To run the file path must be set to data file - line 27
 * 
 * Author: Tim Williams
 */ 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

public class Server
{
    List<Item> itemList = new List<Item>(); // list of items in collection     
    List<string> searchHistory = new List<string>(); // list of strings used in searches
    public Server()
    {
        readData(); // read items from file		
    }

    private void readData()
    {                                     /******IMPORTANT - Change filepath to direct to data file*******/
        StreamReader sr = new StreamReader("C:/Users/Tim/Documents/Uni/Info226/assignment2/Williams_300296562_Info226_A2/data/item_records.txt"); // attach a reader to data file 

        while (sr.Peek() >= 0) // until end of file
        {
            string line = sr.ReadLine();  // read current line
            if (line[0] != '#')  // if line in data file does not start with #, it is Item data
            {
                // split line by tab delimited
                string[] values = line.Split('\t');
                // read values into variables, as strings, or parsing them to correct type
                int itemId = Int32.Parse(values[0]);
                string fName = values[1];
                string lName = values[2];
                string sport = values[3];
                string itemType = values[4];
                int itemYear = Int32.Parse(values[5]);
                string yearsActive = values[6];
                string team = values[7];
                int firstProYear = Int32.Parse(values[8]);
                string dob = (values[9]);
                string placeOfBirth = values[10];
                bool alive = bool.Parse(values[11]);
                // construct new Item and add to Item List
                Item item = new Item(itemId, fName, lName, sport, itemType, itemYear, yearsActive, team, firstProYear, dob, placeOfBirth, alive);
                itemList.Add(item);
            }
            // next split lines by tab and create Item

        }
    }
    /*
     * return the total number of items in the collection
     */
    public int getItemCount()
    {
        return itemList.Count;
    }
    /*
     * gets the search histroy. If there are more than 10 searches
     * just gets the most recent 10
     * returns a string array
     */
    public string[] getSearchHistory()
    {
        string[] history;
        if (searchHistory.Count < 10)  // if less than 10 searches in list
        {
            history = new string[searchHistory.Count];  // make array, size if search list
            for (int i = 0; i < searchHistory.Count; i++) // loop through search list
            {
                history[i] = searchHistory[i];      // add every search to result array
            }
        }
        else
        {
            history = new string[10];   // there are 10+ searches
            int index = 0;
            for (int i = searchHistory.Count - 10; i < searchHistory.Count - 1; i++)  // loop through the most recent 10
            {
                history[index] = searchHistory[i];  // add them to array
                index++;
            }
        }
        return history;  // return result array
    }
    /*
     * get the number of items associated with a particular player
     * params: first name, last name
     * return: number of items
     */
    public int getNumItemsByPlayer(string fname, string lname)
    {
        int count = 0; // set counter
        for (int i = 0; i < itemList.Count; i++) // for all items
        {
            Item itm = (Item)itemList[i]; // check if names are equal, ignoring case
            if (itm.getFName().Equals(fname, StringComparison.InvariantCultureIgnoreCase) && itm.getLName().Equals(lname, StringComparison.InvariantCultureIgnoreCase))
            {
                count++; // name found, increment cout
            }
        }
        return count;   // return result
    }
    /* allows user to change to category (item type)
     * params: item number, new category
     */
    public void setCategory(int itemId, string category)
    {
        Item itm = getItemFromId(itemId);  // get item
        itm.setCategory(category);  // update item type

    }
    /* get the category of an item
     * params: item number
     * returns: the category array the user has set for the item
     * note that items are not categorised until user has set category, default category is "not categorised"
     */
    public string[] getItemCategory(int itemId)
    {
        Item itm = getItemFromId(itemId);
        return itm.getCategory();
    }
    /*
     * get number of items in a specified type
     * params: type
     * return: number of items
     */
    public int getNumItemsByType(string type)
    {
        int count = 0; // initialise counter
        for (int i = 0; i < itemList.Count; i++) // for all items
        {
            Item itm = (Item)itemList[i]; // check if type of current item matches search type
            if (itm.getType().Equals(type, StringComparison.InvariantCultureIgnoreCase))
            {
                count++; // if match was found increment count
            }
        }
        return count;   // return result
    }
    /*
     * get number of items in a specified category
     * params: category
     * return: number of items
     */
    public int getNumItemsByCategory(string category)
    {
        int count = 0; // initialise counter
        for (int i = 0; i < itemList.Count; i++) // for all items
        {
            Item itm = (Item)itemList[i];  // current item to searchs
            for (int j = 0; j < itm.getCategory().Length; j++) // inner loop to check each index of category array against category input
            {
                if (itm.getCategory()[j] != null && itm.getCategory()[j].Equals(category, StringComparison.InvariantCultureIgnoreCase)) // if matching entry is found in item category array
                {
                    count++; //  increment count when match found
                }
            }
        }
        return count;   // return result
    }
    /*
     * update condition function. user can add condition and whether item has a dedication
     * params: item id number, true/false has dedication, condition details, and current value
     */
    public void updateCondition(int itemId, bool dedication, string condition, decimal value)
    {
        Item itm = (Item)itemList[itemId]; // get item associated with id number
        itm.setDedication(dedication);  // set dedication true or false
        itm.setCondition(condition); // update condition
        itm.setCurrentValue(value);
    }
    /* get the total values of the collection
     */
    public decimal getTotalValue()
    {
        decimal total = 0;
        for (int i = 0; i < itemList.Count; i++) // for all items
        {
            Item itm = (Item)itemList[i];
            total += itm.getCurrentValue();
        }
        return total;
    }

    /* 
     * get the value of a single item
     */
    public decimal getItemValue(int itemId)
    {
        Item itm = getItemFromId(itemId);
        return itm.getCurrentValue();  // return current value of item
    }

    /*
     *search the catalogue by category and keyword combination. searchable types are
     *"sport", "item type", "year", team" keyword can be anything but will only return results
     *if an item in the catalogue matches it
     *params: string type, string keyword
     */
    public Item[] searchByTypeAndKeyword(string type, string kWord)
    {
        searchHistory.Add(type + " ," + kWord);
        string keyWord = kWord.ToLowerInvariant();  // make sure input is in lower case
        string itemType = type.ToLowerInvariant();
        Item[] temp = new Item[itemList.Count];  // temporary array to store results in, size of item list
        int index = 0;  // index of temp array
        for (int i = 0; i < itemList.Count; i++)  // for all items
        {
            if (itemType.Equals("sport"))  // if user has searched by sport category
            {
                if (itemList[i].getSport().Equals(kWord))  // check all items to see if keyword  sport matches sport in item 
                {
                    temp[index] = itemList[i];  // if it does, add it to temp array at index
                    index++;                    // increment temp index
                }
            }
            else if (itemType.Equals("item type"))  // do as above for the other 3 searchable categories
            {
                if (itemList[i].getType().Equals(kWord))
                {
                    temp[index] = itemList[i];
                    index++;
                }
            }
            else if (itemType.Equals("year"))
            {
                if (itemList[i].getItemYear().ToString().Equals(kWord.ToString()))  // convert numbers to string for comparison
                {
                    temp[index] = itemList[i];
                    index++;
                }
            }
            else if (itemType.Equals("team"))
            {
                if (itemList[i].getTeam().Equals(kWord))
                {
                    temp[index] = itemList[i];
                    index++;
                }
            }
        }  // end for loop               
        return fillResultsFromTemp(temp, index);  // return a new array of the correct size with only relevant data
    }

    /* 
     * search items by category. searchable categories to be decided by Client
     * this is a bit unclear in our user stories
     * params: a string 'category
     * return: array of Items in category
     */
    public Item[] searchByCategory(string category)
    {
        searchHistory.Add(category);
        string cat = category.ToLowerInvariant();
        Item[] temp = new Item[itemList.Count];  // temporary array to store results in, size of item list
        int index = 0;  // index of temp array
        for (int i = 0; i < itemList.Count; i++)  // for all items
        {
            for (int j = 0; j < itemList[i].getCategory().Length; j++)  // inner loop through categories in items category array
            {
                if (itemList[i].getCategory()[j] != null && itemList[i].getCategory()[j].Equals(category)) // if category is not null and matches search category
                {
                    temp[index] = itemList[i];  // add item to return list
                    index++;    // increment index counter
                }
            }
        }
        return fillResultsFromTemp(temp, index); // trim array and return
    }
    /*
     * updates value of an item
     * params: the id of the item to be updates, the new value
     */
    public void updateCurrentValue(int itemId, decimal val)
    {
        Item itm = getItemFromId(itemId); // use helper function to get item
        if (itm != null)        // if item was found
            itm.setCurrentValue(val); // update value
    }

    /*
     * sets value of item in a particular year
     * param: item id, year, value of that year
     */
    public void updateValueByYear(int itemId, int year, decimal val)
    {
        Item itm = getItemFromId(itemId); // get item from helper function
        if (year <= itm.getCurrentYear() && year >= itm.getItemYear())  // check if year is between item year and current year
            itm.setYearValue(val, year);  // function in Item class handles this
        else throw new ArgumentOutOfRangeException("that year is not available for this item");
    }

    /*
     * get the decimal array of years values for an item
     */
    public decimal[] getAllYearVaules(int itemId)
    {
        Item itm = getItemFromId(itemId);
        decimal[] values = itm.getYearValues();
        return values;
    }
    /*
     *gives the age of the item, so available years are current year minus age
     *params: item number
     *returns: a string, "start year - current year"
     */
    public string getItemsAvailableYears(int itemId)
    {
        Item itm = getItemFromId(itemId);  // get item from number
        int age = itm.getAvailableYears(); // get age of item

        return (itm.getCurrentYear() - age).ToString() + " - " + itm.getCurrentYear().ToString();
    }

    /*
    * add a new item to the list, a unique item number will be automatically generated
    * params: all item details except id number
    */
    public void addItem(string fName, string lName, string sport, string itemType, int itemYear, string yearsActive, string team, int firstProYear, string dob, string placeOfBirth, bool alive)
    {
        int id = itemList.Count; // make id number the size of the list, this should give a unique number for each entry, assuming existing entries follow this rule
        Item itm = new Item(id, fName, lName, sport, itemType, itemYear, yearsActive, team, firstProYear, dob, placeOfBirth, alive);
        itemList.Add(itm);
    }

    /* user can add a comment to a list of comments
     * params: item number, comment to add
     */
    public void addComment(int itemId, string comment)
    {
        Item itm = getItemFromId(itemId);
        itm.setComment(comment);  // added comment to list of comments
    }
    /* get array of comments from an item
     * params: item number
     * returns: an array of string comments
     */
    public string[] getComments(int itemId)
    {
        Item itm = getItemFromId(itemId);  // get item
        List<string> cmts = itm.getComments();  // get list of item comments
        string[] comments = new string[cmts.Count];  // make new array, size of comment list
        for (int i = 0; i < cmts.Count; i++)
        {
            comments[i] = cmts[i];  // put comments from list into array
        }
        return comments;  // return array
    }

    // TODO Fix
    public Item[] checkForAllDuplicates()
    {
        Item[] temp = new Item[itemList.Count]; // make temporary array, size of item list
        for (int i = 0; i < temp.Length; i++) // all items in temp are initialised to have -1 itemId
        {                                       // through secondary constructor
            temp[i] = new Item();
        }
        int index = 0;  // initialise index  for duplicate items array
        for (int i = 0; i < itemList.Count; i++) // for all items
        {
            for (int j = i + 1; j < itemList.Count - 1; j++)  // check every other item against item i
                if (itemList[i].compare(itemList[j]) == 1)   // if it matches the criteria for duplicate
                {
                    temp[index] = (Item)itemList[i]; // add to duplicate array and increment index
                    index++;
                }
        }
        return fillResultsFromTemp(temp, index);  // trim temp array and return duplicates
    }

    /* check a particular item for duplicates. 
     * params item id
     * returns an array of items - note that in the test dataset this array will only ever be 1 element,
     * but it is necessary to store it in an array to account for a larger dataset with more duplicate items
     */
    public Item[] checkForItemDuplicate(int itemId)
    {
        Item[] items = checkForAllDuplicates();  // get full list of duplicate items
        Item[] temp = new Item[items.Length];   // make new array size of duplicate list
        int index = 0;      // array index counter
        for (int i = 0; i < items.Length; i++)   // for each duplicate item
        {
            if (items[i].compare(getItemFromId(itemId)) == 1)  // check if it matches the item with ItemId input 
            {
                temp[index] = items[i];  // if it matches, add to temp array
                index++;    // increment array index
            }
        }
        return fillResultsFromTemp(temp, index);  // trim array and return
    }

    /*
    * This helper function creates a results array for functions to return to client when needed
    * It is necessary to avoid sending the client arrays with null, essentially it trims arrays 
    * to just the important data to retrun to client
    * params: temp array of Items, number of items - index
    */
    private Item[] fillResultsFromTemp(Item[] temp, int index)
    {
        Item[] results = new Item[index]; // make a new array for results
        for (int i = 0; i < index; i++)  // go through temp array to fill results array
        {
            results[i] = temp[i];
        }
        return results;  // returns an array
    }

    /*
    * helper funtion takes an item id number and returns the Item with that id
    */
    public Item getItemFromId(int id)
    {
        Item itm = new Item(); // make item to return, using other constructor that initialises item id at -1
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].getItemId() == id) // if item with that number was found
                itm = (Item)itemList[i];        // assign it to itm to return 

        }
        if (itm.getItemId() != -1)  // item was not found if item id is still -1
            return itm;
        else throw new NullReferenceException("Item with that id number was not found");  // throw exception if item not found
    }
}

