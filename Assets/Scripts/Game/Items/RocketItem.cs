using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;
using UnityEngine;

namespace Game.Items
{
    public class RocketItem : Item 
    {
        private bool _isAlreadyExploded;
        private ItemType itemType;

        public void PrepareRocketItem(ItemBase itemBase, ItemType itemType)
        {
            this.itemType = itemType;
            var rocketSprite = ServiceProvider.GetImageLibrary.VerticalRocketSprite; 
        
            if(itemType == ItemType.HorizontalRocket)
            {
                rocketSprite = ServiceProvider.GetImageLibrary.HorizontalRocketSprite;
            }

            Prepare(itemBase, rocketSprite);
        }

        public override MatchType GetMatchType()
        {
            return MatchType.Special;
        }

        public override ItemType GetItemType()
        {
            return itemType;
        }


        public override bool CanBeExplodedByTouch()
        {
            return true;
        }

       public override bool TryExecute(MatchType matchType)
        {

            if (_isAlreadyExploded) return false;
            _isAlreadyExploded = true;

            if(_itemType==ItemType.HorizontalRocket)
            {
                ServiceProvider.GetSpecialItemManager.explodeRow(this);
            }
            else
            {
                ServiceProvider.GetSpecialItemManager.explodeColumn(this);
            }

            return base.TryExecute();
        }

      
    }
}
