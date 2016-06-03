using UnityEngine;
using System.Collections;

public class RoadScript : MonoBehaviour {

    //The road script controls the spawning and removal of roads

    //Variable used to set the time for destruction
    private float removal = 2.0f;
	
    void OnTriggerExit(Collider col)
    {
        
        //There is a collision box on the road, and when the player(s) exit this it spawns a new instance of roads, while starting a coroutine that destroys the roads after a given time
        if (col.gameObject.name == "Player-2" || col.gameObject.name == "Player-1")
        {
            RoadManager.Instance.Spawn();
            RoadManager.Instance.spawncoin();
            StartCoroutine(Remove());
        }
    }

    // Removes the roads after 2 seconds
    IEnumerator Remove() {
        yield return new WaitForSeconds(removal);
        Destroy(this.gameObject);
    }

    }


