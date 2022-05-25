using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;
using UnityEngine.UI;
using System.Linq;
using System;

public class ArabicFixerScript : MonoBehaviour
{

    public static ArabicFixerScript instance;

    public delegate void Language_Arabic();
    public static event Language_Arabic LanguageArabicEventFire;

    [TextArea]
    internal string arabicText;
    public Text textComponent;

    string keyName;
    public List<string> resultText;
    public RectTransform rt;
    private void Awake()
    {
        instance = this;
        textComponent = GetComponent<Text>();
        List<string> resultText = new List<string>();
        rt = textComponent.GetComponent<RectTransform>();
        FixArabicText();
    }

    private void OnEnable()
    {
        LanguageArabicEventFire += FixArabicText;
    }
    private void OnDisable()
    {
        LanguageArabicEventFire -= FixArabicText;
    }


    void FixArabicText()
    {
        StartCoroutine(FixLineOrder());
    }

    public void SetArabicText(string text)
    {
        this.arabicText = text;
        StartCoroutine(FixLineOrder());
    }

    private void OnValidate()
    {
        StartCoroutine(FixLineOrder());
    }

    public IEnumerator FixLineOrder()
    {
        //List<string> resultText = new List<string>();
        //RectTransform rt = textComponent.GetComponent<RectTransform>();
        List<string> paragraphList = arabicText.Split('\n').ToList();
        print(arabicText);
        foreach (string paragraph in paragraphList)
        {
            textComponent.text = ArabicFixer.Fix(paragraph, false, false);
            TextGenerationSettings tgs = textComponent.GetGenerationSettings(rt.rect.size);

            if (textComponent.text.IndexOf(' ') < 0)
            {
                resultText.Add(textComponent.text);
            }
            else
            {
                List<string> lineList = new List<string>();
                List<string> wordList = textComponent.text.Split(' ').ToList();
                string singleLine = "";

                while (wordList.Count > 0)
                {
                    string singleWord = wordList[wordList.Count - 1];
                    wordList.RemoveAt(wordList.Count - 1);

                    if (textComponent.cachedTextGenerator.GetPreferredWidth(singleWord + ' ' + singleLine, tgs) > rt.rect.width)
                    {
                        lineList.Add(singleLine);
                        singleLine = singleWord;
                    }
                    else
                    {
                        singleLine = (singleLine != "") ? singleWord + ' ' + singleLine : singleWord;
                    }

                }

                if (singleLine.Length > 0)
                    lineList.Add(singleLine);

                resultText.Add(string.Join(Environment.NewLine, lineList.ToArray()));

            }

            if (!Application.isEditor)
                yield return new WaitForEndOfFrame();

        }
        textComponent.text = string.Join(Environment.NewLine, resultText.ToArray());
    }

}