using UnityEngine;
using System.Collections;

public class startsynch : MonoBehaviour {


    // a photon extention to be used on both players
	[PunRPC]
    void go()
    {
        // we set both cars in motions 
        GameObject.FindGameObjectWithTag("Player1").GetComponent<Speedcontroller>().enabled = true;
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Speedcontroller>().enabled = true;


    }
}
