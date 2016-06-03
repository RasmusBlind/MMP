using UnityEngine;
using System.Collections;

public class RoadManager : MonoBehaviour {

    // for control of road spawns
	public GameObject roadPrefab;
	public GameObject currentRoad;
    public GameObject Coin;
    private static RoadManager instance;

    // for control of coins spawned
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
        // the chance of a coins to spawn range(0,1) == 50%
        int spawnCoin = Random.Range(0, 1);
        // checking if we are spawning
        if (spawnCoin == 0)
        {
            // sets the amount of coins spawned to 0
            coinspawned = 0;
            
            // makes an boolean to controll a while loop this is used to spawn multiple coins in coins are to spawn 
            bool j = true;
            // get a random number of coins to spawn
            int numberspawn = Random.Range(1, 4);
            // makes the array oldlanenumber the size of the amount of coins we have to spawn, we use this array to check if there have been a spawn in the different lanes, we do not want the coins to be spawned ontop of each other
            oldlanenumber = new int[numberspawn];
            
            // while loop to spawn all the coins
            while ( j == true)
            {
                // gets a new lane for checking
                newlanenumber = Random.Range(1, 8);
                // says that the lane is free if nothing else are detected
                freeposition = true;
                // we go through all the position in oldlanenumber to see if this lane have been taken 
                foreach (int i in oldlanenumber)
                {
                    if(i == newlanenumber)
                    {
                        freeposition = false;
                    }
                }
                // if the position are free we spawn an coin of the position in the lane 
                if (freeposition == true)
                {
                    Instantiate(Coin, new Vector3(GameObject.FindGameObjectWithTag("lane" + newlanenumber).transform.position.x, currentRoad.transform.position.y, currentRoad.transform.position.z - 0.8f), Quaternion.Euler(180, 0, 0));
                    // addes the new coins position to the oldlanenumber list
                    oldlanenumber[coinspawned] = newlanenumber;
                    // addes 1 to the number of coins spawned
                    coinspawned++;
                }
                // here we check if we have spawned all
                if (coinspawned >= numberspawn)
                {
                    j = false;
                }
            }

        }
    }
}
