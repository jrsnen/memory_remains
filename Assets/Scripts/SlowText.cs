using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlowText : MonoBehaviour {

    private string str;

    public Text text;

    public float textWait = 0.5F;
    public float destroyWait = 3.0F;

	private string[] memories = new string[13] {"Everything feels so blurry. Where am I ? What is going on?",
    "She held the cup in her hands and smiled warmly. It was the most beautiful smile. She laughed and i felt happiness spread through me. If only I could remember who she is?",
    "It’s the woman from my memory.",
    "She threw the bottle on the floor. Shards of glass flew all around the floor and anger gushed over me. How could she? Why would she do this to me?",
    "I read the note. It was a hospital bill. Who’s was it?",
    "The lights. The noises. They pierced through me. I could barely move. I stared at her lying there. Her eyes closed. Red trail of blood escaped from the corner of her mouth. This wasn’t real, this couldn’t be happening, could it? The horror engulf me…",
    "I read the letter. “Patient is released from the treatment” What treatment? Who was treated and where?",
    "I was backing her clothes when I found her diary. I reached for the book with shaking hands. When I read her words It was as if she was still here, whispering her words to me. I felt the guilt and sorrow wash over me.",
    "What is this document? Patience is suffering from deep depression and psychotic behavior...",
    "The music played on the radio. She turned it off. I looked at her but I couldn't read her",
    "The door is finally open.",
    "The images flooded over me. Her smile, the terror, the blood. The brash voices of the sirens. I stared at her lifeless body next to me and moved my gaze to her hands. They were still squeezing the steering wheel… I should have been there to stop her but I wasn’t...",
    "I wasn’t there to stop her from herself. I made one mistake. Could I punish myself forever for it? Would I..."};

    public uint memNum = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(AnimateText(memories[memNum]));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator AnimateText(string strComplete)
    {

        int i = 0;
        str = "";
        Debug.Log("TexWrite starting:" + strComplete.Length);
        while (i < strComplete.Length)
        {
            //Debug.Log("Writing text:" + i + "/" + strComplete.Length);
            str += strComplete[i++];
            text.text = str;
            yield return new WaitForSeconds(textWait);
        }
        Debug.Log("TexWrite finished");

        yield return new WaitForSeconds(destroyWait);

        Destroy(this.gameObject);
    }
}
