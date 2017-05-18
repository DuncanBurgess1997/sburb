using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string characterName;
    public PlayerClass characterClass;
    public PlayerAspect characterAspect;
    public StrifeKind strifeSpecibus;
    private bool allocated;
    public Item weapon;
    public Land characterLand;
    public bool characterMale;

    public List<StrifeKind> strifePortfolio = new List<StrifeKind>();
    public List<Item> sylladex = new List<Item>();

    GameObject manager = GameObject.Find("DatabaseManager");
    DictionaryDatabase data;

    private int echeLevel;
    public int[] baseAtts = new int[6]; // Con, Str, Dex, Int, Wis, Cha
    private int[] attBonuses = new int[6];
    private int[] atts = new int[6];
    private int hp, maxHp, aspect, maxAspect, init, luck;

    
    public Character(string name, PlayerClass playerClass, PlayerAspect playerAspect, int[] playerAtts, bool male)
    {
        data =  manager.GetComponent<DictionaryDatabase>();
        characterName = name;
        characterClass = playerClass;
        characterAspect = playerAspect;
        characterMale = male;

        for (int i = 0; i < 6; i++)
        {
            baseAtts[i] = playerAtts[i];
        }

        echeLevel = 1;
    }

    public void allocateSpecibus(Item weapon)
    {
        if (!allocated)
        {
            strifeSpecibus = weapon.strifeKind;
            strifePortfolio.Add(weapon.strifeKind);
            allocated = true;
        }
        else
        {
            Debug.Log("Strife specibus already allocated.");
        }
    }

    public void addPortfolio(StrifeKind kind)
    {
        strifePortfolio.Add(kind);
    }

    public void changeSpecibus(StrifeKind kind)
    {
        if (strifePortfolio.Exists(x => x == kind))
        {
            strifeSpecibus = kind;
        }
        else
        {
            Debug.Log("This strife specibus is not in your portfolio.");
        }
    }

    public void captchalogue(Item item)
    {
        sylladex.Add(item);
        Debug.Log(item.itemName + " captchalogued!");
    }

    public void equipWeapon(Item newWeapon, bool fromSylladex)
    {
        if (newWeapon.itemType != 1 && newWeapon.itemType != 2 && newWeapon.itemType != 3)
        {
            Debug.Log("This item is not a weapon.");
            return;
        }
        else if (newWeapon.strifeKind != strifeSpecibus)
        {
            Debug.Log("This weapon does not match your strife specibus.");
            return;
        }
        else
        {
            if (weapon != null)
            {
                sylladex.Add(weapon);
            }
            weapon = newWeapon;
            Debug.Log(characterName + " has now equipped : " + weapon.itemName);
            deriveStats();

            if (fromSylladex)
            {
                sylladex.Remove(data.items[newWeapon.itemName]);
            }
        }
    }

    public void debugCharacter()
    {
        deriveStats();
        Debug.Log("Character name : " + characterName + "\nCharacter class : "+ characterClass.className + " of " + characterAspect.aspectName +
            "\nConstitution : " + atts[0] + "\nStrength : " + atts[1] + 
            "\nDexterity : " + atts[2] + "\nIntelligence: " + atts[3] + 
            "\nWisdom : " + atts[4] + "\nCharisma : " + atts[5] + 
            "\nHP : " + hp + "/" + maxHp + "\nAspect : " + aspect + "/" + maxAspect +
            "\nInitiative : " + init + "\nLuck : " + luck);
        if (characterMale)
        {
            Debug.Log(characterName + " is Male.");
        }
        else
        {
            Debug.Log(characterName + " is Female.");
        }
        characterLand.debugLand();
    }

    public void debugSylladex()
    {
        if (sylladex.Count == 0)
        {
            Debug.Log("Sylladex is empty.");
            return;
        }
        foreach(Item item in sylladex)
        {
            Debug.Log("Item : " + item.itemName);
        }
    }

    private void deriveStats()
    {
        maxHp = echeLevel * 2 + baseAtts[0];
        hp = maxHp;
        maxAspect = echeLevel + ((baseAtts[characterAspect.aspectAtt] + baseAtts[characterClass.classAtt]) / 2);
        aspect = maxAspect;
        init = baseAtts[2] / 4 + echeLevel;
        luck = echeLevel + (baseAtts[4] / 5) + (baseAtts[5] / 5);
        
        // Find item bonuses.
        if (weapon != null)
        {
            for (int i = 0; i < 6; i++)
            {
                attBonuses[i] = 0;
                attBonuses[i] += weapon.attBonuses[i];
            }

            for (int i = 0; i < 6; i++)
            {
                atts[i] = baseAtts[i] + attBonuses[i];
            }
        }
        else
        {
            for(int i = 0; i < 6; i++)
            {
                atts[i] = baseAtts[i];
            }
        }
    }

    public void generateLand()
    {
        string[] tempArr = new string[6];
        LandPrefix tempPrefix = new LandPrefix(tempArr, 0, false, false);
        List<LandPrefix> preList = new List<LandPrefix>();
        LandSuffix tempSuffix = new LandSuffix(tempArr, 0, false, false);
        List<LandSuffix> sufList = new List<LandSuffix>();
        bool dungeons = false;
        
        foreach (KeyValuePair<string, LandPrefix> entry in data.landPrefixes)
        {
            if (entry.Value.aspectBased)
            {
                if (entry.Value.compatibleAspect == characterAspect)
                {
                    if (characterAspect != data.aspects["Space"] || entry.Value.dictatesDungeons)
                    {
                        // SUCCESS
                        preList.Add(entry.Value);
                    }
                }
            }
            else if (entry.Value.compatibleClass == characterClass)
            {
                if (characterAspect != data.aspects["Space"] || entry.Value.dictatesDungeons)
                {
                    // SUCCESS
                    preList.Add(entry.Value);
                }
            }
        }

        int rnd = Random.Range(0, preList.Count);
        tempPrefix = preList[rnd];
        if (tempPrefix.dictatesDungeons)
        {
            dungeons = true;
        }

        if (characterAspect != data.aspects["Space"])
        {
            foreach (KeyValuePair<string, LandSuffix> entry in data.landSuffixes)
            {
                if (entry.Value.aspectBased)
                {
                    if (entry.Value.compatibleAspect == characterAspect)
                    {
                        if (entry.Value.dictatesDungeons && dungeons != true)
                        {
                            // SUCCESS
                            sufList.Add(entry.Value);
                        }
                        else if (entry.Value.dictatesDungeons != true && dungeons)
                        {
                            // SUCCESS
                            sufList.Add(entry.Value);
                        }
                    }
                }
                else if (entry.Value.compatibleClass == characterClass)
                {
                    if (entry.Value.dictatesDungeons && dungeons != true)
                    {
                        // SUCCESS
                        sufList.Add(entry.Value);
                    }
                    else if (entry.Value.dictatesDungeons != true && dungeons)
                    {
                        // SUCCESS
                        sufList.Add(entry.Value);
                    }
                }
            }
        }
        else
        {
            sufList.Add(data.landSuffixes["Frogs"]);
        }

        rnd = Random.Range(0, sufList.Count);
        tempSuffix = sufList[rnd];
        if (tempSuffix.dictatesDungeons)
        {
            dungeons = true;
        }

        if (dungeons == true)
        {
            characterLand = new Land(tempPrefix, tempSuffix);
        }
        else
        {
            Debug.Log("Dungeons not enabled.");
        }
    }
}
