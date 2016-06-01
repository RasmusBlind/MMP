using UnityEngine;
using System.Collections;

public class Cameramov : MonoBehaviour {

    public Vector3 myPos;
    public Transform myPlay;
     
    void Update()
    {
        transform.position = myPlay.position + myPos;
    }

}
