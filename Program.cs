namespace LibraryBeBig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program library = new Program();
            List<Book> books = library.Books("input data");
            List<LibraryRoom> rooms = library.Rooms();

            // Iterate over the list of books print each property
            //foreach (Book book in Rooms)
            //{
            //    Console.WriteLine($"Title: {book.Title}");
            //    Console.WriteLine($"ISBN: {book.ISBN}");
            //    Console.WriteLine($"Authors: {string.Join(", ", book.Authors)}");
            //    Console.WriteLine($"Number of Pages: {book.NumberOfPages}");
            //    Console.WriteLine($"Publisher: {book.Publisher}");
            //    Console.WriteLine($"Published: {book.PublishYear}");
            //    Console.WriteLine();
            //}

            //Console.WriteLine("Wanna look for the books?");
            //Console.WriteLine("Type in your search query. If you wanna search with more than 1 term, differentiate with '&':");

            //string ConsoleInput = Console.ReadLine();

            //List<Book> Results = library.FindBooks(ConsoleInput, books);

            //// Iterate over the list of filtered books and print each property
            //foreach (Book book in Results)
            //{
            //    Console.WriteLine($"Title: {book.Title}");
            //    Console.WriteLine($"ISBN: {book.ISBN}");
            //    Console.WriteLine($"Authors: {string.Join(", ", book.Authors)}");
            //    Console.WriteLine($"Number of Pages: {book.NumberOfPages}");
            //    Console.WriteLine($"Publisher: {book.Publisher}");
            //    Console.WriteLine($"Published: {book.PublishYear}");
            //    Console.WriteLine();
            //}

            library.PrintLibraryData(rooms);
        }

        public void PrintLibraryData(List<LibraryRoom> libraryRooms)
        {
            foreach (var libraryRoom in libraryRooms)
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

        public List<Book> Books(string input)
        {
            List<Book> books = new List<Book>();

            // Parse the input and create book objects
            // Early mock data for my classes

            // Book 1
            string title1 = "Texts from Denmark";
            string isbn1 = "ISBN1"; //rett
            List<string> authors1 = new List<string> { "Brian Jensen" };
            int numberOfPages1 = 253;
            string publisher1 = "Gyldendal";
            int publishYear1 = 2001;

            Book book1 = new Book(title1, isbn1, authors1, numberOfPages1, publisher1, publishYear1);
            books.Add(book1);

            // Book 2
            string title2 = "Stories from abroad";
            string isbn2 = "ISBN2"; //rett
            List<string> authors2 = new List<string> { "Peter Jensen", "Hans Andersen" };
            int numberOfPages2 = 156;
            string publisher2 = "Borgen";
            int publishYear2 = 2012;

            Book book2 = new Book(title2, isbn2, authors2, numberOfPages2, publisher2, publishYear2);
            books.Add(book2);

            return books;
        }

        public List<Book> FindBooks(string input, List<Book> books)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string[] searchTerms = input.Split('&');

                foreach (string term in searchTerms)
                {
                    List<Book> filteredBooks = books;

                    filteredBooks = filteredBooks
                        .Where(book => book.Title.Contains(term)
                                    || book.Authors.Any(author => author.Contains(term))
                                    || book.Publisher.Contains(term)
                                    || book.PublishYear.ToString().Contains(term))
                        .ToList();

                    books = filteredBooks;
                }
            }
            else
            {
                Console.WriteLine("No input was made. Try again?");
            }

            return books;
        }


        public List<LibraryRoom> Rooms()
        {
            List<LibraryRoom> libraryRooms = new List<LibraryRoom>();

            var libraryRoom = new LibraryRoom
            {
                Room = 101,
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
                                Shelf = 2,
                                LibraryItems = new List<LibraryItems>
                                {
                                    new Book("Harry Potter and the Philosopher's Stone", "ISBN-1234", new List<string> { "J. K. Rowling" }, 223 , "Bloomsbury", 1997),
                                    new Book("Lord of the Rings: The Fellowship of the Ring", "ISBN-1235", new List<string> { "Author1", "Author2" }, 576, "Allen & Unwin", 1954),
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
    }

    #region libraryContent

    public class LibraryItems : RoomRowShelves
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

    public class LibraryRoomRows
    {
        public int Row { get; set; }

        public List<RoomRowShelves>? Shelves { get; set; }
    }

    public class RoomRowShelves
    {
        public int Shelf { get; set; }

        public List<LibraryItems> LibraryItems { get; set; }
    }

    #endregion Library
}