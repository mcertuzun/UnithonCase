using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;
using UnityEngine;

namespace Game.Items
{
    public class ColorBalloonItem : Item
    {
        private Sprite _defaultSprite;
        private MatchType _matchType;

        public void PrepareColorBalloonItem(ItemBase itemBase, MatchType matchType)
        {
            _matchType = matchType;
            SetSpritesForMatchType();
            Prepare(itemBase, _defaultSprite);
        }

        private void SetSpritesForMatchType()
        {
            var imageLibrary = ServiceProvider.GetImageLibrary;

            switch (_matchType)
            {
                case MatchType.Green:
                    _defaultSprite = imageLibrary.GreenBalloonSprite;
                    break;
                case MatchType.Yellow:
                    _defaultSprite = imageLibrary.YellowBalloonSprite;
                    break;
                case MatchType.Blue:
                    _defaultSprite = imageLibrary.BlueBalloonSprite;
                    break;
                case MatchType.Red:
                    _defaultSprite = imageLibrary.RedBalloonSprite;
                    break;
            }
        }
        public override MatchType GetMatchType()
        {
            return _matchType;
        }

        public override bool CanBeExplodedByNeighbourMatch()
        {        
            return true;
        }
       
         public override bool TryExecute(MatchType matchType)
        {          
            if (matchType == this.GetMatchType() || matchType == MatchType.Special)
            {
                return base.TryExecute();
            }
            return false;
        }

    }
}