using Game.Core.ItemBase;
using Game.Managers;

namespace Game.Items
{	
	public class BalloonItem : Item 
	{
		public void PrepareBalloonItem(ItemBase itemBase)
		{
			var balloonSprite = ServiceProvider.GetImageLibrary.BalloonSprite;
			Prepare(itemBase, balloonSprite);
		}
		
		public override bool CanBeExplodedByNeighbourMatch()
		{
			return true;
		}
	}
}
