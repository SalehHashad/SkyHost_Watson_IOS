using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using RTLTMPro;
using TMPro;

public class ScoreRecord : MonoBehaviour {

	public RTLTextMeshPro Name;
	public RTLTextMeshPro Score;
	public string namee;
	public string scoree;

	private void OnEnable(){
	var textFields = GetComponentsInChildren<RTLTextMeshPro>();
	Name = textFields.First(f => f.name == "name");
	Score = textFields.First(f => f.name == "score");
	}

	public void WriteRecord(string name, string score)
	{
		Name.text = name;
		namee= name;
		Score.text = score;
		scoree = score;
	}



}
