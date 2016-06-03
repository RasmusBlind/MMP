using UnityEngine;
using System.Collections;

public class coincollision : MonoBehaviour {
	
	void Update () {
        // here we check if the gold coin have not been picked up and destroy it, if it is far away enough
        if (GameObject.FindGameObjectWithTag("Player1.1").transform.position.y-gameObject.transform.position.y > 50)
        {
            Destroy(gameObject);
        }
        
	}
    void OnTriggerEnter(Collider col)
    {   
        //here we check if a player and what player picked up a coin
        if (col.tag == "Player1" || col.tag == "Player1.1")
        {
            GameObject.FindGameObjectWithTag("Player1.1").GetComponent<PhotonView>().RPC("addpointplayer1", PhotonTargets.All);
 
            Destroy(gameObject);
        }
        else if(col.name == "player-2" || col.tag == "Player2.1")
        {
           
            GameObject.FindGameObjectWithTag("Player2.1").GetComponent<PhotonView>().RPC("addpointplayer2", PhotonTargets.All);
            Destroy(gameObject);
        }
    }
}
