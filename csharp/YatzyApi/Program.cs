using Yatzy;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
IYatzyService _service = new YatzyService();

Dictionary<string, Func<int[],int>>  Evaluators =  new();
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
	Evaluators.Add( "ThreeOfAKind", _service.FourOfAKind);
	Evaluators.Add( "threeofakind", _service.ThreeOfAKind);
	Evaluators.Add( "smallstraight",_service.SmallStraight);
	Evaluators.Add( "largestraight",_service.LargeStraight);
	Evaluators.Add( "fullhouse",    _service.FullHouse);

app.MapPost("/evaluate", async  (YatzyQuery query) => 
{
    if(Evaluators.ContainsKey(query.type.ToLower()))
        return Results.Ok((int)Evaluators[query.type.ToLower()](query.roll.Select(r=> Int32.Parse(r)).ToArray()));

    return Results.BadRequest(query);
});

app.Run();
