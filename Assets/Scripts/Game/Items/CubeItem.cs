using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;
using UnityEngine;

namespace Game.Items
{
    public class CubeItem : Item
    {
        private Sprite _defaultSprite;
        private Sprite _hintedSprite;
        private Sprite _hintedSprite2;

        private MatchType _matchType;

        private int _hinted;
        
        public void PrepareCubeItem(ItemBase itemBase, MatchType matchType)
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
                    _defaultSprite = imageLibrary.GreenCubeSprite;
                    _hintedSprite = imageLibrary.GreenCubeBombHintSprite;
                    _hintedSprite2 = imageLibrary.GreenCubeRocketHintSprite;
                    break;
                case MatchType.Yellow:
                    _defaultSprite = imageLibrary.YellowCubeSprite;
                    _hintedSprite = imageLibrary.YellowCubeBombHintSprite;
                    _hintedSprite2 = imageLibrary.YellowCubeRocketHintSprite;
                    break;
                case MatchType.Blue:
                    _defaultSprite = imageLibrary.BlueCubeSprite;
                    _hintedSprite = imageLibrary.BlueCubeBombHintSprite;
                    _hintedSprite2 = imageLibrary.BlueCubeRocketHintSprite;

                    break;
                case MatchType.Red:
                    _defaultSprite = imageLibrary.RedCubeSprite;
                    _hintedSprite = imageLibrary.RedCubeBombHintSprite;
                    _hintedSprite2 = imageLibrary.RedCubeRocketHintSprite;

                    break;
            }
        }

        public override MatchType GetMatchType()
        {
            return _matchType;
        }

        public override bool CanBeMatchedByTouch()
        {
            return true;
        }

        public override bool TryExecute(MatchType matchType)
        {
            ServiceProvider.GetParticleManager.PlayCubeParticle(this);
            
            return base.TryExecute();
        }

        public override void SetHinted(int hinted)
        {
            if (hinted == 0) SpriteRenderer.sprite = _defaultSprite;
            if (hinted == 1) SpriteRenderer.sprite = _hintedSprite;         
            if (hinted == 2) SpriteRenderer.sprite = _hintedSprite2;
        }
    }
}
