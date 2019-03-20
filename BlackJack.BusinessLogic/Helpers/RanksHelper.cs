using BlackJack.BusinessLogic.Helpers.Interfaces;
using BlackJack.DataAccess.Enums;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Helpers
{
    public class RanksHelper : IRanksHelper
    {
        public int TotalValue(IEnumerable<RankType> steps)
        {
            int totalSum = 0;
            foreach (var card in steps)
            {
                if (card == RankType.Ace && totalSum <= 10)
                {
                    totalSum += 11;
                }
                else if (card == RankType.Ace && totalSum > 10 && totalSum < 21)
                {
                    totalSum += 1;
                }
                else if (card == RankType.Jack || card == RankType.King || card == RankType.Queen)
                {
                    totalSum += 10;
                }
                switch (card)
                {
                    case RankType.Two:
                        totalSum += 2;
                        break;
                    case RankType.Three:
                        totalSum += 3;
                        break;
                    case RankType.Four:
                        totalSum += 4;
                        break;
                    case RankType.Five:
                        totalSum += 5;
                        break;
                    case RankType.Six:
                        totalSum += 6;
                        break;
                    case RankType.Seven:
                        totalSum += 7;
                        break;
                    case RankType.Eight:
                        totalSum += 8;
                        break;
                    case RankType.Nine:
                        totalSum += 9;
                        break;
                    case RankType.Ten:
                        totalSum += 10;
                        break;
                }
            }
            return totalSum;
        }
    }
}
