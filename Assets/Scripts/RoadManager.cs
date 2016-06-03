using UnityEngine;
using System.Collections;

public class RoadManager : MonoBehaviour {


	public GameObject roadPrefab;
	public GameObject currentRoad;
    public GameObject Coin;
    private static RoadManager instance;
    private int newlanenumber;
    private int [] oldlanenumber;
    private int coinspawned;
    private bool freeposition = true;

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
            spawncoin();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn (){
        //Make sure the new spawned road becomes the current one, and cast it as a gameobject
       currentRoad = (GameObject)Instantiate(roadPrefab, currentRoad.transform.GetChild(0).position, Quaternion.identity);
        
    }
    public void spawncoin()
    {
        int spawnCoin = Random.Range(0, 1);

        if (spawnCoin == 0)
        {
            coinspawned = 0;
            
            int j = 0;
            int numberspawn = Random.Range(1, 4);
            oldlanenumber = new int[numberspawn];
            
            while ( j == 0)
            {
                newlanenumber = Random.Range(1, 8);
                freeposition = true;
                foreach (int i in oldlanenumber)
                {
                    if(i == newlanenumber)
                    {
                        freeposition = false;
                    }
                }
                if (freeposition == true)
                {
                    Instantiate(Coin, new Vector3(GameObject.FindGameObjectWithTag("lane" + newlanenumber).transform.position.x, currentRoad.transform.position.y, currentRoad.transform.position.z - 0.8f), Quaternion.Euler(180, 0, 0));
                    oldlanenumber[coinspawned] = newlanenumber;
                    coinspawned++;
                }
                if (coinspawned >= numberspawn)
                {
                    j++;
                }
            }

        }
    }
}
