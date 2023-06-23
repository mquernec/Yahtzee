using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Yatzy
{
    public static class Yatzy
    {

        public static int Chance(int[] dice)
        {
            return dice.Sum();
        }

        public static int yatzy(int[] dice)
        {
            if (ScoreTuple(dice, 5) > 0)
                return 50;
            return 0;
        }

        public static int OfAKind(int[] dice, int kind) => (dice.Count(x => x == kind) * kind);


        public static int ScorePair(int[] dices)
        {
            return ScoreTuple(dices, 2);
        }

        public static int TwoPair(int[] dices)
        {
            var dispatch = dices.GroupBy(x => x, (value, dice) => new
            {
                Key = value,
                Count = dice.Count(),
            });
            var res = dispatch.Where(k => k.Count >= 2).Select(k => k.Key * 2);

            if (res.Count() > 1)
            {
                var topTwo = res.OrderByDescending(k => k).Take(2);
                return topTwo.Sum();
            }

            return 0;
        }

        public static int FourOfAKind(int[] dices) => ScoreTuple(dices, 4);

        public static int ThreeOfAKind(int[] dices)=> ScoreTuple(dices, 3);
        public static int SmallStraight(int[] dices)
        {
            var target = new[] { 1, 2, 3, 4, 5 };

            if (dices.Intersect(target).Count() == target.Length) return 15;
            
            return 0;
        }

        public static int LargeStraight(int[] dices)
        {
            var target = new[] { 2, 3, 4, 5, 6 };

            if (dices.Intersect(target).Count() == target.Length) return 20;

            return 0;
        }

        public static int FullHouse(int[] dices)
        {
            var dispatch = dices.GroupBy(x => x, (value, dice) => new
            {
                Key = value,
                Count = dice.Count(),
            });

            var listTriple = dispatch.Where(k => k.Count > 2).Select(k => k.Key * 3);
            var listDouble = dispatch.Where(k => k.Count == 2).Select(k => k.Key * 2);
            if (listTriple.Any() && listDouble.Any())
            {
                return listTriple.Max() + listDouble.Max();
            }

            return 0;
        }

        /// <summary>
        ///  look for a dice value repeated "tupleSize" time and add value
        /// </summary>
        /// <param name="dices"> pool of dice to examine</param>
        /// <param name="tupleSize"> size of searched tuple</param>
        /// <returns>sum of dice of the tuple</returns>
        public static int ScoreTuple(int[] dices, int tupleSize)
        {
            //grouping dice by value , and counting
            var dispatch = dices.GroupBy(x => x, (value, dice) => new
            {
                Key = value,
                Count = dice.Count(),
            });
            //if there a tuple , score it
            if (dispatch.Any(k => k.Count >= tupleSize))
            {
                var res = dispatch.Where(k => k.Count >= tupleSize).Select(k => k.Key * tupleSize).ToList().Max(x => x);
                return res;
            }
            //else no point
            return 0;
        }

    }
}