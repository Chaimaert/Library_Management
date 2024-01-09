using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mindful_Library
    {
        public partial class Reservation : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["Book_id"] != null)
                    {
                        string bookId = Request.QueryString["Book_id"];

                        // Assuming you have a method to retrieve book details from the book ID
                        Book book = GetBookDetailsFromDatabase(bookId);

                        // Display book details on the page (assign to labels or controls)
                        BookNameLabel.Text = book.BookName; // Example: Display book name in a label
                        AuthorLabel.Text = book.Author;
                        // Assign other book details to respective labels or controls
                    }
                }
            }

            // Method to retrieve book details based on book ID (replace this with your data retrieval method)
            private Book GetBookDetailsFromDatabase(string bookId)
            {
                // Replace this code with your logic to fetch book details from the database based on the book ID
                // Create a Book object and populate it with the retrieved details
                Book book = new Book();

                // Example: Replace this with your actual database querying logic
                // Simulating book details retrieval from a database query
                if (bookId == "1")
                {
                    // For demonstration purposes, create a sample book object with details
                    book.BookId = "1";
                    book.BookName = "Sample Book";
                    book.Author = "Sample Author";
                    // Assign other book details to the Book object
                }

                // Return the Book object with retrieved details
                return book;
            }
        }

        // Create a class representing a Book with properties matching your book details
        public class Book
        {
            public string BookId { get; set; }
            public string BookName { get; set; }
            public string Author { get; set; }
            // Add other properties representing book details as needed
        }
    }

}
}
