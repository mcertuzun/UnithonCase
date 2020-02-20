using Game.Core.Enums;
using Game.Levels;

namespace Game.Core.LevelBase
{
    public static class LevelDataFactory
    {
        public static LevelData CreateLevelData(LevelName levelName)
        {
            LevelData levelData;
            switch (levelName)
            {
                case LevelName.Level0:
                    levelData = new LevelData_0();
                    break;
                case LevelName.Level1:
                    levelData = new LevelData_1();
                    break;
                case LevelName.Level2:
                    levelData = new LevelData_2();
                    break;
                case LevelName.Level3:
                    levelData = new LevelData_3();
                    break;
                case LevelName.Level4:
                    levelData = new LevelData_4();
                    break;
                case LevelName.Level5_1:
                    levelData = new LevelData_5_1();
                    break;
                case LevelName.Level5_2:
                    levelData = new LevelData_5_2();
                    break;
                case LevelName.LevelTest1:
                    levelData = new LevelTest_1();
                    break;
                case LevelName.LevelTest2:
                    levelData = new LevelTest_2();
                    break;
                default:
                    levelData = new LevelData_0();
                    break;
            }

            levelData.Initialize();
            return levelData;
        }
    }
}