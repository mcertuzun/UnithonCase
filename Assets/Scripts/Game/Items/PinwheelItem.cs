using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Items
{
    public class PinwheelItem : Item
    {
        private int _layerCount = 4;
        Dictionary<MatchType, SpriteRenderer> sprites = new Dictionary<MatchType, SpriteRenderer>();
        public void PreparePinwheelItem(ItemBase itemBase)
        {
            var pinwheelLayerBackground = ServiceProvider.GetImageLibrary.PinwheelBackground;
            Prepare(itemBase, pinwheelLayerBackground);

            sprites.Add(MatchType.Green, this.AddSprite(ServiceProvider.GetImageLibrary.GreenPinwheelLeaf));
            sprites.Add(MatchType.Blue, this.AddSprite(ServiceProvider.GetImageLibrary.BluePinwheelLeaf));
            sprites.Add(MatchType.Red, this.AddSprite(ServiceProvider.GetImageLibrary.RedPinwheelLeaf));
            sprites.Add(MatchType.Yellow, this.AddSprite(ServiceProvider.GetImageLibrary.YellowPinwheelLeaf));

        }

        public override MatchType GetMatchType()
        {
            return MatchType.Special;
        }

        public override bool CanBeMatchedByTouch()
        {
            return false;
        }
        public override bool CanBeExplodedByNeighbourMatch()
        {
            return true;
        }

        public override bool CanFall()
        {
            return false;
        }
  
        public override bool TryExecute(MatchType matchType)
        {
            if(matchType == MatchType.Special)
            {
                if (sprites.Count == 1) return base.TryExecute();
                var randomKey = sprites.Keys.ToArray()[(int)Random.Range(0, sprites.Keys.Count)];
                var randomValueFromDictionary = sprites[randomKey];
                this.RemoveSprite(randomValueFromDictionary);
                sprites.Remove(randomKey);
            }
            if (sprites.ContainsKey(matchType))
            {
                if (sprites.Count == 1) return base.TryExecute();
     
                this.RemoveSprite(sprites[matchType]);
                sprites.Remove(matchType);
            }
            return false;
        }
    }
}
