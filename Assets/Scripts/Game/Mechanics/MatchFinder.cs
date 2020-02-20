using System.Collections.Generic;
using Game.Core.BoardBase;
using Game.Core.Enums;

namespace Game.Mechanics
{
	public class MatchFinder
	{
		private readonly bool[,] _visitedCells = new bool[Board.Rows, Board.Cols];
		
		/// <summary>
		/// Returns the list of matching cells according to the given match type.
		/// Returns only the given cell if there are no neighbour items with the given match type.
		/// </summary>
		public List<Cell> FindMatches(Cell cell, MatchType matchType)
		{
			var resultCells = new List<Cell>();
			ClearVisitedCells();
			FindMatches(cell, matchType, resultCells);

			return resultCells;
		}

		public void FindMatches(Cell cell, MatchType matchType, List<Cell> resultCells)
		{
			if (cell == null) return;
			
			var x = cell.X;
			var y = cell.Y;
			if (_visitedCells[x, y]) return;
			
			if (cell.HasItem() &&
			    !cell.Item.CanBeExplodedByNeighbourMatch() &&
			    cell.Item.GetMatchType() == matchType &&
			    cell.Item.GetMatchType() != MatchType.None)
			{
				_visitedCells[x, y] = true;
				resultCells.Add(cell);
			
				var neighbours = cell.Neighbours;
				if (neighbours.Count == 0) return;
	
				for (var i = 0; i < neighbours.Count; i++)
				{	
					FindMatches(neighbours[i], matchType, resultCells);
				}
			}
		}

		public void ClearVisitedCells()
		{
			for (var x = 0; x < _visitedCells.GetLength(0); x++)
			{
				for (var y = 0; y < _visitedCells.GetLength(1); y++)
				{
					_visitedCells[x, y] = false;
				}
			}
		}
	}
}
