﻿namespace Store
{
	public interface IBookRepository
	{
		Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
		Book[] GetAllByIsbn(string isbn);
		Book GetById(int id);
	}
}
