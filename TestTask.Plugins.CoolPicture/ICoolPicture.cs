using System;

namespace TestTask.Plugins.CoolPicture
{
	public interface ICoolPicture
	{
		void Rotate (string imagePath);
		void FlipHorizontal (string imagePath);
		void FlipVertical (string imagePath);
	}
}

