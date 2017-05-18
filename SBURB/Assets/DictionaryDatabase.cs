using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryDatabase : MonoBehaviour {

    public Dictionary<string, Grist> grists = new Dictionary<string, Grist>();
    public Dictionary<string, PlayerAspect> aspects = new Dictionary<string, PlayerAspect>();
    public Dictionary<string, PlayerClass> classes = new Dictionary<string, PlayerClass>();
    public Dictionary<string, StrifeKind> strifeKinds = new Dictionary<string, StrifeKind>();
    public Dictionary<string, Trait> traits = new Dictionary<string, Trait>();
    public Dictionary<string, Item> items = new Dictionary<string, Item>();

    public Dictionary<string, LandPrefix> landPrefixes = new Dictionary<string, LandPrefix>();
    public Dictionary<string, LandSuffix> landSuffixes = new Dictionary<string, LandSuffix>();

    public int numberOfGristTypes = 0;
    public int numberOfLandPrefixes = 0;
    public int numberOfLandSuffixes = 0;

    // Use this for initialization
    void Start ()
    {
        int i = 0;
        i = addGrist(i, "Build", 0);

        i = addGrist(i, "Shale", 1);

        i = addGrist(i, "Tar", 2);

        i = addGrist(i, "Jet", 3);

        i = addGrist(i, "Mercury", 4);

        i = addGrist(i, "Cobalt", 5);

        numberOfGristTypes = grists.Count;

        addAspect("Blood", 0); // Con, Str, Dex, Int, Wis, Cha
        addAspect("Life", 0);
        addAspect("Rage", 1);
        addAspect("Void", 1);
        addAspect("Time", 2);
        addAspect("Breath", 2);
        addAspect("Space", 3);
        addAspect("Mind", 3);
        addAspect("Doom", 4);
        addAspect("Light", 4);
        addAspect("Hope", 5);
        addAspect("Heart", 5);

        addClass("Heir", 0); // Con, Str, Dex, Int, Wis, Cha
        addClass("Maid", 0);
        addClass("Page", 1);
        addClass("Knight", 1);
        addClass("Thief", 2);
        addClass("Rogue", 2);
        addClass("Witch", 3);
        addClass("Mage", 3);
        addClass("Sylph", 4);
        addClass("Seer", 4);
        addClass("Prince", 5);
        addClass("Bard", 5);

        string[] tempArr = new string[3];
        i = 0;
        // CON
        // STR
        tempArr[0] = "Swamps";
        tempArr[1] = "Bogs";
        tempArr[2] = "Marsh";
        i = addLandPrefix(i, tempArr, classes["Page"], null, false, false);
        tempArr[0] = "Castles";
        tempArr[1] = "Forts";
        tempArr[2] = "Fortresses";
        i = addLandPrefix(i, tempArr, classes["Page"], null, false, true);
        tempArr[0] = "Heat";
        tempArr[1] = "Flame";
        tempArr[2] = "Lava";
        i = addLandPrefix(i, tempArr, classes["Knight"], null, false, false);
        // DEX
        tempArr[0] = "Wind";
        tempArr[1] = "Breeze";
        tempArr[2] = "Gust";
        i = addLandPrefix(i, tempArr, null, aspects["Breath"], true, false);
        // INT
        tempArr[0] = "Frost";
        tempArr[1] = "Ice";
        tempArr[2] = "Rime";
        i = addLandPrefix(i, tempArr, classes["Witch"], null, false, false);
        // WIS
        tempArr[0] = "Light";
        tempArr[1] = "Luminescence";
        tempArr[2] = "Shine";
        i = addLandPrefix(i, tempArr, null, aspects["Light"], true, false);
        // CHA

        i = 0;
        // CON
        tempArr[0] = "Haze";
        tempArr[1] = "Fog";
        tempArr[2] = "Mist";
        i = addLandSuffix(i, tempArr, null, aspects["Blood"], true, false);
        tempArr[0] = "Tombs";
        tempArr[1] = "Crypts";
        tempArr[2] = "Mausoleums";
        i = addLandSuffix(i, tempArr, null, aspects["Life"], true, true);
        tempArr[0] = "Flowers";
        tempArr[1] = "Blossoms";
        tempArr[2] = "Blooms";
        i = addLandSuffix(i, tempArr, null, aspects["Life"], true, false);
        // STR
        tempArr[0] = "Coliseums";
        tempArr[1] = "Stadiums";
        tempArr[2] = "Arenas";
        i = addLandSuffix(i, tempArr, null, aspects["Rage"], true, true);
        tempArr[0] = "Silence";
        tempArr[1] = "Lull";
        tempArr[2] = "Stillness";
        i = addLandSuffix(i, tempArr, null, aspects["Void"], true, false);
        // DEX
        tempArr[0] = "Clockwork";
        tempArr[1] = "Gears";
        tempArr[2] = "Cogs";
        i = addLandSuffix(i, tempArr, null, aspects["Time"], true, true);
        tempArr[0] = "Sand";
        tempArr[1] = "Sand";
        tempArr[2] = "Sand";
        i = addLandSuffix(i, tempArr, null, aspects["Time"], true, false);
        tempArr[0] = "Shade";
        tempArr[1] = "Dark";
        tempArr[2] = "Shadow";
        i = addLandSuffix(i, tempArr, null, aspects["Breath"], true, false);
        // INT
        tempArr[0] = "Frogs";
        tempArr[1] = "Frogs";
        tempArr[2] = "Frogs";
        i = addLandSuffix(i, tempArr, null, aspects["Space"], true, false);
        tempArr[0] = "Courts";
        tempArr[1] = "Tribunals";
        tempArr[2] = "Tribunals";
        i = addLandSuffix(i, tempArr, null, aspects["Mind"], true, true);
        // WIS
        tempArr[0] = "Dust";
        tempArr[1] = "Ashes";
        tempArr[2] = "Embers";
        i = addLandSuffix(i, tempArr, null, aspects["Doom"], true, false);
        tempArr[0] = "Rain";
        tempArr[1] = "Drizzle";
        tempArr[2] = "Precipitation";
        i = addLandSuffix(i, tempArr, null, aspects["Light"], true, false);
        // CHA
        tempArr[0] = "Angels";
        tempArr[1] = "Angels";
        tempArr[2] = "Angels";
        i = addLandSuffix(i, tempArr, null, aspects["Hope"], true, true);
        tempArr[0] = "Reflection";
        tempArr[1] = "Mirrors";
        tempArr[2] = "Mirrors";
        i = addLandSuffix(i, tempArr, null, aspects["Heart"], true, true);
        
        numberOfLandPrefixes = landPrefixes.Count;
        numberOfLandSuffixes = landSuffixes.Count;

        addStrifeKind("hammerKind");
        addStrifeKind("bowKind");
        addStrifeKind("bladeKind");

        i = 0;
        i = addTrait(i, "Time Element");
        i = addTrait(i, "Space Element");
        i = addTrait(i, "Reliable");
        i = addTrait(i, "Tool");
        i = addTrait(i, "Piercing");
        i = addTrait(i, "Agile");
        i = addTrait(i, "Ranged");

        loadItemFile("Assets/items.txt"); // Call to load items.
    }

    private int addGrist(int i, string gristName, int gristTier)
    {
        i++;

        Grist tempGrist = new Grist(gristName, gristTier, i);
        grists.Add(gristName, tempGrist);

        return i;
    }

    private void addAspect(string aspectName, int aAtt)
    {
        PlayerAspect tempAspect = new PlayerAspect("nullName", 0);

        tempAspect.aspectName = aspectName;
        tempAspect.aspectAtt = aAtt;

        aspects.Add(aspectName, tempAspect);
    }

    private void addClass(string className, int cAtt)
    {
        PlayerClass tempClass = new PlayerClass("nullName", 0);

        tempClass.className = className;
        tempClass.classAtt = cAtt;

        classes.Add(className, tempClass);
    }

    public void addStrifeKind(string strifeKindName)
    {
        StrifeKind tempStrifeKind = new StrifeKind("nullName");

        tempStrifeKind.strifeKindName = strifeKindName;

        strifeKinds.Add(strifeKindName, tempStrifeKind);
    }

    private int addTrait(int i, string traitName)
    {
        i++;
        Trait tempTrait = new Trait("nullName", 0);

        tempTrait.traitName = traitName;
        tempTrait.ID = i;

        traits.Add(traitName, tempTrait);

        return i;
    }

    private void loadItemFile(string fileName)
    {
        string[] text = System.IO.File.ReadAllLines(fileName);

        for (int i = 0; i < text.Length;)
        {
            int[] tempArr = new int[6];
            Item tempItem = new Item("nullName", null, 0, null, null, null, tempArr);
            tempItem.itemName = text[i++];
            tempItem.strifeKind = strifeKinds[text[i++]];
            tempItem.itemType = int.Parse(text[i++]);
            tempItem.attack = int.Parse(text[i++]);
            tempItem.trait1 = traits[text[i++]];
            tempItem.trait2 = traits[text[i++]];
            if (tempItem.itemType == 2 || tempItem.itemType == 3)
            {
                tempItem.trait3 = traits[text[i++]];
                tempItem.component1Name = text[i++];
                tempItem.component2Name = text[i++];
                if (text[i++] == "True")
                {
                    tempItem.andOperator = true;
                }
                else
                {
                    tempItem.andOperator = false;
                }
            }
            tempItem.numberOfGrists = int.Parse(text[i++]);
            for (int j = 0; j < tempItem.numberOfGrists; j++)
            {
                tempItem.grist[j] = grists[text[i++]];
                tempItem.gristCost[j] = int.Parse(text[i++]);
            }
            for (int j = 0; j < 6; j++)
            {
                tempItem.attBonuses[j] = int.Parse(text[i++]);
            }
            items.Add(tempItem.itemName, tempItem);
            i++;
        }
    }

    public void addItem(string itemName, Item tempItem)
    {
        items.Add(itemName, tempItem);
    }

    private int addLandPrefix(int i, string[] landName, PlayerClass compatibleClass, PlayerAspect compatibleAspect, bool based, bool dungeons)
    {
        i++;

        LandPrefix tempLand = new LandPrefix(landName, i, based, dungeons);
        tempLand.compatibleClass = compatibleClass;
        tempLand.compatibleAspect = compatibleAspect;

        landPrefixes.Add(landName[0], tempLand);

        return i;
    }

    private int addLandSuffix(int i, string[] landName, PlayerClass compatibleClass, PlayerAspect compatibleAspect, bool based, bool dungeons)
    {
        i++;

        LandSuffix tempLand = new LandSuffix(landName, i, based, dungeons);
        tempLand.compatibleAspect = compatibleAspect;
        tempLand.compatibleClass = compatibleClass;

        landSuffixes.Add(landName[0], tempLand);

        return i;
    }

    public void alchemize(string newName, string item1Name, string item2Name, bool andOperator, string fileName)
    {
        int temp = 0;
        Item item1 = items[item1Name];
        Item item2 = items[item2Name];

        temp = string.Compare(item1Name, item2Name);

        if (temp < 0)
        {
            item1 = items[item1Name];
            item2 = items[item2Name];
        }
        else if (temp > 0)
        {
            item1 = items[item2Name];
            item2 = items[item1Name];
        }
        else if (temp == 0)
        {
            Debug.Log("Both components have same name? Shouldn't happen.");
        }

        foreach (KeyValuePair<string, Item> entry in items)
        {
            if (entry.Value.component1Name == item1.itemName && entry.Value.component2Name == item2.itemName && entry.Value.andOperator == andOperator)
            {
                Debug.Log("An item made this way already exists.");
                return;
            }
            else if (entry.Value.itemName == newName)
            {
                Debug.Log("An item with this name already exists.");
                return;
            }
        }
        
        int[] tempArr = new int[6];
        Item newItem = new Item("nullName", null, 0, null, null, null, tempArr);
        
        if (item1.itemType != item2.itemType)
        {
            Debug.Log("These items cannot be alchemized together.");
        }
        else
        {
            newItem.itemName = newName;
            newItem.itemType = item1.itemType;
            newItem.component1Name = item1.itemName;
            newItem.component2Name = item2.itemName;
            newItem.andOperator = andOperator;
            if (item1.itemType == 1)
            {
                newItem.itemType = 2;
                if (andOperator)
                {
                    newItem.strifeKind = item1.strifeKind;
                    newItem.attack = item1.attack + (item2.attack / 2);
                    for (int i = 0; i < 6; i++)
                    {
                        newItem.attBonuses[i] = item1.attBonuses[i] + (item2.attBonuses[i] / 2);
                    }
                    newItem.trait1 = item1.trait1;
                    newItem.trait2 = item2.trait1;
                    newItem.trait3 = item1.trait2;
                }
                else // Or operator
                {
                    newItem.strifeKind = item2.strifeKind;
                    newItem.attack = item2.attack + (item1.attack / 2);
                    for (int i = 0; i < 6; i++)
                    {
                        newItem.attBonuses[i] = item2.attBonuses[i] + (item1.attBonuses[i] / 2);
                    }
                    newItem.trait1 = item2.trait1;
                    newItem.trait2 = item1.trait1;
                    newItem.trait3 = item2.trait2;
                }
            }

            newItem.grist[0] = grists["Build"];
            newItem.gristCost[0] = (item1.gristCost[0] + item2.gristCost[0]) * 2;
            newItem.numberOfGrists = newItem.itemType;
            for (int i = 1; i < newItem.numberOfGrists; i++)
            {
                // Randomly make a grist cost appropriate to tier, components, traits and land...
                do
                {
                    int gristID = Random.Range(1, numberOfGristTypes + 1);
                    foreach (KeyValuePair<string, Grist> entry in grists)
                    {
                        if (entry.Value.gristID == gristID)
                        {
                            newItem.grist[i] = entry.Value;
                        }
                    }
                } while (newItem.grist[i] == null);
                newItem.gristCost[i] = newItem.attack * 2;
            }
        }

        items.Add(newName, newItem);

        string append = System.Environment.NewLine +
                newItem.itemName + System.Environment.NewLine +
                newItem.strifeKind.strifeKindName + System.Environment.NewLine +
                newItem.itemType + System.Environment.NewLine +
                newItem.attack + System.Environment.NewLine +
                newItem.trait1.traitName + System.Environment.NewLine +
                newItem.trait2.traitName + System.Environment.NewLine +
                newItem.trait3.traitName + System.Environment.NewLine +
                newItem.component1Name + System.Environment.NewLine +
                newItem.component2Name + System.Environment.NewLine +
                newItem.andOperator + System.Environment.NewLine +
                newItem.numberOfGrists + System.Environment.NewLine +
                newItem.grist[0].gristName + System.Environment.NewLine +
                newItem.gristCost[0] + System.Environment.NewLine;

        System.IO.File.AppendAllText(fileName, append);

        for (int i = 1; i < newItem.numberOfGrists; i++)
        {
            append = newItem.grist[i].gristName + System.Environment.NewLine +
                        newItem.gristCost[i] + System.Environment.NewLine;

            System.IO.File.AppendAllText(fileName, append);
        }

        append = newItem.attBonuses[0] + System.Environment.NewLine +
                    newItem.attBonuses[1] + System.Environment.NewLine +
                    newItem.attBonuses[2] + System.Environment.NewLine +
                    newItem.attBonuses[3] + System.Environment.NewLine +
                    newItem.attBonuses[4] + System.Environment.NewLine +
                    newItem.attBonuses[5] + System.Environment.NewLine +
                    "==============================";

        System.IO.File.AppendAllText(fileName, append);
    }

    public void debugAspect(string className)
    {
        PlayerAspect tempAspect = new PlayerAspect("nullName", 0);

        if (aspects.TryGetValue(className, out tempAspect))
        {
            Debug.Log("Aspect : " + tempAspect.aspectName);
        }
        else
        {
            Debug.Log("Aspect does not exist.");
        }
    }

    public void debugClass(string className)
    {
        PlayerClass tempClass = new PlayerClass("nullName", 0);

        if (classes.TryGetValue(className, out tempClass))
        {
            Debug.Log("Class : " + tempClass.className);
        }
        else
        {
            Debug.Log("Class does not exist.");
        }
    }

    public void debugStrifeKind(string strifeKindName)
    {
        StrifeKind tempStrifeKind = new StrifeKind("nullName");

        if (strifeKinds.TryGetValue(strifeKindName, out tempStrifeKind))
        {
            Debug.Log("strifeKind Name: " + tempStrifeKind.strifeKindName);
        }
        else
        {
            Debug.Log("strifeKind does not exist.");
        }
    }

    public void debugTrait(string traitName)
    {
        Trait tempTrait = new Trait("nullName", 0);

        if (traits.TryGetValue(traitName, out tempTrait))
        {
            Debug.Log("Trait " + tempTrait.ID + ", Name: " + tempTrait.traitName);
        }
        else
        {
            Debug.Log("Trait does not exist.");
        }
    }

    private void debugItem(string itemName)
    {
        int[] tempArr = new int[6];
        Item tempItem = new Item("nullName", null, 0, null, null, null, tempArr);

        if (items.TryGetValue(itemName, out tempItem))
        {
            if (tempItem.itemType == 1)
            {
                Debug.Log("Item Name: " + tempItem.itemName + "\nItem Kind: " + tempItem.strifeKind.strifeKindName + "\nItem Attack: " + tempItem.attack + 
                          "Trait 1 : " + tempItem.trait1.traitName + "\nTrait 2 : " + tempItem.trait2.traitName);
            }
            else if (tempItem.itemType == 2)
            {
                Debug.Log("Item Name: " + tempItem.itemName + "\nItem Kind: " + tempItem.strifeKind.strifeKindName + "\nItem Attack: " + tempItem.attack +
                          "\nTrait 1 : " + tempItem.trait1.traitName + "\nTrait 2 : " + tempItem.trait2.traitName +
                          "\nTrait 3 : " + tempItem.trait3.traitName + "." +
                          "\nComponents : " + tempItem.component1Name + ", " + tempItem.component2Name);
                if (tempItem.andOperator)
                {
                    Debug.Log("Made via && operator");
                }
                else
                {
                    Debug.Log("Made via || operator");
                }
            }
            for (int i = 0; i < tempItem.numberOfGrists; i++)
            {
                Debug.Log(tempItem.grist[i].gristName + " Grist : " + tempItem.gristCost[i]);
            }
        }
        else
        {
            Debug.Log("Item does not exist.");
        }
    }
}
