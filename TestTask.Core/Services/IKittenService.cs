using System;
using TestTask.Core.Models;

namespace TestTask.Core.Services
{
	public interface IKittenService
	{
		Kitten CreateNewKitten(int Id);
	}
}

