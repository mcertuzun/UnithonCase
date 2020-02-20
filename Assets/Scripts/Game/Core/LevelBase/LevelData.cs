using Game.Core.Enums;
using UnityEngine;

namespace Game.Core.LevelBase
{
	public abstract class LevelData
	{		
		public abstract ItemType GetNextFillItemType();
		public abstract void Initialize();

		public ItemType[,] GridData { get; protected set; }

		private static readonly ItemType[] DefaultCubeArray = new[]
		{
			ItemType.GreenCube,
			ItemType.YellowCube,
			ItemType.BlueCube,
			ItemType.RedCube
		};

		protected static ItemType GetRandomCubeItemType()
		{
			return GetRandomItemTypeFromArray(DefaultCubeArray);
		}

		protected static ItemType GetRandomItemTypeFromArray(ItemType[] itemTypeArray)
		{
			return itemTypeArray[Random.Range(0, itemTypeArray.Length)];
		}
	}
}
