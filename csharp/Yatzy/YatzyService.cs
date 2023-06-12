using Yatzy;
public class YatzyService: IYatzyService {
	public int Chance(int[] faces)	{return Yatzy.Yatzy.Chance(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int Yatzee(int[] faces){return Yatzy.Yatzy.yatzy(faces);}
	public int Ones(int[] faces)	{return Yatzy.Yatzy.Ones(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int Twos(int[] faces){return Yatzy.Yatzy.Twos(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int Threes(int[] faces){return Yatzy.Yatzy.Threes(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int Fours(int[] faces){Yatzy.Yatzy engine = new (faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);
	return engine.Fours();}
	public int Fives(int[] faces){Yatzy.Yatzy engine = new (faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);
	return engine.Fives();}
	public int Sixes(int[] faces){Yatzy.Yatzy engine = new (faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);
	return engine.sixes();}
	public int Pair(int[] faces){return Yatzy.Yatzy.ScorePair(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int TwoPair(int[] faces){return Yatzy.Yatzy.TwoPair(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int FourOfAKind(int[] faces){return Yatzy.Yatzy.FourOfAKind(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int ThreeOfAKind(int[] faces){return Yatzy.Yatzy.ThreeOfAKind(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int SmallStraight(int[] faces){return Yatzy.Yatzy.SmallStraight(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int LargeStraight(int[] faces){return Yatzy.Yatzy.LargeStraight(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
	public int FullHouse(int[] faces){return Yatzy.Yatzy.FullHouse(faces[0],	faces[1],	faces[2],	faces[3],	faces[4]);}
}
