using System.Linq;
using Yatzy;
public class YatzyService: IYatzyService {
	public bool Validate(int[] faces, int poolSize, int maxValue)
	{
		if(faces.Length != poolSize) return false;
		if(faces.Any(f=> f<0 || f>maxValue) ) return false;
		return true;
	}

	public int Chance(int[] faces)	{return Yatzy.Yatzy.Chance(faces);}
	public int Yatzee(int[] faces){return Yatzy.Yatzy.yatzy(faces);}
	public int Ones(int[] faces)	{return Yatzy.Yatzy.OfAKind(faces,1);}
	public int Twos(int[] faces){return Yatzy.Yatzy.OfAKind(faces,2);}
	public int Threes(int[] faces){return Yatzy.Yatzy.OfAKind(faces,3);}
	public int Fours(int[] faces){return Yatzy.Yatzy.OfAKind(faces,4);}
	public int Fives(int[] faces){return Yatzy.Yatzy.OfAKind(faces,5);}
	public int Sixes(int[] faces){return Yatzy.Yatzy.OfAKind(faces,6);}
	public int Pair(int[] faces){return Yatzy.Yatzy.ScorePair(faces);}
	public int TwoPair(int[] faces){return Yatzy.Yatzy.TwoPair(faces);}
	public int FourOfAKind(int[] faces){return Yatzy.Yatzy.FourOfAKind(faces);}
	public int ThreeOfAKind(int[] faces){return Yatzy.Yatzy.ThreeOfAKind(faces);}
	public int SmallStraight(int[] faces){return Yatzy.Yatzy.SmallStraight(faces);}
	public int LargeStraight(int[] faces){return Yatzy.Yatzy.LargeStraight(faces);}
	public int FullHouse(int[] faces){return Yatzy.Yatzy.FullHouse(faces);}
}
