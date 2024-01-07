<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="Mindful_Library.Reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <h1>Reservation Details</h1>
            <div class="container">
        <div class="row">
            <div class="col">
                <label>Book Name:</label>
                <asp:Label ID="lblBookName" runat="server"></asp:Label>
            </div>
            <div class="col">
                <label>Author Name:</label>
                <asp:Label ID="lblAuthorName" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <label>Genre:</label>
                <asp:Label ID="lblGenre" runat="server"></asp:Label>
            </div>
            <div class="col">
                <label>Pages:</label>
                <asp:Label ID="lblPages" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <label>Cost:</label>
                <asp:Label ID="lblCost" runat="server"></asp:Label>
            </div>
            <div class="col">
                <label>Availability:</label>
                <asp:Label ID="lblAvailability" runat="server"></asp:Label>
            </div>
     

</asp:Content>
