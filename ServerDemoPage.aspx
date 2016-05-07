<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServerDemoPage.aspx.cs" Inherits="ServerDemoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 271px;
        }
        .auto-style2 {
            width: 281px;
        }
        .auto-style3 {
            width: 271px;
            height: 29px;
        }
        .auto-style4 {
            width: 281px;
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
        }
        .auto-style6 {
            width: 271px;
            height: 23px;
        }
        .auto-style7 {
            width: 281px;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 1001px">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Totaltems" runat="server" OnClick="Totaltems_Click" Text="get total items" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="totalItemsTextBox" runat="server"></asp:TextBox>
                </td>
                <td>number of items in colletction</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="searchHistoryButton" runat="server" OnClick="searchHistoryButton_Click" Text="get search history" />
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="SearchHistoryDropDownList" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">search history up to most recent 10 max</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="SetCategoryButton" runat="server" OnClick="SetCategoryButton_Click" Text="set category" />
                </td>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="item ID "></asp:Label>
                    <asp:TextBox ID="CatIdTextBox" runat="server" Width="41px"></asp:TextBox>
                    <asp:Label ID="CategoryLabel" runat="server" Text="Label"></asp:Label>
                    <asp:DropDownList ID="SetCategoryDropDownList" runat="server">
                        <asp:ListItem>over 20 years</asp:ListItem>
                        <asp:ListItem>over $100</asp:ListItem>
                        <asp:ListItem>to sell</asp:ListItem>
                        <asp:ListItem>favourite</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="GetCategoryButton" runat="server" OnClick="GetCategoryButton_Click" Text="get category" />
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="GetCategoryTextBox" runat="server">enter id number</asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:ListBox ID="GetCategoryListBox" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="SerachTypeKwordButton" runat="server" OnClick="SerachTypeKwordButton_Click" Text="seach by type and keyword" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="KeywordTextBox" runat="server" ToolTip="key word">keyword</asp:TextBox>
                    <asp:DropDownList ID="TypeDropDownList" runat="server">
                        <asp:ListItem>sport</asp:ListItem>
                        <asp:ListItem>team</asp:ListItem>
                        <asp:ListItem>item type</asp:ListItem>
                        <asp:ListItem>year</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ListBox ID="SearchTypeKwordListBox" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="SearchCategoryButton" runat="server" OnClick="SearchCategoryButton_Click" Text="search by category" />
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="SearchByCategoryDropDownList" runat="server">
                        <asp:ListItem>over 20 years</asp:ListItem>
                        <asp:ListItem>over $100</asp:ListItem>
                        <asp:ListItem>to sell</asp:ListItem>
                        <asp:ListItem>favourite</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ListBox ID="SearchCategoryListBox" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="getNumItemsByPlayerButton" runat="server" Text="get num items by player" OnClick="getNumItemsByPlayerButton_Click" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="FirstNameTextBox" runat="server">first name</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="LasttNameTextBox" runat="server">last name</asp:TextBox>
                    <asp:Label ID="GetNumItemsByPlayerlabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="GetNumItemsByTypeButton" runat="server" Text="get num items by item type" OnClick="GetNumItemsByTypeButton_Click" />
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="GetItemsByTypeDropDownList" runat="server">
                        <asp:ListItem>ball</asp:ListItem>
                        <asp:ListItem>photo</asp:ListItem>
                        <asp:ListItem>t-shirt</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="GetNumItemsByTypeLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="GetNumItemsByCategoryButton" runat="server" OnClick="GetNumItemsByCategoryButton_Click" Text="get num items by category" />
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="getNumItemsByCategoryDropDownList" runat="server">
                        <asp:ListItem>over 20 years</asp:ListItem>
                        <asp:ListItem>over $100</asp:ListItem>
                        <asp:ListItem>to sell</asp:ListItem>
                        <asp:ListItem>favourite</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="GetNumItemsByCategoryLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="GetTotalValueButton" runat="server" OnClick="GetTotalValueButton_Click" Text="get total collection value" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="GetTotalValueTextBox" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="UpdateConditionButton" runat="server" OnClick="UpdateConditionButton_Click" Text="update item condition" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="IdTextBox" runat="server">item id</asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="DedicationDropDownList" runat="server">
                        <asp:ListItem Selected="True">true</asp:ListItem>
                        <asp:ListItem>false</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ConditionDropDownList1" runat="server">
                        <asp:ListItem>poor</asp:ListItem>
                        <asp:ListItem>good</asp:ListItem>
                        <asp:ListItem>very good</asp:ListItem>
                        <asp:ListItem>excellent</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="ValueTextBox" runat="server">value decimal</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="UpdateCurrentValueButton" runat="server" BorderStyle="None" OnClick="UpdateCurrentValueButton_Click" Text="update current value" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="currentValueIdTextBox" runat="server">item id</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="CurrentValueTextBox" runat="server">value decimal</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="GetItemFromIdButton" runat="server" OnClick="GetItemFromIdButton_Click" Text="get item from id" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="GetItemFromIdTextBox" runat="server">id number</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="GetItemByIdLabelLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="AddCommentButton" runat="server" OnClick="AddCommentButton_Click" Text="add comment" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="AddCommentIdTextBox" runat="server">id number</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="CommentTextBox" runat="server">comment</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="GetCommentsButton" runat="server" OnClick="GetCommentsButton_Click" Text="get item comments" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="GetCommentsIDTextBox" runat="server">id number</asp:TextBox>
                </td>
                <td>
                    <asp:ListBox ID="GetCommentsListBox" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Button ID="CheckForDuplicatesButton" runat="server" OnClick="CheckForDuplicatesButton_Click" Text="check for all duplicates" />
                </td>
                <td class="auto-style7">
                    <asp:Label ID="NumDupsLabel" runat="server" Text="num duplicates"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:ListBox ID="DuplicatesListBox" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="CheckDuplicateByItemButton" runat="server" OnClick="CheckDuplicateByItemButton_Click" Text="check for duplicate of item" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="CheckDupByItemTextBox" runat="server">item id</asp:TextBox>
                </td>
                <td>
                    <asp:ListBox ID="CheckDupByItemListBox" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="GetItemAvailableYearsButton" runat="server" OnClick="GetItemAvailableYearsButton_Click" Text="get item available years" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="GetAvailYearsIDTextBox" runat="server">item id</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="YearsAvailLabel" runat="server" Text="available years"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="updateValueByYearButton" runat="server" OnClick="updateValueByYearButton_Click" Text="update value by year" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="UpdateValByYearIdTextBox" runat="server">item id</asp:TextBox>
                    <asp:TextBox ID="updateValYearTextBox" runat="server">year</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="updateValYearValueTextBox" runat="server">value</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="getAllValuesButton" runat="server" OnClick="getAllValuesButton_Click" Text="get all values for an item" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="GetAllValuesIdTextBox" runat="server">item id</asp:TextBox>
                </td>
                <td>
                    <asp:ListBox ID="GetAllYearValuesListBox" runat="server" Width="499px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="getItemValueButton" runat="server" OnClick="getItemValueButton_Click" Text="get item value" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="getItemValueTextBox" runat="server">item id</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="GetItemValueLabel" runat="server" Text="value"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>

