using UnityEngine;
using UnityEngine.UI;
using System;
[RequireComponent(typeof(Text))]
public class SetArabicFixedText : MonoBehaviour
{
    [SerializeField]
    bool useTashkeel; // display the morphology (movements) in the text? //
    [SerializeField]
    bool useHinduNumbers; // Use Arabic (or Hindi, as you would like to call it) numbers?
    [SerializeField]
    Text textUI; // we know a variable that holds a text object / element
    private string neededText;

    void Start()
    {
        textUI = GetComponent<Text>();
        Invoke("AlignArabicText", .5f);
    }

    void AlignArabicText()
    {

        if (textUI.text != string.Empty)
        {
            neededText = textUI.text;
            textUI.text = textUI.FixArabicUITextLines(useTashkeel, useHinduNumbers, neededText);

        }
    }
    
}