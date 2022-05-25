using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RTLTMPro;

public class FinalTestPanel : MonoBehaviour
{
    public RTLTextMeshPro Result;
    public TestManager testManager;
    public GameObject Testpanel;


    private void OnEnable()
    {
        Result.text = testManager.TestResult.ToString()+"/20";
    }
    // Start is called before the first frame update
    public void HideTestManager()
    {
        Testpanel.SetActive(false);
    }

    private void Update()
    {
        
    }
}
