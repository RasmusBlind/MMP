using UnityEngine;
using System.Collections;

public class startsynch : MonoBehaviour {

	[PunRPC]
    void go()
    {
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Speedcontroller>().enabled = true;
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Speedcontroller>().enabled = true;


    }
}
