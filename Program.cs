namespace LibraryBeBig
{
    public class Program
    {
        public static List<LibraryRoom> rooms = Rooms();
        public static void Main(string[] args)
        {
            Program library = new Program();

            library.startLibrary();
        }

        public void startLibrary()
        {
            Program library = new Program();

            rooms = Rooms();

            Console.WriteLine("Welcome to the LibraryBeBig Library. It's so far very small with just 1 room, 1 shelf, and just 1 row. (Really, we couldn't afford anymore?");
            Console.WriteLine();
            Console.WriteLine("Type a number for what you wanna do, the following options are: ");
            Console.WriteLine();
            Console.WriteLine("0: View the current books.");
            Console.WriteLine("1: Add a book to a shelf.");
            Console.WriteLine("2: Remove a book from a shelf.");
            Console.WriteLine("3: Find a book.");

            int userChoice;
            string input = Console.ReadLine();
            bool isInt = int.TryParse(input, out userChoice);
            if (isInt)
            {
                //See the current books
                if (userChoice == 0)
                {
                    library.PrintLibraryData(rooms, 1, 1, 1);
                }
                //Add a book
                else if (userChoice == 1)
                {
                    library.InsertBook(rooms, 1, 1, 1);
                }
                //Delete a book
                else if (userChoice == 2)
                {
                    library.DeleteBook(rooms, 1, 1, 1);
                }
                //Find a book
                else if (userChoice == 3)
                {
                    library.FindBook(rooms, 1, 1, 1);
                }
                //Wrong number
                else
                {
                    Console.WriteLine("I'm sorry, the number is in another castle.");
                }
            }
            else
            {
                Console.WriteLine("That wasn't a number. Try again.");
            }
        }

        //Early test code
        //}

        //public List<Book> Books(string input)
        //{
        //    List<Book> books = new List<Book>();

        //    // Parse the input and create book objects
        //    // Early mock data for my classes

        //    // Book 1
        //    string title1 = "Texts from Denmark";
        //    string isbn1 = "ISBN1"; //rett
        //    List<string> authors1 = new List<string> { "Brian Jensen" };
        //    int numberOfPages1 = 253;
        //    string publisher1 = "Gyldendal";
        //    int publishYear1 = 2001;

        //    Book book1 = new Book(title1, isbn1, authors1, numberOfPages1, publisher1, publishYear1);
        //    books.Add(book1);

        //    // Book 2
        //    string title2 = "Stories from abroad";
        //    string isbn2 = "ISBN2"; //rett
        //    List<string> authors2 = new List<string> { "Peter Jensen", "Hans Andersen" };
        //    int numberOfPages2 = 156;
        //    string publisher2 = "Borgen";
        //    int publishYear2 = 2012;

        //    Book book2 = new Book(title2, isbn2, authors2, numberOfPages2, publisher2, publishYear2);
        //    books.Add(book2);

        //    return books;
        //}

        //public List<Book> FindBooks(string input, List<Book> books)
        //{
        //    if (!string.IsNullOrEmpty(input))
        //    {
        //        string[] searchTerms = input.Split('&');

        //        foreach (string term in searchTerms)
        //        {
        //            List<Book> filteredBooks = books;

        //            filteredBooks = filteredBooks
        //                .Where(book => book.Title.Contains(term)
        //                            || book.Authors.Any(author => author.Contains(term))
        //                            || book.Publisher.Contains(term)
        //                            || book.PublishYear.ToString().Contains(term))
        //                .ToList();

        //            books = filteredBooks;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No input was made. Try again?");
        //    }

        //    return books;
        //}

        //Original data
        public static List<LibraryRoom> Rooms()
        {
            List<LibraryRoom> libraryRooms = new List<LibraryRoom>();

            var libraryRoom = new LibraryRoom
            {
                Room = 1,
                RoomName = "Fantasy",
                Rows = new List<LibraryRoomRows> // Instantiate the list
                {
                    new LibraryRoomRows
                    {
                        Row = 1,
                        Shelves = new List<RoomRowShelves> // Instantiate the list
                        {
                            new RoomRowShelves
                            {
                                Shelf = 1,
                                LibraryItems = new List<LibraryItems>
                                {
                                    new Book("Harry Potter and the Philosopher's Stone", "ISBN-1234", new List<string> { "J. K. Rowling" }, 223 , "Bloomsbury", 1997),
                                    new Book("Lord of the Rings: The Fellowship of the Ring", "ISBN-1235", new List<string> { "Some", "Dude" }, 576, "Allen & Unwin", 1954),
                                    new Book("The Lion, The Witch and the Wardrobe", "ISBN-1236", new List<string> { "C. S. Lewis" }, 172, "Geoffrey Bles", 1950)
                                }
                            }
                        }
                    }
                }
            };
            libraryRooms.Add(libraryRoom);
            return libraryRooms;
        }

        //0 Overview
        public void PrintLibraryData(List<LibraryRoom> rooms, int roomNumber, int rowNumber, int shelfNumber)
        {
            try
            {
                foreach (var libraryRoom in rooms)
                {
                    Console.WriteLine($"Room: {libraryRoom.Room}");

                    foreach (var roomRow in libraryRoom.Rows)
                    {
                        Console.WriteLine($"  Row: {roomRow.Row}");

                        foreach (var shelf in roomRow.Shelves)
                        {
                            Console.WriteLine($"    Shelf: {shelf.Shelf}");

                            foreach (var libraryItem in shelf.LibraryItems)
                            {
                                Console.WriteLine($"      ISBN: {libraryItem.ISBN}");
                                Console.WriteLine($"      Title: {libraryItem.Title}");

                                if (libraryItem is Book book)
                                {
                                    Console.WriteLine($"      Authors: {string.Join(", ", book.Authors)}");
                                    Console.WriteLine($"      Number of Pages: {book.NumberOfPages}");
                                    Console.WriteLine($"      Publisher: {book.Publisher}");
                                    Console.WriteLine($"      Publish Year: {book.PublishYear}");
                                }

                                // Add handling for other types of LibraryItems if needed

                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch(Exception ex )
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                startLibrary();
            }
        }

        //1 Create
        public void InsertBook(List<LibraryRoom> libraryRooms, int roomNumber, int rowNumber, int shelfNumber)
        {
            try
            {
                bool reply = false;
                List<string> newAuthors = new List<string>();

                Console.WriteLine("You wanna insert a book? Follow the step by step guide for how to add a book to the library.");
                Console.WriteLine("What's the title: ");
                string newBookTitle = Console.ReadLine();
                Console.WriteLine("What's the ISBN: ");
                string newBookISBN = Console.ReadLine();
                Console.WriteLine("How many authors in numbers: ");
                int authorCount = Convert.ToInt16(Console.ReadLine());
                for (int i = 1; i <= authorCount; i++)
                {
                    Console.WriteLine("Name of author number " + i + ": ");
                    string author = Console.ReadLine();
                    if (!string.IsNullOrEmpty(author))
                    {
                        newAuthors.Add(author);
                    }
                    else
                    {
                        Console.WriteLine("You sure the author doesn't have a name?");
                        Console.WriteLine(); //Space
                        Console.WriteLine("Name of author number " + i + ": ");
                        string authorTryAgain = Console.ReadLine();
                        if (!string.IsNullOrEmpty(authorTryAgain))
                        {
                            newAuthors.Add(authorTryAgain);
                        }
                    }
                }
                Console.WriteLine("How many pages does the book have: ");
                int newBookPageNumbers = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Who published the book: ");
                string newBookPublisher = Console.ReadLine();
                Console.WriteLine("What year was the book published: ");
                int newBookPublishYear = Convert.ToInt16(Console.ReadLine());



                Console.WriteLine();
                Console.WriteLine("Congratulations, wanna save the book you've typed in? Y/N");
                if (Console.ReadLine() == "Y")
                    reply = true;

                if (reply)
                {
                    List<LibraryRoom> OriginalLocation = Rooms();
                    Book newBook = new Book(newBookTitle, newBookISBN, newAuthors, newBookPageNumbers, newBookPublisher, newBookPublishYear);
                    AddBookToLibrary(OriginalLocation, 1, 1, 1, newBook);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                startLibrary();
            }
        }

        public void AddBookToLibrary(List<LibraryRoom> libraryRooms, int roomNumber, int rowNumber, int shelfNumber, Book book)
        {
            // Find the relevant room, row, and shelf in the mock data
            var room = libraryRooms.FirstOrDefault(r => r.Room == roomNumber);
            if (room == null)
            {
                // Room not found
                Console.WriteLine("Room not found.");
                return;
            }

            var row = room.Rows.FirstOrDefault(r => r.Row == rowNumber);
            if (row == null)
            {
                // Row not found
                Console.WriteLine("Row not found.");
                return;
            }

            var shelf = row.Shelves.FirstOrDefault(s => s.Shelf == shelfNumber);
            if (shelf == null)
            {
                // Shelf not found
                Console.WriteLine("Shelf not found.");
                return;
            }

            // Add the book to the LibraryItems collection
            shelf.LibraryItems.Add(book);

            Console.WriteLine("Book added successfully.");
            Console.WriteLine();
        }

        //2 Delete
        public void DeleteBook(List<LibraryRoom> libraryRooms, int roomNumber, int rowNumber, int shelfNumber)
        {

        }

        //3 Search
        public void FindBook(List<LibraryRoom> libraryRooms, int roomNumber, int rowNumber, int shelfNumber)
        {
            Console.WriteLine("");
        }
    }

    #region libraryContent

    public class LibraryItems
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public LibraryItems(string isbn, string title)
        {
            ISBN = isbn;
            Title = title;
        }
        //public abstract string GetItemInformation();
    }

    public class Book : LibraryItems
    {
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }

        public Book(string title, string isbn, List<string> authors, int numberOfPages, string publisher, int published)
            : base(title, isbn)
        {
            Authors = authors;
            NumberOfPages = numberOfPages;
            Publisher = publisher;
            PublishYear = published;
        }
    }

    public class Disk : LibraryItems
    {
        public int NumberOfTracks { get; set; }

        public Disk(string title, string isbn, int numberOfTracks)
            : base(title, isbn)
        {
            NumberOfTracks = numberOfTracks;
        }
    }

    public class Content : Disk
    {
        public string Artist { get; set; }
        public string TrackTitle { get; set; }
        public TimeSpan Duration { get; set; }
        public int ContentType { get; set; }

        public Content(string title, string isbn, int numberOfTracks, string artist, string trackTitle, TimeSpan duration, int contentType)
            : base(title, isbn, numberOfTracks)
        {
            Artist = artist;
            TrackTitle = trackTitle;
            Duration = duration;
            ContentType = contentType;
        }
    }



    public enum ContentTypes
    {
        Audio, //0
        Video //1
    }

    #endregion libraryContent



    #region Library

    public class LibraryRoom
    {
        public int Room { get; set; }

        public string RoomName { get; set; }

        public List<LibraryRoomRows> Rows { get; set; }
    }

    public class LibraryRoomRows : LibraryRoom
    {
        public int Row { get; set; }

        public List<RoomRowShelves>? Shelves { get; set; }
    }

    public class RoomRowShelves : LibraryRoomRows
    {
        public int Shelf { get; set; }

        public List<LibraryItems>? LibraryItems { get; set; }
    }

    #endregion Library
}