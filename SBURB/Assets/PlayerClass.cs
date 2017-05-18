public class PlayerClass
{
    public string className;
    public int classAtt = 0; // Con, Str, Dex, Int, Wis, Cha

    public PlayerClass(string name, int cAtt)
    {
        className = name;
        classAtt = cAtt;
    }
}
