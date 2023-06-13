using  Yatzy;
namespace Yatzy.Engine;

public class  YatzyEngine:IYatzyEngine
{

public string[] Roll()=> Roll(6);
private readonly IYatzyService  _service;
static Random rnd = new Random();
private Dictionary<string,Func <int[],int>>  Evaluators =  new();
public YatzyEngine( IYatzyService  service)
{    
  _service = service;
    Evaluators.Add( "Chance",       _service.Chance);
	Evaluators.Add( "Yatzee",       _service.Yatzee);
	Evaluators.Add( "Ones",         _service.Ones);
	Evaluators.Add( "Twos",         _service.Twos);
	Evaluators.Add( "Threes",       _service.Threes);
	Evaluators.Add( "Fours",        _service.Fours);
	Evaluators.Add( "Fives",        _service.Fives);
	Evaluators.Add( "Sixes",        _service.Sixes);
	Evaluators.Add( "Pair",         _service.Pair);
	Evaluators.Add( "TwoPair",      _service.TwoPair);
	Evaluators.Add( "FourOfAKind", _service.FourOfAKind);
	Evaluators.Add( "ThreeOfAKind", _service.ThreeOfAKind);
	Evaluators.Add( "SmallStraight",_service.SmallStraight);
	Evaluators.Add( "LargeStraight",_service.LargeStraight);
	Evaluators.Add( "FullHouse",    _service.FullHouse);

    }
   public Func<int[],int> get_evaluator(string typeName)
   {
    if ( Evaluators.HasKeys(typeName))
    {
          return Evaluators[typeName];
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
