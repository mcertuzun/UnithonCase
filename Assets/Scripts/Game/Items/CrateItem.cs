using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;

namespace Game.Items
{
    public class CrateItem : Item
    {
        private int _layerCount = 2;
        
        public void PrepareCrateItem(ItemBase itemBase)
        {
            var crateLayer2Sprite = ServiceProvider.GetImageLibrary.CrateLayer2Sprite;
            Prepare(itemBase, crateLayer2Sprite);
        }

        public override bool CanBeMatchedByTouch()
        {
            return false;
        }

        public override bool CanFall()
        {
            return false;
        }

        public override bool CanBeExplodedByNeighbourMatch()
        {
            return true;
        }
        
        public override bool TryExecute(MatchType matchType)
        {
            _layerCount--;
            if (_layerCount <= 0) return base.TryExecute();
            
            SpriteRenderer.sprite = ServiceProvider.GetImageLibrary.CrateLayer1Sprite;
            return false;
        }
    }
}
