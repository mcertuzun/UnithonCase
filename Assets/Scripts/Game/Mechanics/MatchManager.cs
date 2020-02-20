using System.Collections.Generic;
using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Managers;
using UnityEngine;

namespace Game.Mechanics
{
    public class MatchManager : MonoBehaviour
    {
        public Board Board;
        ParticleSystem particle = null;
        private readonly MatchFinder _matchFinder = new MatchFinder();

        private void Update()
        {
            _matchFinder.ClearVisitedCells();

            for (var y = 0; y < Board.Rows; y++)
            {
                for (var x = 0; x < Board.Cols; x++)
                {
                    var cell = Board.Cells[x, y];

                    if (!cell.HasItem() || cell.Item.GetMatchType() == MatchType.None) continue;

                    var resultCells = new List<Cell>();
                    _matchFinder.FindMatches(cell, cell.Item.GetMatchType(), resultCells);

                    foreach (var resultCell in resultCells)
                    {
                        if (resultCell.Item.GetMatchType() == MatchType.Special && resultCells.Count >= 2 && resultCell.Item.GetParticle() == null)
                        {
                            particle = ServiceProvider.GetParticleManager.PlayComboParticleOnItem(resultCell.Item);
                            resultCell.Item.SetParticle(particle);
                        }
                        else if (resultCell.Item.GetMatchType() == MatchType.Special && resultCells.Count < 2 && resultCell.Item.GetParticle() != null)
                        {
                            ServiceProvider.GetParticleManager.StopParticle(resultCell.Item.GetParticle());

                        }
                        var item = resultCell.Item;
                        if (item != null)
                        {
                            int hint = 0;
                            if (resultCells.Count >= Board.MakeBombCount)
                            {
                                hint = 1;
                            }
                            else if (resultCells.Count >= Board.MakeRocketCount)
                            {
                                hint = 2;
                            }
                            item.SetHinted(hint);
                        }
                    }
                }
            }
        }
   
    }
}
