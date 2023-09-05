﻿using Moq;

namespace Store.Tests
{
	public class BookServiceTests
	{
		[Fact]
		public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
		{
			var bookRepositoryStub = new Mock<IBookRepository>();
			bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
				.Returns(new[] { new Book(1, "", "", "", "", 0m) });

			bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
				.Returns(new[] { new Book(2, "", "", "", "", 0m) });
			var bookService = new BookService(bookRepositoryStub.Object);
			var validIsbn = "ISBN 12345-67890";

			var actual = bookService.GetAllByQuery(validIsbn);

			Assert.Collection(actual, book=>Assert.Equal(1, book.Id));
		}
		[Fact]
		public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
		{
			var bookRepositoryStub = new Mock<IBookRepository>();
			bookRepositoryStub.Setup(x => x.GetAllByIsbn("Reach"))
				.Returns(new[] { new Book(1, "", "", "", "", 0m) });

			bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor("Reach"))
				.Returns(new[] { new Book(2, "", "", "", "", 0m) });
			var bookService = new BookService(bookRepositoryStub.Object);
			var author = "Reach";

			var actual = bookService.GetAllByQuery(author);

			Assert.Collection(actual, book => Assert.Equal(2, book.Id));
		}
	}
}
