using UnityEngine;
using System.Collections;

public class SlowText : MonoBehaviour {

    private string str;

    public GUIText text;

	// Use this for initialization
	void Start () {
        StartCoroutine(AnimateText("Something gibrish to see if text displaying works slowly. This is a dream or is it not. We do not exist."));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator AnimateText(string strComplete)
    {

        int i = 0;
        str = "";
        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            text.text = str;
            yield return new WaitForSeconds(0.5F);


        }
    }
}
