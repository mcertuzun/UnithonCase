using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.LevelBase;

namespace Game.Levels
{
    public class LevelData_4 : LevelData
    {
        public override ItemType GetNextFillItemType()
        {
            return GetRandomCubeItemType();
        }

        public override void Initialize()
        {
            GridData = new ItemType[Board.Rows, Board.Cols];
            
            GridData[3, 5] = ItemType.HorizontalRocket;
            GridData[5, 3] = ItemType.HorizontalRocket;
            GridData[4, 0] = ItemType.HorizontalRocket;
            GridData[4, 8] = ItemType.HorizontalRocket;
            
            GridData[3, 3] = ItemType.VerticalRocket;
            GridData[5, 5] = ItemType.VerticalRocket;
            GridData[0, 0] = ItemType.VerticalRocket;
            GridData[8, 0] = ItemType.VerticalRocket;
            
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