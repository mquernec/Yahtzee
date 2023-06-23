using Yatzy;
using Yatzy.Engine;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
IYatzyService _service = new YatzyService();
YatzyEngineInterface _engine = new YatzyEngine(_service);

app.MapPost("/evaluate",   (YatzyQuery query) => { 
    if(_service.Validate(query.roll.Select(r=> Int32.Parse(r)).ToArray(),5,6))
    {
     return   Results.Ok(new YatzyReponse((int)_engine.get_evaluator(query.type)(query.roll.Select(r=> Int32.Parse(r)).ToArray())));}
    else{
      return  Results.UnprocessableEntity();
    }
    });
app.MapGet("/roll",   () => _engine.Roll());
app.MapGet("/play",   () => _engine.PlayARound());
app.MapGet("/try/{mode}",   (string mode) => _engine.TryAMode(mode));
app.MapGet("/roll/{nbDice}",   (int nbDice) => _engine.Roll(nbDice));
app.MapGet("/roll/{nbDice}/{nbSide}",   (int nbDice, int nbSide) => _engine.Roll(nbDice,nbSide));
app.MapPost("/best",   (string[] rolls) =>  _engine.BestForaRoll(rolls));
app.Run();



