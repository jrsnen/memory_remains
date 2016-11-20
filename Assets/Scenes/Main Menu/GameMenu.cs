using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Main menu");
	
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void onClickStartGame()
    {
        UnityEngine.Cursor.visible = false;
        Application.LoadLevel(1);
    }

    public void onClickCredits()
    {
        Application.LoadLevel(2);
        Debug.Log("Drag ended!");
    }

    public void onClickExit()
    {
        Application.Quit();
    }

}
/*
var isQuit = false;

function OnMouseEnter()
{
    //change text color
    GetComponent.< Renderer > ().material.color = Color.red;
}

function OnMouseExit()
{
    //change text color
    GetComponent.< Renderer > ().material.color = Color.white;
}

function OnMouseUp()
{
    //is this quit
    if (isQuit == true)
    {
        //quit the game
        Application.Quit();
    }
    else
    {
        //load level
        Application.LoadLevel("shuffle1");
    }
}

function Update()
{
    //quit game if escape key is pressed
    if (Input.GetKey(KeyCode.Escape))
    {
        Application.Quit();
    }
}*/
