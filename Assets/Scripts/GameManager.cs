using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // these variables hold the score of each player
    public int scoreplayer1 = 0;
    public int scoreplayer2 = 0;
    // these variables are for styling of the GUI, GUIStyle are edited from the unity interface
    public Texture boxback;
    public GUIStyle myStyle;
    public GUIStyle mySecondStyle;
	void Start () {
        
    }
    void OnGUI()
    {
        // here we print the score to the screen with different colors and a specific style
        GUI.color = Color.red;
        GUI.Box(new Rect(5, 10, 140, 20), "Red Player Score:  " + scoreplayer1, myStyle);
        GUI.color = Color.blue;
        GUI.Box(new Rect(5, 30, 140, 20), "Blue Player Score: " + scoreplayer2, mySecondStyle);
        
        //if either of the player have a score above 100(i.e. 110) we will print to the screen the winner and stop each car
        if (scoreplayer1> 100)
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 134, 20), "   Red Player Wins!!   ", myStyle);
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Speedcontroller>().enabled = false;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            GameObject.FindGameObjectWithTag("Player2").GetComponent<Speedcontroller>().enabled = false;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else if (scoreplayer2> 100)
        {
            GUI.color = Color.blue;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 134, 20), "   Blue Player Wins!!   ", mySecondStyle);
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Speedcontroller>().enabled = false;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Speedcontroller>().enabled = false;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

    }

    
    // this function are used by the Remote Procedure Call to add point to the players
    public void addpointplayer1()
    {
        scoreplayer1 += 10;
    }
    public void addpointplayer2()
    {
        scoreplayer2 += 10;
    }
}
