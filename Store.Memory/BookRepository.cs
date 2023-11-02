namespace Store.Memory
{
	public class BookRepository : IBookRepository
	{
		private readonly Book[] books = new[]
		{
			new Book(1, "art","d.knut", "ISBN 12323-12342", "Lorem ipsum asbat karaganda baraban sabaka sluumpa ps", 15.2m),
			new Book(2, "Ref","m.fowler", "ISBN 12003-12642", "Lorem ipsum asbat karaganda baraban sabaka sluumpa ps", 10m),
			new Book(3, "C Prog","b.Kernigan", "ISBN 18783-18882", "Lorem ipsum asbat karaganda baraban sabaka sluumpa ps", 20m)
		};

		public Book[] GetAllByIsbn(string isbn) => books.Where(book => book.Isbn == isbn).ToArray();

		public Book[] GetAllByTitleOrAuthor(string query) => books
			.Where(b => b.Title.Contains(query??"")
			|| b.Author.Contains(query??""))
			.ToArray();

		public Book GetById(int id) => books.Single(book=>book.Id==id);
		public Book[] GetAllByIds(IEnumerable<int> bookIds)
		{
			return books.Where(book => bookIds.Contains(book.Id)).ToArray();
		}

		public Book[] GetAllBook() => books;
	}
}