using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Channels;

namespace task3_2_
{
    class Book
    {
        public string title;
        public string author;
        public long isbn; 
        public bool availability; 
        public Book(string title, string author, long isbn, bool availability) 
        { this.title = title; 
            this.author = author; 
            this.isbn = isbn; 
            this.availability = availability; 
        }
        
    }
    class Library
    {
        public List<Book> collectionOfBooks = new List<Book>();
        public List<Book> AddBook()
        {
            Console.WriteLine("Please enter the title of the book:");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the name of the author of the book:");
            string author = Console.ReadLine();
            Console.WriteLine("Please enter the isbn of the book:");
            long isbn = Convert.ToInt32(Console.ReadLine());
            bool availability = true;
            for (int i = 0; i < collectionOfBooks.Count; i++)
            {
                if(collectionOfBooks[i].isbn == isbn && collectionOfBooks[i].title == title)
                {
                    Console.WriteLine("The book already exists");
                    Console.WriteLine(" ");
                    return collectionOfBooks;
                }
            }
            Book newbook = new Book(title, author, isbn, availability);
            collectionOfBooks.Add(newbook);
            Console.WriteLine("Book added Successfully");
            return collectionOfBooks;
        }
        public void Addbook(Book book) 
        { 
            collectionOfBooks.Add(book);
        }
        public bool BorrowBook()
        {
            Console.WriteLine("Enter the book title you wish to borrow");
            string answer = Console.ReadLine();
           for (int i = 0; i < collectionOfBooks.Count;i++)
            {
                if (collectionOfBooks[i].title == answer)
                {
                    if (collectionOfBooks[i].availability == true)
                    {
                        collectionOfBooks[i].availability = false;
                        Console.WriteLine("You borrowed the book successfuly");
                        Console.WriteLine("");
                        return true;
                    }
                    else if (answer != null && !collectionOfBooks[i].availability)
                    {
                        Console.WriteLine("The book is already borrowed");
                        return false;
                    }
                    
                }
                else { Console.WriteLine("Book not found"); }
            }
            return false;
        }
        public bool ReturnBook()
        { 
            Console.WriteLine("Please enter name of Book you want to Return");
            String Answer = Console.ReadLine();
            for (int i = 0; i < collectionOfBooks.Count; i++)
            {
                if (collectionOfBooks[i].title == Answer || collectionOfBooks[i].author == Answer)
                {
                    if (collectionOfBooks[i].availability)
                    {
                        Console.WriteLine("the book is already avilabele");
                        Console.WriteLine("");
                    }
                    else if (!collectionOfBooks[i].availability)
                    {
                        Console.WriteLine("the book succefully Returned !");
                        Console.WriteLine("");
                        collectionOfBooks[i].availability = true;

                    }
                    else
                    {
                        Console.WriteLine("there is no book with that name");
                        Console.WriteLine("");
                    }
                    {

                    }
                }
            }
            return false;
        }
        public void Getbooks()
        {
            for (int i = 0; i < collectionOfBooks.Count; i++)
            {
                Console.WriteLine($"Title:{collectionOfBooks[i].title} " +
                    $", Author = {collectionOfBooks[i].author} " +
                    $", ISBN: {collectionOfBooks[i].isbn} " +
                    $", Availability: {collectionOfBooks[i].availability}");
            }
        }
        public void SearchBook()
        {
            Console.WriteLine("Enter the book title you want to search for: ");
            string answer = Console.ReadLine();
            bool bookfound = false;
            for (int i = 0; i < collectionOfBooks.Count; i++)
            {
                if (collectionOfBooks[i].title == answer || collectionOfBooks[i].author == answer)
                {
                    bookfound = true;

                    if (collectionOfBooks[i].availability)
                    {
                        Console.WriteLine($"The book {collectionOfBooks[i].title} by {collectionOfBooks[i].author} you are searching for is available");
                    }
                    else
                    {
                        Console.WriteLine($"The book {collectionOfBooks[i].title} by {collectionOfBooks[i].author} is already borrowed");
                    }
                }
            }
            if (!bookfound) { Console.WriteLine("Sorry the book is not available"); }
        }
        public void DeleteBook()
        {
            Console.WriteLine("Enter the title of the book you wish to delete: ");
            String answer = Console.ReadLine();
            for (int i = 0; i < collectionOfBooks.Count; i++)
            {
                if (collectionOfBooks[i].title == answer)
                {
                    if (collectionOfBooks[i].availability)
                    {
                        string Title = collectionOfBooks[i].title;
                        collectionOfBooks.RemoveAt(i);
                        Console.WriteLine($"The book {Title} is deleted ");
                        Console.WriteLine("");
                        return;
                    }
                    else if (!collectionOfBooks[i].availability)
                    {
                        Console.WriteLine("Sorry, book is borrowed");
                        Console.WriteLine("");

                    }
                    else
                    {
                        Console.WriteLine("Sorry book not found");
                        Console.WriteLine("");


                    }

                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Library library = new Library();
            library.Addbook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 9780743273565, true));
            library.Addbook(new Book("To Kill  a Mockingbird", "Harper Lee", 9780061120084, true));
            library.Addbook(new Book("1984", "George Orwell", 9780451524935, true));
            
            
            do
            {
                Console.WriteLine("Enter A to add a book");
                Console.WriteLine("Enter B to Borrow a book");
                Console.WriteLine("Enter R to Return a book");
                Console.WriteLine("Enter L to List the books");
                Console.WriteLine("Enter S to Search for a book"); 
                Console.WriteLine("Enter D to delete a book in the list");
                Console.WriteLine("Enter Q to quit the program");
                char action = Convert.ToChar(Console.ReadLine());
                
                switch (char.ToUpper(action))
                {
                    case 'A':
                        library.AddBook();
                        break;

                    case 'B':
                        
                    
                        library.BorrowBook();
                        break;

                    case 'L':
                        library.Getbooks();
                        break;

                    case 'R':

                        library.ReturnBook();
                        break;

                    case 'S':
                        library.SearchBook();
                        break;
                    case 'D':
                        library.DeleteBook();
                        break;

                    case 'Q':
                        quit = true;
                        Console.WriteLine("Goodbye !");
                        break;
                    default:
                        Console.WriteLine("Action not available try again with a valid character");
                        break;
                }   
            }
            while (!quit);
        }
    }
}
