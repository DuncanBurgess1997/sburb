using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMoveToPoint : MonoBehaviour
{
    public Vector3 finalPos;
    private Button theButton;
    GameObject mainCamera;
    public GameObject target;
    public bool nameCondition, attCondition;

	// Use this for initialization
	void Start ()
    {
        mainCamera = GameObject.Find("Main Camera");
        theButton = this.GetComponentInParent<Button>();
        Button btn = theButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick ()
    {
        GameObject manager = GameObject.Find("ChrCreationManager");
        ChrCreationManager managerScript = manager.GetComponent<ChrCreationManager>();

        GameObject nameTipText = GameObject.Find("NameTipText");
        GameObject attTipText = GameObject.Find("AttTipText");

        string tip = "";

        if (nameCondition)
        {
            if (managerScript.tempCharacter.characterName == "nullName")
            {
                tip = "Please enter a valid name!";
                nameTipText.GetComponent<Text>().text = tip;

                return;
            }
        }
        if (attCondition)
        {
            if (managerScript.SkillPoints != 0)
            {
                tip = "Please spend all attribute points!";
                attTipText.GetComponent<Text>().text = tip;

                return;
            }
        }

        Vector3 newFinal;

        if (target != null)
        {
            float tempX, tempY;
            tempX = finalPos.x;
            tempY = finalPos.y;

            newFinal = target.transform.position;
            newFinal.x += tempX;
            newFinal.y += tempY;
            newFinal.z = mainCamera.transform.position.z;
        }
        else
        {
            newFinal = finalPos;
        }
        SmoothMoveToPoint cameraMove = mainCamera.GetComponent<SmoothMoveToPoint>();

        cameraMove.MoveToPoint(newFinal);

        if (nameCondition)
        {
            tip = "";
            nameTipText.GetComponent<Text>().text = tip;
        }
        if (attCondition)
        {
            tip = "";
            attTipText.GetComponent<Text>().text = tip;
        }
    }
}
