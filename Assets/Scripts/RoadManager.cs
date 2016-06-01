using UnityEngine;
using System.Collections;

public class RoadManager : MonoBehaviour {


	public GameObject roadPrefab;
	public GameObject currentRoad;
    private static RoadManager instance;

    public static RoadManager Instance
    {
        get
        {//If it doesn't exist yet
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<RoadManager>();
            }
            return RoadManager.instance;
        }
    }

    // Use this for initialization
    void Start () {
        //try to spawn it 10 times
        for(int i = 0; i < 10; i++) { 
        Spawn();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn (){
        //Make sure the new spawned road becomes the current one, and cast it as a gameobject
       currentRoad = (GameObject)Instantiate(roadPrefab, currentRoad.transform.GetChild(0).position, Quaternion.identity);

      int spawnCoin = Random.Range(0, 10);

        if (spawnCoin == 0)
        {
            currentRoad.transform.Find("Road/lanepos4/Coin").gameObject.SetActive(true);
        }

    }
}
