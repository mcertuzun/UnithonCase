using System;
using System.Collections.Generic;
using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Items;
using Game.Managers;
using Game.Mechanics;
using UnityEngine;

namespace Game.Core.BoardBase
{
	public class Board : MonoBehaviour
	{
		public const int Rows = 9;
		public const int Cols = 9;
		
		public const int MakeRocketCount = 5; 
		public const int MakeBombCount = 7; 
		public const int MinimumMatchCount = 2; 
	
		public Cell CellPrefab;
		
		public Transform CellsParent;
		public Transform ItemsParent;
		public Transform ParticlesParent;

		[HideInInspector] public Cell[,] Cells = new Cell[Cols, Rows];

		private SpecialItemManager _specialItemManager;
		private readonly MatchFinder _matchFinder = new MatchFinder();
	
		public void Prepare()
		{
			CreateCells();
			PrepareCells();
			_specialItemManager = ServiceProvider.GetSpecialItemManager;
		}
		
		private void CreateCells()
		{
			for (var y = 0; y < Rows; y++)
			{
				for (var x = 0; x < Cols; x++)
				{
					var cell = Instantiate(CellPrefab, Vector3.zero, Quaternion.identity, CellsParent);
					Cells[x, y] = cell;
				}
			}
		}

		private void PrepareCells()
		{
			for (var y = 0; y < Rows; y++)
			{
				for (var x = 0; x < Cols; x++)
				{
					Cells[x, y].Prepare(x, y, this);
				}
			}
		}

		public void CellTapped(Cell cell)
		{
			if (cell == null) return;
            
			if (!cell.HasItem()) return;
			if(cell.Item.CanBeExplodedByTouch())
			{
				cell.Item.TryExecute();				
			}
			else if (cell.Item.CanBeMatchedByTouch())
			{
				ExplodeMatchingCells(cell);				
			}
        }

		private void ExplodeMatchingCells(Cell cell)
		{
            var cells = _matchFinder.FindMatches(cell, cell.Item.GetMatchType());
			if (cells.Count < MinimumMatchCount) return;
            MatchType matchedType = cell.Item.GetMatchType();
            var effectedCells = new HashSet<Cell>();
			for (var i = 0; i < cells.Count; i++)
			{
				var explodedCell = cells[i];
				var item = explodedCell.Item;
               
                if (item.TryExecute(matchedType))
				{
					foreach (var neighbour in explodedCell.Neighbours)
					{
						if (neighbour.HasItem() && neighbour.Item.CanBeExplodedByNeighbourMatch())
						{
							effectedCells.Add(neighbour);
						}
					}
				}
			}

			foreach (var effectedCell in effectedCells)
			{
				var item = effectedCell.Item;
				item.TryExecute(matchedType);
			}
			
			if (cells.Count < MakeRocketCount) return;
            if(cells.Count>=MakeRocketCount && cells.Count < MakeBombCount)
            {
                int random = UnityEngine.Random.Range(0, 2);
                if (random == 0)
                {
                    var bomb = ItemFactory.CreateItem(ItemType.HorizontalRocket, ItemsParent);
                    cell.Item = bomb;
                    bomb.transform.position = cell.transform.position;
                }
                else
                {
                    var bomb = ItemFactory.CreateItem(ItemType.VerticalRocket, ItemsParent);
                    cell.Item = bomb;
                    bomb.transform.position = cell.transform.position;
                }
                

            }
            else if (cells.Count>=MakeBombCount) { 
			var bomb = ItemFactory.CreateItem(ItemType.Bomb, ItemsParent);
			cell.Item = bomb;
			bomb.transform.position = cell.transform.position;
            }
		}

		public Cell GetNeighbourWithDirection(Cell cell, Direction direction)
		{
			var x = cell.X;
			var y = cell.Y;
			switch (direction)
			{
				case Direction.None:
					break;
				case Direction.Up:
					y += 1;
					break;
				case Direction.UpRight:
					y += 1;
					x += 1;
					break;
				case Direction.Right:
					x += 1;
					break;
				case Direction.DownRight:
					y -= 1;
					x += 1;
					break;
				case Direction.Down:
					y -= 1;
					break;
				case Direction.DownLeft:
					y -= 1;
					x -= 1;
					break;
				case Direction.Left:
					x -= 1;
					break;
				case Direction.UpLeft:
					y += 1;
					x -= 1;
					break;
				default:
					throw new ArgumentOutOfRangeException("direction", direction, null);
			}

			if (x >= Cols || x < 0 || y >= Rows || y < 0) return null;

			return Cells[x, y];
		}
	}
}
