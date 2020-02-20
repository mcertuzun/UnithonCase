using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;
using System.Collections;
using UnityEngine;

namespace Game.Items
{
    public class DuckItem : Item
    {
        public void PrepareDuckItem(ItemBase itemBase)
        {
            var duckSprite = ServiceProvider.GetImageLibrary.DuckSprite;
            Prepare(itemBase, duckSprite);
        }

 
        public override void afterFalled()
        {
            if(Cell.GetFallTarget().FirstCellBelow==null) Destroy(gameObject);
        }

        public override bool TryExecute(MatchType matchType)
        { 
            return true;
        }
    }
}