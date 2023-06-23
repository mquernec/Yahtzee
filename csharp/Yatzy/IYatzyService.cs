public interface IYatzyService {
	int Chance(int[] faces);
	int Yatzee(int[] faces);
	int Ones(int[] faces);
	int Twos(int[] faces);
	int Threes(int[] faces);
	int Fours(int[] faces);
	int Fives(int[] faces);
	int Sixes(int[] faces);
	int Pair(int[] faces);
	int TwoPair(int[] faces);
	int FourOfAKind(int[] faces);
	int ThreeOfAKind(int[] faces);
	int SmallStraight(int[] faces);
	int LargeStraight(int[] faces);
	int FullHouse(int[] faces);
	bool Validate(int[] faces, int poolSize, int maxValue);
}
