using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.LevelBase;
using UnityEngine;

namespace Game.Levels
{
    public class LevelTest_1 : LevelData
    {
        public override ItemType GetNextFillItemType()
        {
            return GetRandomFillItemType();
        }

        private ItemType GetRandomFillItemType()
        {
            return Random.Range(0, 10) < 2 ? GetRandomColorBalloonType() : GetRandomCubeItemType();
        }

        private ItemType GetRandomColorBalloonType()
        {
            return ItemType.GreenBalloon + Random.Range(0, 4);
        }

        public override void Initialize()
        {
            GridData = new ItemType[Board.Rows, Board.Cols];

            for (int i = 1; i < Board.Rows; i++)
            {
                GridData[0, i] = ItemType.Crate;
                GridData[8, i] = ItemType.Crate;
            }
            GridData[0, 0] = ItemType.Pinwheel;
            GridData[8, 0] = ItemType.Pinwheel;
            
            GridData[1, 0] = ItemType.Bomb;
            GridData[1, 1] = ItemType.VerticalRocket;
            GridData[4, 3] = ItemType.HorizontalRocket;
            GridData[4, 4] = ItemType.HorizontalRocket;
            GridData[4, 5] = ItemType.HorizontalRocket;
            GridData[7, 7] = ItemType.Bomb;
            GridData[7, 8] = ItemType.Bomb;

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