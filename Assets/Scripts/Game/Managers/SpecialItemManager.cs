using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.ItemBase;
using UnityEngine;

namespace Game.Managers
{
    public class SpecialItemManager : IProvidable
    {

        public void explodeRow(Item item)
        {

            for (var x = 0; x < 9; x++)
            {
                var cell = item.Cell.Board.Cells[x, item.Cell.Y];

                if (cell.HasItem() )
                {
                    cell.Item.TryExecute(item.GetMatchType());
                }
            }

        }
        public void explodeColumn(Item item)
        {
            for (var y = 0; y < 9; y++)
            {
                var cell = item.Cell.Board.Cells[item.Cell.X, y];

                if (cell.HasItem())
                {
                    cell.Item.TryExecute(item.GetMatchType());
                }
            }
        }

        public void explodeBomb(Item item, int n)
        {
            var minX = Mathf.Max(0, item.Cell.X - n);
            var maxX = Mathf.Min(Board.Cols - n, item.Cell.X + n);

            var minY = Mathf.Max(0, item.Cell.Y - n);
            var maxY = Mathf.Min(Board.Rows - n, item.Cell.Y + n);

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var cell = item.Cell.Board.Cells[x, y];

                    if (cell.HasItem())
                    {
                        cell.Item.TryExecute(item.GetMatchType());
                    }
                }
            }
        }

        public void SpecialExplosion()
        {
           
        }
    }
}