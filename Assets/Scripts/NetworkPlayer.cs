using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {
    public Camera myCam;

    // Use this for initialization
    void Start () {
        if (photonView.isMine)
            myCam.enabled = true;
}
	
	// Update is called once per frame
	void Update () {
	
	}
}
