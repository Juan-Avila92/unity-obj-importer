using Dummiesman;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Import : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    string objPath = "D:/RevitApiProjects/PrinceGeorge.obj";
    string error = string.Empty;
    GameObject loadedObject;

    
    public void ImportObj()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://3dvs-aras.s3-us-west-2.amazonaws.com/assets/PrinceGeorge.obj");
        StartCoroutine(WaitAndPrint(www));
    }

    
    private IEnumerator WaitAndPrint(UnityWebRequest www)
    {
        yield return www.SendWebRequest();
        
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("https://3dvs-aras.s3-us-west-2.amazonaws.com/assets/PrinceGeorge.obj");
            Debug.LogError(www.error);
            Debug.LogError("HOLAA");
        }
        else
        {
            var textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.downloadHandler.text));
            GameObject objModel = new GameObject();
            objModel = new OBJLoader().Load(textStream);

        }
    }
}
