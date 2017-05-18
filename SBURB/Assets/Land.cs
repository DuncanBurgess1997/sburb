using UnityEngine;

public class Land
{
    public LandPrefix prefix;
    public LandSuffix suffix;
    public string landName;

    public Land(LandPrefix pre, LandSuffix suf)
    {
        int rnd1, rnd2;
        rnd1 = Random.Range(0, 3);
        rnd2 = Random.Range(0, 3);
        landName = "Land of " + pre.landNames[rnd1] + " and " + suf.landNames[rnd2];
    }

    public void debugLand()
    {
        Debug.Log(landName);
    }
}