using UnityEngine;
using UnityEngine.UI;

public class InputStringField : MonoBehaviour
{
    const int parameterNumber = 3;
    string[] parameters = new string[parameterNumber];
    int i = 0;

    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string arg0)
    {
        parameters[i] = arg0;
        i++;
        if (i >= parameterNumber)
        {
            i = 0;
            int j = int.Parse(parameters[2]);
            writeItem("Assets/items.txt", parameters[0], parameters[1], j);
        }
    }

    public void writeItem(string fileName, string itemName, string strifeKind, int attack)
    {
        string append = itemName + System.Environment.NewLine + strifeKind + System.Environment.NewLine + attack + System.Environment.NewLine;

        GameObject manager = GameObject.Find("DatabaseManager");
        DictionaryDatabase data = manager.GetComponent<DictionaryDatabase>();

        Item tempItem = new Item("nullName", null, 0, null, null, null, null);
        tempItem.itemName = itemName;
        tempItem.strifeKind = data.strifeKinds[strifeKind];
        tempItem.attack = attack;
        data.addItem(itemName, tempItem);

        System.IO.File.AppendAllText(fileName, append);
    }
}