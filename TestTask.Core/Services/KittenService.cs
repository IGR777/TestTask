using System;
using TestTask.Core.Models;

namespace TestTask.Core.Services
{
	public class KittenService : IKittenService
	{
		private readonly System.Random _random = new System.Random();
		public Kitten CreateNewKitten(int Id)
		{
			return new Kitten()
			{
				Id = Id,
				ImageUrl = string.Format("http://placekitten.com/{0}/{0}", _random.Next(50) + 301)
			};
		}

	}
}

