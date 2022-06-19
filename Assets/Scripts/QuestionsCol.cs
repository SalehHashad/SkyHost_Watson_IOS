using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsCol : MonoBehaviour
{
    public int Number;
    public GameObject popuppanel;
    public GameObject ThiusBtn;
    public RawImage ImagePopUp;
    public Texture ThisBtnImag;
    // Start is called before the first frame update

    private void Awake()
    {
        ThiusBtn = this.gameObject;
        popuppanel = GameObject.Find("PopUpImage");
        ImagePopUp = popuppanel.GetComponentInChildren<RawImage>();
        ThisBtnImag = ThiusBtn.GetComponent<RawImage>().texture;
    }

    void Start()
    {
        
        
    }

    public void showpanel()
    {
        popuppanel.SetActive(true);
        ImagePopUp.texture = ThisBtnImag;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
