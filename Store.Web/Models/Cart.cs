﻿namespace Store.Web.Models
{
	public class Cart
	{
		public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>(); // <int><int> BookId Count

		public decimal Amount { get; set; }

	}
}