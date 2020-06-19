using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Creating the class

public class SelectPrefab : MonoBehaviour, IPointerClickHandler
{
    // public and local variables and Gameobjects

    public GameObject ThisAcuPointPrefab;
    string AcuPointPreFabName;
    public static string Message;
   // public Texture CancelImg;
  //  public string Cancel;
   // public string Lung_Highlight;
    // While Starting, Check's the name of the GameObject

    void Start()
    {
        //AcuPointPreFabName = this.gameObject.name;
      //  (GameObject.Find("FocusButton").GetComponent(Cancel) as MonoBehaviour).enabled = false;
        GameObject.Find("Acuimg").GetComponent<RawImage>().enabled = false;
    }

    // Receives the Message from Other class

    public void MessagefromCreatePrefab(string ReceivedMessage)
    {
        Message = ReceivedMessage;
        Debug.Log(Message);
    }

    // OnPointerClick work's like a button for Panel component

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        var thisname = name;
        Debug.Log("the name is "+ thisname);
        thisname = thisname.Split(' ')[0];
        Selected(thisname, Message);
    }

    // Accessing the received message and shared with gameobject to Highlight

    void Selected(string thisname, string AcuPoints)
    {
        Debug.Log("Acupoints "+AcuPoints);
        String[] separator = { "," };
        List<string> strList = new List<string>(AcuPoints.Split(separator, StringSplitOptions.RemoveEmptyEntries));
        for (int i = 0; i < strList.Count; i++)
        {
            if (strList[i].Equals(thisname))
            {
                if (gameObject.name.Equals(thisname + " List"))
                {
                    HighlightRed(thisname, AcuPoints);
                }
            }
        }
    }

    // Highlight the gameobject

    void HighlightRed(string thisname, string AcuPoints)
    {

        ThisAcuPointPrefab.GetComponent<Image>().color = new Color32(166, 255, 159, 255);
        //if (GameObject.FindWithTag("AcuPoints"))
        //{
        //var ReceivedMessage = ":LooKAtTheObject";
        //GameObject.Find(thisname).SendMessage("SendMsgToAcuPoint", ReceivedMessage);
       // Camera.main.SendMessage("msgController", thisname + "FocusLhs");
       // Camera.main.SendMessage("CamMsg", "LooKAtTheObject");
        //}
        //GameObject.Find(thisname + "_ObjectLhs").GetComponent<Renderer>().enabled = true;
       // GameObject.Find(thisname + "_TextLhs").GetComponent<Renderer>().enabled = true;
       // GameObject.Find(thisname + "_ObjectRhs").GetComponent<Renderer>().enabled = true;
      //  GameObject.Find(thisname + "_TextRhs").GetComponent<Renderer>().enabled = true;
        Focus(thisname, AcuPoints);
        String[] separator = { "," };
        List<string> strListB = new List<string>(AcuPoints.Split(separator, StringSplitOptions.RemoveEmptyEntries));
        strListB.Remove(thisname);
        for (int i = 0; i < strListB.Count; i++)
        {
            GameObject.Find(strListB[i] + " List").GetComponent<Image>().color = new Color(255, 255, 225);
           // GameObject.Find(strListB[i] + "_ObjectLhs").GetComponent<Renderer>().enabled = false;
            //GameObject.Find(strListB[i] + "_ObjectRhs").GetComponent<Renderer>().enabled = false;
          //  GameObject.Find(strListB[i] + "_TextLhs").GetComponent<Renderer>().enabled = false;
           // GameObject.Find(strListB[i] + "_TextRhs").GetComponent<Renderer>().enabled = false;
        }
    }

    void Focus(string thisname, string AcuPoints)
    {
     //   GameObject.Find("FocusButton").GetComponentInChildren<RawImage>().texture = CancelImg;
        GameObject.Find("Acuimg").GetComponent<RawImage>().enabled = true;
        GameObject.Find("Acuimg").GetComponent<RawImage>().texture = Resources.Load("Imagess/" + thisname) as Texture2D;
       // GameObject.Find("FocusButton").GetComponentInChildren<Text>().text = "Cancel the Focus";
       // GameObject.Find("FocusText").GetComponent<RectTransform>().sizeDelta = new Vector2(131.5f, 22.12f);
      //  GameObject.Find("FocusText").GetComponent<RectTransform>().localPosition = new Vector3(-45.91f, -1.525879e-05f, 0);
       // (GameObject.Find("FocusButton").GetComponent(Cancel) as MonoBehaviour).enabled = true;
       // GameObject.Find("FocusButton").SendMessage("ReceivedMessagefromSelectPrefab", thisname);
      //  GameObject.Find("FocusButton").SendMessage("ReceivedAcuPoint", AcuPoints);

       // GameObject.Find("LHS").GetComponent<RawImage>().enabled = true;
       // GameObject.Find("LHS").GetComponent<RawImage>().GetComponent<RawImage>().color = new Color32(0x96, 0xF2, 0xCA, 0xFF);
       // GameObject.Find("LHS").SendMessage("SelectedAcuPoint", thisname);
       // GameObject.Find("LHS").GetComponentInChildren<Text>().enabled = true;
       // GameObject.Find("RHS").GetComponent<RawImage>().enabled = true;
      //  GameObject.Find("RHS").GetComponent<RawImage>().GetComponent<RawImage>().color = new Color32(0xDA, 0xFF, 0xEF, 0xFF);
       // GameObject.Find("RHS").SendMessage("SelectedAcuPoint", thisname);
       // GameObject.Find("RHS").GetComponentInChildren<Text>().enabled = true;
    }
}