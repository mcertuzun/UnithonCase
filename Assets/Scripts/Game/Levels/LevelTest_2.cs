using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.LevelBase;

namespace Game.Levels
{
    public class LevelTest_2 : LevelData
    {
        public override ItemType GetNextFillItemType()
        {
            return GetRandomCubeItemType();
        }

        public override void Initialize()
        {
            GridData = new ItemType[Board.Rows, Board.Cols];
            
            GridData[0, 4] = ItemType.Pinwheel;
            GridData[8, 4] = ItemType.Pinwheel;
            
            GridData[0, 8] = ItemType.Duck;
            GridData[8, 8] = ItemType.Duck;
            
            GridData[4, 7] = ItemType.VerticalRocket;
            GridData[4, 6] = ItemType.Bomb;
            GridData[4, 5] = ItemType.VerticalRocket;
            GridData[3, 4] = ItemType.HorizontalRocket;
            GridData[5, 4] = ItemType.HorizontalRocket;

            GridData[1, 1] = ItemType.Bomb;
            GridData[1, 2] = ItemType.Bomb;
            GridData[2, 1] = ItemType.HorizontalRocket;
            GridData[6, 1] = ItemType.HorizontalRocket;
            GridData[7, 1] = ItemType.HorizontalRocket;
            GridData[7, 2] = ItemType.HorizontalRocket;

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