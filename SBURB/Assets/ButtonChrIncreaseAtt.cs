using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChrIncreaseAtt : MonoBehaviour
{
    private Button theButton;
    public int att; // Con, Str, Dex, Int, Wis, Cha
    public bool positive;
    public GameObject managerObject;
    private ChrCreationManager manager;
    // Use this for initialization
    void Start ()
    {
        theButton = this.GetComponentInParent<Button>();
        Button btn = theButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        managerObject = GameObject.Find("ChrCreationManager");
        manager = managerObject.GetComponent<ChrCreationManager>();
    }

    void TaskOnClick()
    {
        manager.ChangeAtt(att, positive);
    }
}
