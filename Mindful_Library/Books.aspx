<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Mindful_Library.Books" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<!-- jQuery library -->
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<!-- DataTables library -->
<script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
        </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="margin-top:10px, container ">
            <div class="row">

                <div class="margin-top:10px, col-sm-12">
                    <center>
                        <h3 class="title">
                        Books List</h3>
                    </center>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card">
                            <div class="card-body">

                                <div class="row">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Mindful_libraryConnectionString %>" SelectCommand="SELECT * FROM [Books]"></asp:SqlDataSource>
                                    <div class="col">
                                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Book_id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="book_id" ReadOnly="True" SortExpression="book_id">
                                                    <ControlStyle Font-Bold="True" />
                                                    <ItemStyle Font-Bold="True" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-lg-10">
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Book_Name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            <span class="title">Author - </span>
                                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Author_Name") %>'></asp:Label>
                                                                             <br />
                                                                             <span class="title">Genre - </span>
                                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Book_Type") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-12">  
                                                                            <span class="title">Pages - </span>                                                 
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("Pages_Nbr") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            <span class="title">Cost - </span> 
                                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("[Price]") %>'></asp:Label>
                                                                             <br />
                                                                            <span class="title">Availability - </span> 
                                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("[Disponibility]") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-2">
                                                                    <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("[Image]") %>' />
                                                                </div>
                                                            </div>
                                                        </div>
                                                         <!-- Reserve button -->
                                                           <div style="text-align: left;">
                                                            <asp:Button ID="ReserveButton" runat="server" Text="Reserve" CommandName="ReserveLivre" CommandArgument='<%# Eval("Book_Id") %>'
                                                                style="background-color: #e7bc91; border: none; color: black; padding: 5px 10px; width: fit-content; float: left;" OnCommand="ReserverLivre_Click"  />
                                                    </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <center>
            </div>
        </div>
</asp:Content>
