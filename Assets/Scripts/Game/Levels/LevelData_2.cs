using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.LevelBase;
using UnityEngine;

namespace Game.Levels
{
    public class LevelData_2 : LevelData
    {
        public override ItemType GetNextFillItemType()
        {
            return Random.Range(0, 10) < 1 ? ItemType.Bomb : GetRandomCubeItemType();
        }

        public override void Initialize()
        {
            GridData = new ItemType[Board.Rows, Board.Cols];
            
            GridData[2, 2] = ItemType.Pinwheel;
            GridData[2, 6] = ItemType.Pinwheel;
            
            GridData[6, 2] = ItemType.Pinwheel;
            GridData[6, 6] = ItemType.Pinwheel;

            for (var y = 0; y < Board.Rows; y++)
            {
                for (var x = 0; x < Board.Cols; x++)
                {
                    if(GridData[x, y] != ItemType.None) continue; 
                    GridData[x, y] = GetRandomCubeItemType();
                }
            }            
        }
    }
}