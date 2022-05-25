using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TestScript : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject prefabSend;
    public GameObject prefabReceive;
    public Transform parent;

    public float startingPos = 0;

    
    public InputField inputField;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject obj = Instantiate(prefabSend, new Vector3(0, 0, 0), Quaternion.identity, parent);
            obj.transform.localPosition = new Vector3(0, startingPos, 0);
            startingPos -= obj.GetComponent<RectTransform>().rect.height + 25;

            scrollRect.DOVerticalNormalizedPos(0, .2f).SetDelay(.5f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject obj = Instantiate(prefabReceive, new Vector3(0, 0, 0), Quaternion.identity, parent);
            obj.transform.localPosition = new Vector3(0, startingPos, 0);
            startingPos -= obj.GetComponent<RectTransform>().rect.height + 25;

            scrollRect.DOVerticalNormalizedPos(0, .2f).SetDelay(.5f);

        }
    }

    public void OnClickSendBtn()
    {
        SendMessageServer(inputField.text.ToString());
    }

    public void SendMessageServer(string str)
    {
        GameObject obj = Instantiate(prefabSend, new Vector3(0, 0, 0), Quaternion.identity, parent);
        obj.transform.localPosition = new Vector3(0, startingPos, 0);
        startingPos -= obj.GetComponent<RectTransform>().rect.height + 25;
        inputField.text = null;
        scrollRect.DOVerticalNormalizedPos(0, .2f).SetDelay(.5f);
    }


    void InsertMessageChatBox(string str,Text textField)
    {
        textField.text = str;
        print(str.Length);
    }

    void ChangeChatBoxHeight(int lenght)
    {
        switch(lenght)
        {
            case 150:

                break;

            default:

                break;
        }
    }

    internal enum IsolatedArabicLetters
    {
        Hamza = 0xFE80,
        Alef = 0xFE8D,
        AlefHamza = 0xFE83,
        WawHamza = 0xFE85,
        AlefMaksoor = 0xFE87,
        AlefMaksora = 0xFBFC,
        HamzaNabera = 0xFE89,
        Ba = 0xFE8F,
        Ta = 0xFE95,
        Tha2 = 0xFE99,
        Jeem = 0xFE9D,
        H7aa = 0xFEA1,
        Khaa2 = 0xFEA5,
        Dal = 0xFEA9,
        Thal = 0xFEAB,
        Ra2 = 0xFEAD,
        Zeen = 0xFEAF,
        Seen = 0xFEB1,
        Sheen = 0xFEB5,
        S9a = 0xFEB9,
        Dha = 0xFEBD,
        T6a = 0xFEC1,
        T6ha = 0xFEC5,
        Ain = 0xFEC9,
        Gain = 0xFECD,
        Fa = 0xFED1,
        Gaf = 0xFED5,
        Kaf = 0xFED9,
        Lam = 0xFEDD,
        Meem = 0xFEE1,
        Noon = 0xFEE5,
        Ha = 0xFEE9,
        Waw = 0xFEED,
        Ya = 0xFEF1,
        AlefMad = 0xFE81,
        TaMarboota = 0xFE93,
        PersianPe = 0xFB56,     // Persian Letters;
        PersianChe = 0xFB7A,
        PersianZe = 0xFB8A,
        PersianGaf = 0xFB92,
        PersianGaf2 = 0xFB8E

    }
}
