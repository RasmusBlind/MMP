using UnityEngine;
using System.Collections;

public class coincollision : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (GameObject.FindGameObjectWithTag("Player1.1").transform.position.y-gameObject.transform.position.y > 50)
        {
            Destroy(gameObject);
        }
        
	}
    void OnTriggerEnter(Collider col)
    {
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
