<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="Mindful_Library.Reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
        <h2>Reservation Details</h2>
        <asp:GridView ID="ReservedBookGridView" runat="server" CssClass="table-style" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Book_id" HeaderText="Book ID" />
                <asp:BoundField DataField="Book_Name" HeaderText="Book Name" />
                <asp:BoundField DataField="Author_Name" HeaderText="Author" />
                <asp:BoundField DataField="Book_Type" HeaderText="Genre" />
                <asp:BoundField DataField="Pages_Nbr" HeaderText="Pages" />
                <asp:BoundField DataField="Price" HeaderText="Cost" />
                <asp:BoundField DataField="Disponibility" HeaderText="Availability" />
            </Columns>
        </asp:GridView>
   </div>
</asp:Content>
