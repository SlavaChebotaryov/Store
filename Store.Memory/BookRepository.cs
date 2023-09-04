namespace Store.Memory
{
	public class BookRepository : IBookRepository
	{
		private readonly Book[] books = new[]
		{
			new Book(1, "art","d.knut", "ISBN 12323-12342"),
			new Book(2, "Ref","m.fowler", "ISBN 12003-12642"),
			new Book(3, "C Prog","b.Kernigan", "ISBN 18783-18882")
		};

		public Book[] GetAllByIsbn(string isbn) => books.Where(book => book.Isbn == isbn).ToArray();

		public Book[] GetAllByTitleOrAuthor(string query) => books
			.Where(b => b.Title.Contains(query)
			|| b.Author.Contains(query))
			.ToArray();

	}
}