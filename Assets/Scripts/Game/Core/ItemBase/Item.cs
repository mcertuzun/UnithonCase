using System.Collections.Generic;
using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Mechanics;
using UnityEngine;

namespace Game.Core.ItemBase
{
	public abstract class Item : MonoBehaviour
	{
		private const int BaseSortingOrder = 10;
        public ParticleSystem _particleSystem;
		public SpriteRenderer SpriteRenderer;
		public FallAnimation FallAnimation;
        public ItemType _itemType;
		private int _childSpriteOrder;

		public bool IsDestroyed { get; private set; }

		private Cell _cell;
		public Cell Cell
		{
			get { return _cell; }
			set
			{
				if (_cell == value) return;
				
				var oldCell = _cell;
				_cell = value;
				
				if (oldCell != null && oldCell.Item == this)
				{
					oldCell.Item = null;
				}

				if (value != null)
				{
					value.Item = this;
					gameObject.name = _cell.gameObject.name + " " + GetType().Name;
				}
				
			}
		}

		public SpriteRenderer AddSprite(Sprite sprite)
		{
			var spriteRenderer = new GameObject("Sprite_" + _childSpriteOrder).AddComponent<SpriteRenderer>();
			spriteRenderer.transform.SetParent(transform);
			spriteRenderer.sprite = sprite;
			spriteRenderer.sortingLayerID = SortingLayer.NameToID("Item");
			spriteRenderer.sortingOrder = BaseSortingOrder + _childSpriteOrder++;

			return spriteRenderer;
		}

		public void RemoveSprite(SpriteRenderer spriteRenderer)
		{
			if (spriteRenderer == SpriteRenderer)
			{
				SpriteRenderer = null;
			}
			
			Destroy(spriteRenderer.gameObject);
		}

		public virtual MatchType GetMatchType()
		{
			return MatchType.None;
		}

        public virtual ItemType GetItemType()
        {
            return ItemType.None;
        }
     
		public virtual bool CanBeExplodedByTouch()
		{
			return false;
		}
        public virtual bool CanBeExploring()
        {
            return false;
        }

        public virtual bool CanBeMatchedByTouch()
		{
			return false;
		}

		public virtual bool CanFall()
		{
			return true;
		}

		public bool IsFalling()
		{            
			return FallAnimation.IsFalling;
		}
        public virtual void afterFalled()
        {
            
        }
        public virtual bool CanBeExplodedByNeighbourMatch()
		{
			return false;
		}
		
		public virtual bool TryExecute(MatchType matchType = MatchType.None)
		{
            RemoveItem();			
			return true;
		}

		public void RemoveItem()
		{
			Cell.Item = null;
			Cell = null;
			
			IsDestroyed = true;
			Destroy(gameObject);
		}

		public void Prepare(ItemBase itemBase, Sprite sprite)
		{
			SpriteRenderer = AddSprite(sprite);
			FallAnimation = itemBase.FallAnimation;
			FallAnimation.Item = this;		
		}

		public void Fall()
		{
			if (CanFall())
			{
				FallAnimation.FallTo(Cell.GetFallTarget());				
			}
		}
		
		public override string ToString()
		{
			return gameObject.name;
		}

		public virtual void SetHinted(int hinted)
		{
		}
        public virtual void SetParticle(ParticleSystem particle)
		{
            this._particleSystem = particle;
		}
        public virtual ParticleSystem GetParticle()
		{
            return this._particleSystem;
		}
	}
}
