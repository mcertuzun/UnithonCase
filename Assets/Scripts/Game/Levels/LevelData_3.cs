using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.LevelBase;

namespace Game.Levels
{
    public class LevelData_3 : LevelData
    {
        public override ItemType GetNextFillItemType()
        {
            return GetRandomCubeItemType();
        }

        public override void Initialize()
        {
            GridData = new ItemType[Board.Rows, Board.Cols];
            
            GridData[1, 8] = ItemType.Duck;
            GridData[7, 8] = ItemType.Duck;

            GridData[1, 0] = ItemType.RedCube;
            GridData[1, 1] = ItemType.RedCube;
            GridData[1, 2] = ItemType.YellowCube;
            GridData[1, 3] = ItemType.YellowCube;
            GridData[1, 4] = ItemType.BlueCube;
            GridData[1, 5] = ItemType.BlueCube;
            GridData[1, 6] = ItemType.GreenCube;
            GridData[1, 7] = ItemType.GreenCube;
            
            GridData[7, 0] = ItemType.GreenCube;
            GridData[7, 1] = ItemType.GreenCube;
            GridData[7, 2] = ItemType.BlueCube;
            GridData[7, 3] = ItemType.BlueCube;
            GridData[7, 4] = ItemType.YellowCube;
            GridData[7, 5] = ItemType.YellowCube;
            GridData[7, 6] = ItemType.RedCube;
            GridData[7, 7] = ItemType.RedCube;
            
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