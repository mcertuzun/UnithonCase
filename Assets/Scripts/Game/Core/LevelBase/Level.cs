using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Mechanics;
using UnityEngine;

namespace Game.Core.LevelBase
{
	public class Level : MonoBehaviour 
	{
		public LevelName CurrentLevel;
		public Board Board;
		public FallAndFillManager FallAndFillManager;
		
		private LevelData _levelData;
		
		void Start ()
		{
			PrepareBoard();
			PrepareLevel();
			StartFalls();
		}

		private void PrepareLevel()
		{
			_levelData = LevelDataFactory.CreateLevelData(CurrentLevel);

			for (var y = 0; y < _levelData.GridData.GetLength(0); y++)
			{
				for (var x = 0; x < _levelData.GridData.GetLength(1); x++)
				{
					var cell = Board.Cells[x, y];
					
					var itemType = _levelData.GridData[x, y];
					var item = ItemFactory.CreateItem(itemType, Board.ItemsParent);
					if (item == null) continue;					
					 					
					cell.Item = item;
					item.transform.position = cell.transform.position;
				}
			}
		}

		private void PrepareBoard()
		{
			Board.Prepare();
		}

		private void StartFalls()
		{
			FallAndFillManager.Init(Board, _levelData);
			FallAndFillManager.StartFalls();
		}
		
	}
}
