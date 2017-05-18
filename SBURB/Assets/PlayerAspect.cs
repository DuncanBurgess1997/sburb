public class PlayerAspect
{
    public string aspectName;
    public int aspectAtt = 0; // Con, Str, Dex, Int, Wis, Cha

    public PlayerAspect(string name, int aAtt)
    {
        aspectName = name;
        aspectAtt = aAtt;
    }
}