using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.LevelBase;

namespace Game.Levels
{
    public class LevelData_1 : LevelData
    {
        public override ItemType GetNextFillItemType()
        {
            return GetRandomCubeItemType();
        }

        public override void Initialize()
        {
            GridData = new ItemType[Board.Rows, Board.Cols];

            GridData[0, 0] = ItemType.GreenBalloon;
            GridData[0, 1] = ItemType.YellowBalloon;
            GridData[0, 2] = ItemType.BlueBalloon;
            GridData[0, 3] = ItemType.RedBalloon;
            GridData[0, 4] = ItemType.GreenBalloon;
            GridData[0, 5] = ItemType.YellowBalloon;
            GridData[0, 6] = ItemType.BlueBalloon;
            GridData[0, 7] = ItemType.RedBalloon;
            GridData[0, 8] = ItemType.GreenBalloon;
            
            GridData[8, 0] = ItemType.GreenBalloon;
            GridData[8, 1] = ItemType.YellowBalloon;
            GridData[8, 2] = ItemType.BlueBalloon;
            GridData[8, 3] = ItemType.RedBalloon;
            GridData[8, 4] = ItemType.GreenBalloon;
            GridData[8, 5] = ItemType.YellowBalloon;
            GridData[8, 6] = ItemType.BlueBalloon;
            GridData[8, 7] = ItemType.RedBalloon;
            GridData[8, 8] = ItemType.GreenBalloon;

            for (var y = 0; y < Board.Rows; y++)
            {
                for (var x = 1; x < Board.Cols - 1; x++)
                {
                    if(GridData[x, y] != ItemType.None) continue; 
                    GridData[x, y] = GetRandomCubeItemType();
                }
            }            
        }
    }
}