using System.Collections.Generic;
using Game.Core.Enums;
using Game.Core.ItemBase;
using UnityEngine;

namespace Game.Core.BoardBase
{
	public class Cell : MonoBehaviour
	{
		public TextMesh LabelText;

		[HideInInspector] public int X;
		[HideInInspector] public int Y;

		[HideInInspector] public Cell FirstCellBelow;
		[HideInInspector] public bool IsFillingCell;
		
		public List<Cell> Neighbours { get; private set; }
		
		private Item _item;

		public Board Board { get; private set; }

		public Item Item
		{
			get
			{
				return _item;
			}
			set
			{
				if (_item == value) return;
				
				var oldItem = _item;
				_item = value;
				
				if (oldItem != null && Equals(oldItem.Cell, this))
				{
					oldItem.Cell = null;
				}
				if (value != null)
				{
					value.Cell = this;
				}
			}
		}

		public void Prepare(int x, int y, Board board)
		{
			X = x;
			Y = y;
			transform.localPosition = new Vector3(x,y);
			IsFillingCell = Y == Board.Rows - 1;
			Board = board;
			
			UpdateLabel();
			UpdateNeighbours(Board);
		}

		private void UpdateNeighbours(Board board)
		{
			Neighbours = new List<Cell>();
			var up = board.GetNeighbourWithDirection(this, Direction.Up);
			var down = board.GetNeighbourWithDirection(this, Direction.Down);
			var left = board.GetNeighbourWithDirection(this, Direction.Left);
			var right = board.GetNeighbourWithDirection(this, Direction.Right);
			
			if(up!=null) Neighbours.Add(up);
			if(down!=null) Neighbours.Add(down);
			if(left!=null) Neighbours.Add(left);
			if(right!=null) Neighbours.Add(right);

			if (down != null) FirstCellBelow = down;
		}

		private void UpdateLabel()
		{
			var cellName = X + ":" + Y;
			LabelText.text = cellName;
			gameObject.name = "Cell "+cellName;
		}

		public bool HasItem()
		{
			return Item != null;
		}
		
		public override string ToString()
		{
			return gameObject.name;
		}

		public Cell GetFallTarget()
		{
			var targetCell = this;
			while (targetCell.FirstCellBelow != null && targetCell.FirstCellBelow.Item == null)
			{
				targetCell = targetCell.FirstCellBelow;
			}
			return targetCell;
		}
	}
}
