using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;
//using Newtonsoft.Json;

using System;
//using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



[Serializable]
public class Data
{


    public string Search;


    public string[] Specific_part;


    public string Merge;
}
public class CreatePrefabs : MonoBehaviour
{
    private string url = "https://cbotdrg92b.execute-api.eu-central-1.amazonaws.com/Digital_library_API/digital-library?x-api-key=KaFn9xEXuw8T2fOzkUa7j8dkrgMlNmQt80epCtSp";
    string jsonData;




    public GameObject prefab;
    public GameObject other;
    GameObject baseObject;
    // Start is called before the first frame update
    void Start()
    {
        init();
      //  OnMessage("LU1,LU2,LU3,LU4,LU5,LU6");
    }

    void init()
    {
        Data mydata = new Data() { Search = "All", Specific_part = new string[] { "Acupoints" }, Merge = "None" };
        // Debug.Log(mydata);
        jsonData = JsonUtility.ToJson(mydata);

        Debug.Log(jsonData);
        StartCoroutine(PostRequest());
    }


    IEnumerator PostRequest()
    {

        //  dt.Search = "All";
        // dt.SpecificPart = new string[] { "AcuPoints"};
        ///Debug.Log(dt.SpecificPart);
        //  dt.Merge = "None";

        //      UnityWebRequest request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        //     request.SetRequestHeader("x-api-key", "KaFn9xEXuw8T2fOzkUa7j8dkrgMlNmQt80epCtSp");
        //     yield return request.Send();

        //  DownloadHandlerBuffer dH = new DownloadHandlerBuffer();
        // request.downloadHandler = dH;

        //       if (request.isNetworkError || request.isHttpError)
        //        {
        //           Debug.Log("Error is : " + request.error);
        //       }
        //       else
        //       {
        //           Debug.Log("HIIII");
        //           Debug.Log("Received: ");
        //    Debug.Log(request.downloadHandler.text);
        //     Debug.Log("Received: " + uwr.downloadHandler.text);

        //Debug.Log("downloadHandler Text : " + request.downloadHandler.text);
        //             Debug.Log("responseCode : " + request.responseCode);
        //  Debug.Log("isDone : " + request.isDone);
        // Debug.Log("method : " + request.method);

        //var uwr = new UnityWebRequest(url, "POST");
        //byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        // uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        // uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        // uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        // yield return uwr.SendWebRequest();

        // if (uwr.isNetworkError||uwr.isHttpError)
        // {
        //     Debug.Log("Error While Sending: " + uwr.error);
        // }
        //  else
        // {
        //     Debug.Log("Received: " + uwr.downloadHandler.text);
        // }


        /* using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData))
         {
             yield return www.SendWebRequest();

             if (www.isNetworkError || www.isHttpError)
             {
                 Debug.Log(www.error);
             }
             else
             {
                 Debug.Log("Form upload complete!");
             }
         }
         */



        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("x-api-key", "KaFn9xEXuw8T2fOzkUa7j8dkrgMlNmQt80epCtSp");
        //  request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log("Something went wrong, and returned error: " + request.error);
            // requestErrorOccurred = true;
        }
        else
        {
            //  Debug.Log("Response: " + request.downloadHandler.text);
            string a = request.downloadHandler.text;
            Debug.Log(a);
            var words = a.Split(new char[] { '[', ']' });
            Debug.Log(words[1]);
            words[1] = words[1].Replace("\"", string.Empty);
            words[1] = words[1].Replace(" ", string.Empty);
            OnMessage(words[1]);
          //  OnMessage("LIV1,LIV2,LIV3,LIV4,LIV5,LIV6,LIV7, LIV8, LIV9, LIV10, LIV11, LIV12, LIV13, LIV14, GB1, GB2, GB3, GB4, GB5, GB6, GB7, GB8, GB9, GB10, GB11, GB12, GB13, GB14, GB15, GB16, GB17, GB18, GB19, GB20, GB21, GB22, GB23, GB24, GB25, GB26, GB27, GB28, GB29, GB30, GB31, GB32, GB33, GB34, GB35, GB36, GB37, GB38, GB39, GB40, GB41, GB42, GB43, GB44, H1, H2, H3, H4, H5, H6, H7, H8, H9, SI1, SI2, SI3, SI4, SI5, SI6, SI7, SI8, SI9, SI10, SI11, SI12, SI13, SI14, SI15, SI16, SI17, SI18, SI19, P1, P2, P3, P4, P5, P6, P7, P8, P9, SJ1, SJ2, SJ3, SJ4, SJ5, SJ6, SJ7, SJ8, SJ9, SJ10, SJ11, SJ12, SJ13, SJ14, SJ15, SJ16, SJ17, SJ18, SJ19, SJ20, SJ21, SJ22, SJ23, ST1, ST2, ST3, ST4, ST5, ST6, ST7, ST8, ST9, ST10, ST11, ST12, ST13, ST14, ST15, ST16, ST17, ST18, ST19, ST20, ST21, ST22, ST23, ST24, ST25, ST26, ST27, ST28, ST29, ST30, ST31, ST32, ST33, ST34, ST35, ST36, ST37, ST38, ST39, ST40, ST41, ST42, ST43, ST44, ST45, SP1, SP2, SP3, SP4, SP5, SP6, SP7, SP8, SP9, SP10, SP11, SP12, SP13, SP14, SP15, SP16, SP17, SP18, SP19, SP20, SP21, LU1, LU2, LU3, LU4, LU5, LU6, LU7, LU8, LU9, LU10, LU11, LI1, LI2, LI3, LI4, LI5, LI6, LI7, LI8, LI9, LI10, LI11, LI12, LI13, LI14, LI15, LI16, LI17, LI18, LI19, LI20, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15, K16, K17, K18, K19, K20, K21, K22, K23, K24, K25, K26, K27, UB1, UB2, UB3, UB4, UB5, UB6, UB7, UB8, UB9, UB10, UB11, UB12, UB13, UB14, UB15, UB16, UB17, UB18, UB19, UB20, UB21, UB22, UB23, UB24, UB25, UB26, UB27, UB28, UB29, UB30, UB31, UB32, UB33, UB34, UB35, UB36, UB37, UB38, UB39, UB40, UB41, UB42, UB43, UB44, UB45, UB46, UB47, UB48, UB49, UB50, UB51, UB52, UB53, UB54, UB55, UB56, UB57, UB58, UB59, UB60, UB61, UB62, UB63, UB64, UB65, UB66, UB67, DU1, DU2, DU3, DU4, DU5, DU6, DU7, DU8, DU9, DU10, DU11, DU12, DU13, DU14, DU15, DU16, DU17, DU18, DU19, DU20, DU21, DU22, DU23, DU24, DU25, DU26, DU27, DU28, REN1, REN2, REN3, REN4, REN5, REN6, REN7, REN8, REN9, REN10, REN11, REN12, REN13, REN14, REN15, REN16, REN17, REN18, REN19, REN20, REN21, REN22, REN23, REN24");
            // GameObject.Find("sample").GetComponentInChildren<Text>().text = words[1];
            //   var w1 = words[0].Split('[');
            //  Debug.Log(w1);


            // List<string> subr = a.Split(':').ToList();
            // List<string> result = subr[1].Split(',').ToList();
            //  foreach (string i in result)
            // {
            //     Debug.Log(i);
            // }
            // JObject json = JObject.Parse(a);
            //var userObj = JObject.Parse(a);
            //  Debug.Log(result);

            //var userGuid = Convert.ToString(userObj["Data"]["guid"]);
        }
    }
        void OnMessage(string Message)
        {
        String[] separator = { "," };
        IList<string> strList = new List<string>(Message.Split(separator, StringSplitOptions.RemoveEmptyEntries));
        int j = -400;
        for (int i = 0; i < strList.Count; i++)
        {
            
                GameObject Point = Instantiate(prefab, new Vector3(j, 0, 0), transform.rotation) as GameObject;
                Point.transform.SetParent(other.transform, false);
                Point.name = strList[i] + " List";
                Point.GetComponentInChildren<Text>().text = strList[i];
            Debug.Log(strList[i]);
            j += 180 + 20;
            
         if (GameObject.FindWithTag("AcuPointPrefab"))
         {
                GameObject.Find(strList[i] + " List").SendMessage("MessagefromCreatePrefab", Message);
                Debug.Log("Msg Sent to :" + strList[i] + " List");
                Debug.Log("The message is "+Message);
            }
        }
        strList.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
