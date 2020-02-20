using System;
using Game.Core.Enums;
using Game.Items;
using UnityEngine;

namespace Game.Core.ItemBase
{
    public static class ItemFactory
    {
        private static GameObject _itemBasePrefab;

        public static Item CreateItem(ItemType itemType, Transform parent)
        {
            if (_itemBasePrefab == null)
            {
                _itemBasePrefab = Resources.Load("ItemBase") as GameObject;
            }
            
            var itemBase = GameObject.Instantiate(
                _itemBasePrefab, Vector3.zero, Quaternion.identity, parent).GetComponent<ItemBase>();
            
            Item item = null;
            switch (itemType)
            {
                case ItemType.GreenCube:
                    item = CreateCubeItem(itemBase, MatchType.Green);
                    break;
                case ItemType.YellowCube:
                    item = CreateCubeItem(itemBase, MatchType.Yellow);
                    break;
                case ItemType.BlueCube:
                    item = CreateCubeItem(itemBase, MatchType.Blue);
                    break;
                case ItemType.RedCube:
                    item = CreateCubeItem(itemBase, MatchType.Red);
                    break;    
                case ItemType.Crate:
                    item = CreateCrateItem(itemBase);
                    break;
                case ItemType.Balloon:
                    item = CreateBalloonItem(itemBase);
                    break;
                case ItemType.GreenBalloon:
                    item = CreateColorBalloonItem(itemBase, MatchType.Green);
                    break;
                case ItemType.YellowBalloon:
                    item = CreateColorBalloonItem(itemBase, MatchType.Yellow);
                    break;
                case ItemType.BlueBalloon:
                    item = CreateColorBalloonItem(itemBase, MatchType.Blue);
                    break;
                case ItemType.RedBalloon:
                    item = CreateColorBalloonItem(itemBase, MatchType.Red);
                    break;
                case ItemType.Bomb:
                    item = CreateBombItem(itemBase);
                    break; 
                case ItemType.Pinwheel:
                    item = CreatePinwheelItem(itemBase);
                    break;
                case ItemType.Duck:
                    item = CreateDuckItem(itemBase);
                    break;
                case ItemType.HorizontalRocket:
                    item = CreateRocketItem(itemBase, ItemType.HorizontalRocket);
                    break;
                case ItemType.VerticalRocket:
                    item = CreateRocketItem(itemBase, ItemType.VerticalRocket);
                    break;
                default:
                    Debug.LogWarning("Can not create item: " + itemType);
                    break;
            }
            
            return item;
        }

        private static Item CreateRocketItem(ItemBase itemBase, ItemType itemType)
        {
            var rocketItem = itemBase.gameObject.AddComponent<RocketItem>();
            rocketItem.PrepareRocketItem(itemBase, itemType);

            return rocketItem;
        }


        private static Item CreateDuckItem(ItemBase itemBase)
        {
            var duckItem = itemBase.gameObject.AddComponent<DuckItem>();
            duckItem.PrepareDuckItem(itemBase);

            return duckItem;
        }

        private static Item CreateCubeItem(ItemBase itemBase, MatchType matchType)
        {
            var cubeItem = itemBase.gameObject.AddComponent<CubeItem>();
            cubeItem.PrepareCubeItem(itemBase, matchType);
            
            return cubeItem;
        }
        
        private static Item CreateCrateItem(ItemBase itemBase)
        {
            var crateItem = itemBase.gameObject.AddComponent<CrateItem>();
            crateItem.PrepareCrateItem(itemBase);
            return crateItem;
        }

        private static Item CreatePinwheelItem(ItemBase itemBase)
        {
            var pinwheelItem = itemBase.gameObject.AddComponent<PinwheelItem>();
            pinwheelItem.PreparePinwheelItem(itemBase);
            return pinwheelItem;
        }
        
        private static Item CreateBalloonItem(ItemBase itemBase)
        {
            var balloonItem = itemBase.gameObject.AddComponent<BalloonItem>();
            balloonItem.PrepareBalloonItem(itemBase);
            return balloonItem;
        }
        
        private static Item CreateColorBalloonItem(ItemBase itemBase, MatchType matchType)
        {
            var colorBalloonItem = itemBase.gameObject.AddComponent<ColorBalloonItem>();
            colorBalloonItem.PrepareColorBalloonItem(itemBase, matchType);
            return colorBalloonItem;
        }
        
        private static Item CreateBombItem(ItemBase itemBase)
        {
            var bombItem = itemBase.gameObject.AddComponent<BombItem>();
            bombItem.PrepareBombItem(itemBase);
            return bombItem;
        }
    }
}
