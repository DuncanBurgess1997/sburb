public class LandPrefix
{
    public string[] landNames = new string[3];
    public int landID;
    public bool aspectBased;
    public bool dictatesDungeons;
    public PlayerAspect compatibleAspect;
    public PlayerClass compatibleClass;

    public LandPrefix(string[] names, int ID, bool based, bool dungeons)
    {
        landNames[0] = names[0];
        landNames[1] = names[1];
        landNames[2] = names[2];
        landID = ID;

        aspectBased = based;
        dictatesDungeons = dungeons;
    }
}
