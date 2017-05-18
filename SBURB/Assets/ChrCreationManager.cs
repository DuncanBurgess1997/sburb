using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChrCreationManager : MonoBehaviour
{
    int[] tempArr = new int[6];
    public Character tempCharacter;
    public int SkillPoints = 10;
    public GameObject[] attDisplays = new GameObject[6];
    public GameObject[] attDisplays2 = new GameObject[6];
    private string[] attNames = new string[6];
    public GameObject skillPoints;
    public GameObject portrait, portrait2, toolTip, aAtt, cAtt;
    public GameObject nameData;

    GameObject manager;
    DictionaryDatabase data;

    private bool active = false;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("DatabaseManager");
        data = manager.GetComponent<DictionaryDatabase>();

        attNames[0] = "Constitution : ";
        attNames[1] = "Strength      : ";
        attNames[2] = "Dexterity     : ";
        attNames[3] = "Intelligence  : ";
        attNames[4] = "Wisdom        : ";
        attNames[5] = "Charisma      : ";
    }

    public void newCharacter ()
    {
        active = true;
        for (int i = 0; i < 6; i++)
        {
            tempArr[i] = 10;
        }
        tempCharacter = new Character("nullName", data.classes["Knight"], data.aspects["Breath"], tempArr, false);
    }

	// Update is called once per frame
	void Update ()
    {
        if (active)
        {
            for (int i = 0; i < 6; i++)
            {
                attDisplays[i].GetComponentInChildren<Text>().text = attNames[i] + tempCharacter.baseAtts[i].ToString();
            }
            for (int i = 0; i < 6; i++)
            {
                attDisplays2[i].GetComponentInChildren<Text>().text = attNames[i] + tempCharacter.baseAtts[i].ToString();
            }

            skillPoints.GetComponentInChildren<Text>().text = SkillPoints.ToString();

            SpriteRenderer sprite = portrait2.GetComponent<SpriteRenderer>();
            loadPortrait(sprite);

            Text toolTipText = toolTip.GetComponent<Text>();
            toolTipText.text = ChangeToolTip();

            Text nameText = nameData.GetComponentInChildren<Text>();
            nameText.text = tempCharacter.characterName + ", " + tempCharacter.characterClass.className + " of " + tempCharacter.characterAspect.aspectName;
        }
	}

    public string ChangeToolTip()
    {
        string tip = "";

        if (tempCharacter.characterClass == data.classes["Knight"])
        {
            tip += "As a Knight, you will wield your aspect as a weapon.\n";
        }
        else if (tempCharacter.characterClass == data.classes["Thief"])
        {
            tip += "As a Thief, you will steal your aspect from foes and gain it for yourself.\n";
        }
        else if (tempCharacter.characterClass == data.classes["Seer"])
        {
            tip += "As a Seer, you will guide others with your understanding of your aspect.\n";
        }

        if (tempCharacter.characterAspect == data.aspects["Rage"])
        {
            tip += "Rage players have domain over anger, strength and sanity.\n";
        }
        else if (tempCharacter.characterAspect == data.aspects["Time"])
        {
            tip += "Time players have domain over time itself.\n";
        }
        else if (tempCharacter.characterAspect == data.aspects["Breath"])
        {
            tip += "Breath players have domain over freedom, direction and the wind.\n";
        }
        else if (tempCharacter.characterAspect == data.aspects["Doom"])
        {
            tip += "Doom players have domain over fate, destruction and death.\n";
        }

        Text aAttText = aAtt.GetComponentInChildren<Text>();
        if (tempCharacter.characterAspect.aspectAtt == 0)
        {
            aAttText.text = "CON";
        }
        else if (tempCharacter.characterAspect.aspectAtt == 1)
        {
            aAttText.text = "STR";
        }
        else if (tempCharacter.characterAspect.aspectAtt == 2)
        {
            aAttText.text = "DEX";
        }
        else if (tempCharacter.characterAspect.aspectAtt == 3)
        {
            aAttText.text = "INT";
        }
        else if (tempCharacter.characterAspect.aspectAtt == 4)
        {
            aAttText.text = "WIS";
        }
        else if (tempCharacter.characterAspect.aspectAtt == 5)
        {
            aAttText.text = "CHA";
        }

        Text cAttText = cAtt.GetComponentInChildren<Text>();
        if (tempCharacter.characterClass.classAtt == 0)
        {
            cAttText.text = "CON";
        }
        else if (tempCharacter.characterClass.classAtt == 1)
        {
            cAttText.text = "STR";
        }
        else if (tempCharacter.characterClass.classAtt == 2)
        {
            cAttText.text = "DEX";
        }
        else if (tempCharacter.characterClass.classAtt == 3)
        {
            cAttText.text = "INT";
        }
        else if (tempCharacter.characterClass.classAtt == 4)
        {
            cAttText.text = "WIS";
        }
        else if (tempCharacter.characterClass.classAtt == 5)
        {
            cAttText.text = "CHA";
        }

        return tip;
    }

    public void ChangeAtt(int att, bool positive)
    {
        if (positive)
        {
            if (tempCharacter.baseAtts[att] < 20 && SkillPoints != 0)
            {
                tempCharacter.baseAtts[att]++;
                SkillPoints--;
            }
        }
        else
        {
            if (tempCharacter.baseAtts[att] > 8)
            {
                tempCharacter.baseAtts[att]--;
                SkillPoints++;
            }
        }
    }

    public void ChangeClass()
    {
        GameObject buttonObject = GameObject.Find("ChrClassBtn");
        Button theButton = buttonObject.GetComponent<Button>();
        Text buttonText = theButton.GetComponentInChildren<Text>();
        SpriteRenderer portraitSprite = portrait.GetComponent<SpriteRenderer>();

        if (buttonText.text == "Knight")
        {
            buttonText.text = "Thief";
            tempCharacter.characterClass = data.classes["Thief"];
            loadPortrait(portraitSprite);
        }
        else if (buttonText.text == "Thief")
        {
            buttonText.text = "Seer";
            tempCharacter.characterClass = data.classes["Seer"];
            loadPortrait(portraitSprite);
        }
        else if (buttonText.text == "Seer")
        {
            buttonText.text = "Knight";
            tempCharacter.characterClass = data.classes["Knight"];
            loadPortrait(portraitSprite);
        }
    }

    public void ChangeAspect()
    {
        GameObject buttonObject = GameObject.Find("ChrAspectBtn");
        Button theButton = buttonObject.GetComponent<Button>();
        Text buttonText = theButton.GetComponentInChildren<Text>();
        SpriteRenderer portraitSprite = portrait.GetComponent<SpriteRenderer>();

        if (buttonText.text == "Breath")
        {
            buttonText.text = "Doom";
            tempCharacter.characterAspect = data.aspects["Doom"];
            loadPortrait(portraitSprite);
        }
        else if (buttonText.text == "Doom")
        {
            buttonText.text = "Rage";
            tempCharacter.characterAspect = data.aspects["Rage"];
            loadPortrait(portraitSprite);
        }
        else if (buttonText.text == "Rage")
        {
            buttonText.text = "Time";
            tempCharacter.characterAspect = data.aspects["Time"];
            loadPortrait(portraitSprite);
        }
        else if (buttonText.text == "Time")
        {
            buttonText.text = "Breath";
            tempCharacter.characterAspect = data.aspects["Breath"];
            loadPortrait(portraitSprite);
        }
    }

    public void ChangeName(Text name)
    {
        if (name.text.Length > 0)
        {
            tempCharacter.characterName = name.text;
        }
    }

    void loadPortrait(SpriteRenderer portraitSprite)
    {
        string load = "ClasspectPortraits/" + tempCharacter.characterClass.className + "Of" + tempCharacter.characterAspect.aspectName;
        portraitSprite.sprite = Resources.Load<Sprite>(load);
    }

    public void exit()
    {
        if (active)
        {
            GameObject buttonObjectC = GameObject.Find("ChrClassBtn");
            Button theButtonC = buttonObjectC.GetComponent<Button>();
            Text buttonTextC = theButtonC.GetComponentInChildren<Text>();

            SpriteRenderer portraitSprite = portrait.GetComponent<SpriteRenderer>();

            GameObject buttonObjectA = GameObject.Find("ChrAspectBtn");
            Button theButtonA = buttonObjectA.GetComponent<Button>();
            Text buttonTextA = theButtonA.GetComponentInChildren<Text>();

            buttonTextC.text = "Knight";
            buttonTextA.text = "Breath";

            tempCharacter.characterClass = data.classes["Knight"];
            tempCharacter.characterAspect = data.aspects["Breath"];

            SkillPoints = 10;

            GameObject nameField = GameObject.Find("NameInputField");
            nameField.GetComponent<InputField>().text = "";

            loadPortrait(portraitSprite);
            tempCharacter = null;

            active = false;
        }
    }

    public void test()
    {
        tempCharacter.allocateSpecibus(data.items["Ninja Sword"]);
        tempCharacter.captchalogue(data.items["Ninja Sword"]);
        tempCharacter.debugSylladex();
        tempCharacter.equipWeapon(tempCharacter.sylladex.Find(x => x.itemName.Contains("Ninja Sword")), true);

        tempCharacter.debugSylladex();
        tempCharacter.captchalogue(data.items["Bow"]);
        tempCharacter.captchalogue(data.items["Claw Hammer"]);
        tempCharacter.debugSylladex();

        tempCharacter.changeSpecibus(data.strifeKinds["hammerKind"]);
        tempCharacter.equipWeapon(tempCharacter.sylladex.Find(x => x.itemName.Contains("Claw Hammer")), true);
        tempCharacter.debugSylladex();

        tempCharacter.addPortfolio(data.strifeKinds["hammerKind"]);
        tempCharacter.changeSpecibus(data.strifeKinds["hammerKind"]);
        tempCharacter.equipWeapon(tempCharacter.sylladex.Find(x => x.itemName.Contains("Claw Hammer")), true);
        tempCharacter.debugSylladex();
    }
}
