using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using RTLTMPro;

public class ContactUs : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject subject;

    private string Name;
    private string Email;
    private string Subject;
    public string URL;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfW2Kdl_3-sqgMWGqtOhigjljpfQBiQpTS3kuQLAy2HOFpvWQ/formResponse?usp=pp_url&entry.2005620554=med&entry.1045781291=med5@gmao.cm&entry.839337160=test";

    public string APIkey = "";

    // Start is called before the first frame update
    IEnumerator Post(string name, string email, string subject)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2005620554", name);
        form.AddField("entry.1045781291", email);
        form.AddField("entry.839337160", subject);
        /*
        ** Outdated
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
        */
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();  

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    public void Request()
    {
        WWWForm form = new WWWForm();
        Dictionary<string, string> headers = form.headers;
        headers["TOKEN"] = APIkey;

        WWW request = new WWW(URL, null, headers);
        StartCoroutine(OnResponse(request));
    }
    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        // string json =JsonUtility.ToJson()
        //outputext.text = req.text;
        string data = req.text;
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    public void Send()
    {
        Name = username.GetComponent<RTLTextMeshPro>().text;
        //Debug.Log(Name);
        Email = email.GetComponent<RTLTextMeshPro>().text;
        //Debug.Log(Email);
        Subject = subject.GetComponent<RTLTextMeshPro>().text;
        URL = "https://docs.google.com/forms/d/e/1FAIpQLSfW2Kdl_3-sqgMWGqtOhigjljpfQBiQpTS3kuQLAy2HOFpvWQ/formResponse?usp=pp_url&entry.2005620554=" + Name + "&entry.1045781291=" + Email + "&entry.839337160=" + Subject;

        //StartCoroutine(GetRequest(Urll));
        Request();

        //Debug.Log(Subject);
        //StartCoroutine(Post(Name, Email, Subject));

    }
}
