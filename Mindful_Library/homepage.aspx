<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Mindful_Library.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section>
         <img src="images/library2.jpg" class="img-fluid" style="width: 100%; height: 250px; object-fit: cover;" />
         <div>
            <h2 class="title" style="text-align: center;margin-top: 10px;margin-bottom: 20px;">Welcome to Mindful Library</h2>
        </div>
     </section>

    <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2 class="features">Our Features</h2>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                   <img width="150px" src="images/inventory.jpg" />
                  <h4 class="feautres-title" style="margin-top: 5px">Digital Inventory</h4>
                  <p class="text-justify">Access a wealth of digital resources, including e-books, audiobooks,
                      scholarly articles, and databases, available anytime, anywhere.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                   <img width="118px" src="images/collection.jpg" />
                  <h4 class="feautres-title">Diverse Collection</h4>
                  <p class="text-justify">Explore a vast collection of literature spanning genres,
                      cultures, and languages, carefully curated to enrich your reading experience.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                   <img width="150px" src="images/Access.jpg" />
                  <h4 class="feautres-title">24/7 Digital Access</h4>
                  <p class="text-justify">Enjoy uninterrupted access to our collection round the clock,
                      accommodating different schedules and time zones for users worldwide</p>
               </center>
            </div>
         </div>
      </div>
   </section>

     <section>
         <img src="images/library1.jpg" class="img-fluid" style="width: 100%; height: 250px; object-fit: cover;margin-bottom:10px;" />
     </section>

    <section>
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-6">
                    <h2 class="title text-uppercase mb-4">Membership Benefits</h2>
                    <ul class="list-unstyled">
                        <li class="mb-3"><span class="dot"></span><i class="bi bi-check2 me-2 text-primary"></i>Borrowing privileges for a diverse collection of books, audiobooks, and more.</li>
                        <li class="mb-3"><span class="dot"></span><i class="bi bi-check2 me-2 text-primary"></i>Access to exclusive resources, including digital archives and specialized databases.</li>
                        <li class="mb-3"><span class="dot"></span><i class="bi bi-check2 me-2 text-primary"></i>Participation in library events, workshops, and book clubs.</li>
                    </ul>
                </div>

                <div class="col-md-6 text-center">
                    <img src="images/membership.jpg" class="img-fluid rounded" alt="Membership Image" style="max-width: 50%; height: auto;" />
                </div>
            </div>
        
            <div class="row mt-4 align-items-center">
                <div class="col-md-6">
                    <h2 class="title text-uppercase mb-4">How to Access</h2>
                    <ul class="list-unstyled">
                        <li class="mb-3"><span class="dot"></span><i class="bi bi-check2 me-2 text-primary"></i>Students: Present a valid student ID card at the library's circulation desk to sign up for membership.</li>
                        <li class="mb-3"><span class="dot"></span><i class="bi bi-check2 me-2 text-primary"></i>Faculty/Staff: Use your university-issued credentials to access digital resources through the library's online portal.</li>
                        <li class="mb-3"><span class="dot"></span><i class="bi bi-check2 me-2 text-primary"></i>Community Members: Visit the library in person to inquire about community membership options and registration.</li>
                    </ul>
                </div>

                <div class="col-md-6 text-center">
                    <img src="images/access-feature.jpg" class="img-fluid rounded" alt="Access Image" style="max-width: 60%; height: auto;" />
                </div>
            </div>
        </div>
    </section>

</asp:Content>
