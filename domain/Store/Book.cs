using System.Text.RegularExpressions;

namespace Store;

public class Book
{
	public int Id { get; }
	public string Title { get; }
	public string Isbn { get; }
	public string Author { get; set; }

	public Book(int id, string title, string author, string isbn) => (Id, Title, Author, Isbn) = (id, title, author, isbn);

	internal static bool IsIsbn(string s)
	{
		if (s == null)
			return false;

		s = s.Replace("-", "")
			.Replace(" ", "")
			.ToUpper();

		return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
	}

}

