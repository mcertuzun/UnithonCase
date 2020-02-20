using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;
using UnityEngine;

namespace Game.Items
{	
	public class BombItem : Item
	{
		private bool _isAlreadyExploded;
        public readonly static int priorty = 2;
        public void PrepareBombItem(ItemBase itemBase)
		{
			var bombSprite = ServiceProvider.GetImageLibrary.BombSprite;
			Prepare(itemBase, bombSprite);
		}

        public override MatchType GetMatchType()
        {
            return MatchType.Special;
        }

        public override ItemType GetItemType()
        {
            return ItemType.Bomb;
        }

        public override bool CanBeExplodedByTouch()
		{
			return true;
		}
		
		public override bool TryExecute(MatchType matchType)
		{
			if (_isAlreadyExploded) return false;
			_isAlreadyExploded = true;

            ServiceProvider.GetSpecialItemManager.explodeBomb(this,1);

			return base.TryExecute();
		}		
	}
}
