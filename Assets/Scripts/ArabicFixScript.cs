using UnityEngine;
using ArabicSupport;
using UnityEngine.UI;

public class ArabicFixScript : MonoBehaviour
{
    public bool OnEnableTrue;
    void Awake()
    {
        if (gameObject.GetComponent<Text>())
        {
            string oldText = gameObject.GetComponent<Text>().text;
            gameObject.GetComponent<Text>().text = ArabicFixer.Fix(oldText);
        }
    }
    void OnEnable()
    {
        if (gameObject.GetComponent<Text>() && OnEnableTrue)
        {
            string oldText = gameObject.GetComponent<Text>().text;
            //gameObject.GetComponent<Text>().text = ArabicFixer.Fix(oldText);
            gameObject.GetComponent<Text>().text = ArabicFixer.Fix(oldText);
        }
    }


}
