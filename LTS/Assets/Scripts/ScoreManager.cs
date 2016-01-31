using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int sheep;
    public int shepherd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Sheep " +  sheep + ":" + shepherd + " Shepherd";
	}
}
