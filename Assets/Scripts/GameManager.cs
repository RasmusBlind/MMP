using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int scoreplayer1 = 0;
    public int scoreplayer2 = 0;
    public Texture boxback;
    // Use this for initialization
    public GUIStyle myStyle;
    public GUIStyle mySecondStyle;
	void Start () {
        
    }
    void OnGUI()
    {
        
        GUI.color = Color.red;
        GUI.Box(new Rect(5, 10, 140, 20), "Red Player Score:  " + scoreplayer1, myStyle);
        GUI.color = Color.blue;
        GUI.Box(new Rect(5, 30, 140, 20), "Blue Player Score: " + scoreplayer2, mySecondStyle);
        
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
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Speedcontroller>().enabled = false;
        }

    }

    

    public void addpointplayer1()
    {
        scoreplayer1 += 10;
    }
    public void addpointplayer2()
    {
        scoreplayer2 += 10;
    }
}
