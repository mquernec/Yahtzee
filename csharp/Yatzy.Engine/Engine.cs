using  Yatzy;
namespace Yatzy.Engine;

public class  YatzyEngine:YatzyEngineInterface
{

public string[] Roll()=> Roll(6);
private readonly IYatzyService  _service;
static Random rnd = new Random();
private Dictionary<string,Func <int[],int>>  Evaluators =  new();
public YatzyEngine( IYatzyService  service)
{    
  _service = service;
    Evaluators.Add( "chance",       _service.Chance);
	Evaluators.Add( "yatzee",       _service.Yatzee);
	Evaluators.Add( "ones",         _service.Ones);
	Evaluators.Add( "twos",         _service.Twos);
	Evaluators.Add( "threes",       _service.Threes);
	Evaluators.Add( "fours",        _service.Fours);
	Evaluators.Add( "fives",        _service.Fives);
	Evaluators.Add( "sixes",        _service.Sixes);
	Evaluators.Add( "pair",         _service.Pair);
	Evaluators.Add( "twopair",      _service.TwoPair);
	Evaluators.Add( "fourofakind", _service.FourOfAKind);
	Evaluators.Add( "threeofakind", _service.ThreeOfAKind);
	Evaluators.Add( "smallstraight",_service.SmallStraight);
	Evaluators.Add( "largestraight",_service.LargeStraight);
	Evaluators.Add( "fullhouse",    _service.FullHouse);

    }
   public Func<int[],int> get_evaluator(string typeName)
   {
    if ( Evaluators.ContainsKey(typeName.ToLower()))
    {
          return Evaluators[typeName.ToLower()];
    }
   return null;
   }
public string[] Roll(int nbDices)=> Roll(6,6);

public string[] Roll(int nbDices, int nbFaces)
{
    List<string> res =   new  List<string>();
    for(int i =0;i<nbDices;i++)
    {
        res.Add((rnd.Next(1,nbFaces)).ToString());
    }

    return res.ToArray();
}

public int BestForaRoll(string[] rolls){
 int res= 0;
 foreach(var evaluator in Evaluators.Keys)
 {
       var score = (int)Evaluators[evaluator](rolls.Select(r=> Int32.Parse(r)).ToArray());
        res = Math.Max(res,score);
 }
   return res;
}

public int TryAMode(string mode)
{
    string[] rolls = Roll();
    if(Evaluators.ContainsKey(mode.ToLower()))
        return (int)Evaluators[mode.ToLower()](rolls.Select(r=> Int32.Parse(r)).ToArray());
    return 0;
}

public RoundOutput PlayARound()
{
    string[] rolls = Roll();
     int bestScore= 0;
     string bestMethodo=string.Empty;
    List<Scores> scores = new List<Scores>();
    foreach(var evaluator in Evaluators.Keys)
    {
        var score = (int)Evaluators[evaluator](rolls.Select(r=> Int32.Parse(r)).ToArray());
        scores.Add(new Scores(score,evaluator));
      if(score>= bestScore) 
      {
        bestScore = score;
        bestMethodo=evaluator;
      }     
    }
   return new RoundOutput(bestScore,rolls, bestMethodo,scores.ToArray());

}
}
