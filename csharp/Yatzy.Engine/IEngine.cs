namespace Yatzy.Engine;
public record RoundOutput(int bestPoints, string[] rolls, string bestfigure , Scores[] scores);
public record Scores(int points,string figure);

public interface YatzyEngineInterface
{

    public string[] Roll();
    public int TryAMode(string mode);
    public string[] Roll(int nbDices);
    public string[] Roll(int nbDices, int nbFaces);
    public int BestForaRoll(string[] rolls);
    public RoundOutput PlayARound();
    public Func<int[],int> get_evaluator(string typeName);

}
