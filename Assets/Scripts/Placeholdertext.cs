using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
public class Placeholdertext : MonoBehaviour
{
    public GameObject textholdergameobject;
    public Text PlacehoderText;
    public Text Textt;
    public RTLTextMeshPro Thisgameobject;
    //string Thistext;
    // Start is called before the first frame update
    void Start()
    {
        //Thisgameobject = GetComponent<RTLTextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textholdergameobject.GetComponent<Text>().enabled) {
        Thisgameobject.text = PlacehoderText.text;
        }
        else
        {
            Thisgameobject.text = "";
        }
    }
}
