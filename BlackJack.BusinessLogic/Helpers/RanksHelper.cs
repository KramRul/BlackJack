using BlackJack.BusinessLogic.Helpers.Interfaces;
using BlackJack.DataAccess.Enums;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Helpers
{
    public class RanksHelper : IRanksHelper
    {
        public int TotalValue(IEnumerable<Rank> steps)
        {
            int totalSum = 0;
            foreach (var card in steps)
            {
                if (card == Rank.Ace && totalSum <= 10)
                {
                    totalSum += 11;
                }
                else if (card == Rank.Ace && totalSum > 10 && totalSum < 21)
                {
                    totalSum += 1;
                }
                else if (card == Rank.Jack || card == Rank.King || card == Rank.Queen)
                {
                    totalSum += 10;
                }
                switch (card)
                {
                    case Rank.Two:
                        totalSum += 2;
                        break;
                    case Rank.Three:
                        totalSum += 3;
                        break;
                    case Rank.Four:
                        totalSum += 4;
                        break;
                    case Rank.Five:
                        totalSum += 5;
                        break;
                    case Rank.Six:
                        totalSum += 6;
                        break;
                    case Rank.Seven:
                        totalSum += 7;
                        break;
                    case Rank.Eight:
                        totalSum += 8;
                        break;
                    case Rank.Nine:
                        totalSum += 9;
                        break;
                    case Rank.Ten:
                        totalSum += 10;
                        break;
                }
            }
            return totalSum;
        }
    }
}
