using Xunit;

namespace Yatzy.Test
{
    public class YatzyTest
    {
        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            var expected = 15;
            var actual = Yatzy.Chance(new[] {2, 3, 4, 5, 1});
            Assert.Equal(expected, actual);
            Assert.Equal(16, Yatzy.Chance(new[] {3, 3, 4, 5, 1}));
        }

        [Fact]
        public void Fact_1s()
        {
            Assert.Equal(1,Yatzy.OfAKind(new[] {1, 2, 3, 4, 5},1));
            Assert.Equal(2, Yatzy.OfAKind(new[] {1, 2, 1, 4, 5},1));
            Assert.Equal(0, Yatzy.OfAKind(new[] {6, 2, 2, 4, 5},1));
            Assert.Equal(4, Yatzy.OfAKind(new[] {1, 2, 1, 1, 1},1));
        }

        [Fact]
        public void Fact_2s()
        {
            Assert.Equal(4, Yatzy.OfAKind(new[] {1, 2, 3, 2, 6},2));
            Assert.Equal(10, Yatzy.OfAKind(new[] {2, 2, 2, 2, 2},2));
        }

        [Fact]
        public void Fact_threes()
        {
            Assert.Equal(6, Yatzy.OfAKind(new[] {1, 2, 3, 2, 3},3));
            Assert.Equal(12, Yatzy.OfAKind(new[] {2, 3, 3, 3, 3},3));
        }

        [Fact]
        public void fives()
        {
            Assert.Equal(10, Yatzy.OfAKind(new[] {4, 4, 4, 5, 5},5));
            Assert.Equal(15, Yatzy.OfAKind(new[] {4, 4, 5, 5, 5},5));
            Assert.Equal(20, Yatzy.OfAKind(new[] {4, 5, 5, 5, 5},5));
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, Yatzy.FourOfAKind(new[] {3, 3, 3, 3, 5}));
            Assert.Equal(20, Yatzy.FourOfAKind(new[] {5, 5, 5, 4, 5}));
            Assert.Equal(12, Yatzy.FourOfAKind(new[] {3, 3, 3, 3, 3}));
        }

        [Fact]
        public void fours_Fact()
        {
            Assert.Equal(12, Yatzy.OfAKind(new[] {4, 4, 4, 5, 5},4));
            Assert.Equal(8, Yatzy.OfAKind(new[] {4, 4, 5, 5, 5},4));
            Assert.Equal(4, Yatzy.OfAKind(new[] {4, 5, 5, 5, 5},4));
        }

        [Fact]
        public void fullHouse()
        {
            Assert.Equal(18, Yatzy.FullHouse(new[] {6, 2, 2, 2, 6}));
            Assert.Equal(0, Yatzy.FullHouse(new[] {2, 3, 4, 5, 6}));
        }

        [Fact]
        public void largeStraight()
        {
            Assert.Equal(20, Yatzy.LargeStraight(new[] {6, 2, 3, 4, 5}));
            Assert.Equal(20, Yatzy.LargeStraight(new[] {2, 3, 4, 5, 6}));
            Assert.Equal(0, Yatzy.LargeStraight(new[] {1, 2, 2, 4, 5}));
        }

        [Fact]
        public void one_pair()
        {
            Assert.Equal(6, Yatzy.ScorePair(new[] {3, 4, 3, 5, 6}));
            Assert.Equal(10, Yatzy.ScorePair(new[] {5, 3, 3, 3, 5}));
            Assert.Equal(12, Yatzy.ScorePair(new[] {5, 3, 6, 6, 5}));
        }

        [Fact]
        public void sixes_Fact()
        {
            Assert.Equal(0,Yatzy.OfAKind(new[] {4, 4, 4, 5, 5},6));
            Assert.Equal(6, Yatzy.OfAKind(new[] {4, 4, 6, 5, 5},6));
            Assert.Equal(18, Yatzy.OfAKind(new[] {6, 5, 6, 6, 5},6));
        }

        [Fact]
        public void smallStraight()
        {
            Assert.Equal(15, Yatzy.SmallStraight(new[] {1, 2, 3, 4, 5}));
            Assert.Equal(15, Yatzy.SmallStraight(new[] {2, 3, 4, 5, 1}));
            Assert.Equal(0, Yatzy.SmallStraight(new[] {1, 2, 2, 4, 5}));
        }

        [Fact]
        public void three_of_a_kind()
        {
            Assert.Equal(9, Yatzy.ThreeOfAKind(new[] {3, 3, 3, 4, 5}));
            Assert.Equal(15, Yatzy.ThreeOfAKind(new[] {5, 3, 5, 4, 5}));
            Assert.Equal(9, Yatzy.ThreeOfAKind(new[] {3, 3, 3, 3, 5}));
        }

        [Fact]
        public void two_Pair()
        {
            Assert.Equal(16, Yatzy.TwoPair(new[] {3, 3, 5, 4, 5}));
            Assert.Equal(16, Yatzy.TwoPair(new[] {3, 3, 5, 5, 5}));
        }

        [Fact]
        public void Yatzy_scores_50()
        {
            var expected = 50;
            var actual = Yatzy.yatzy(new[] {4, 4, 4, 4, 4});
            Assert.Equal(expected, actual);
            Assert.Equal(50, Yatzy.yatzy(new[] {6, 6, 6, 6, 6}));
            Assert.Equal(0, Yatzy.yatzy(new[] {6, 6, 6, 6, 3}));
        }
    }
}