namespace Store.Memory
{
	public class BookRepository : IBookRepository
	{
		private readonly Book[] books = new[]
		{
			new Book(1, "art"),
			new Book(2, "Ref"),
			new Book(3, "C Prog")
		};

		public Book[] GetAllByTitle(string titlePart) => books.Where(b => b.Title.Contains(titlePart, StringComparison.InvariantCultureIgnoreCase)).ToArray();
	}
}