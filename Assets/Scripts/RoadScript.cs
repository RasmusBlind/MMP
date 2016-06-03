using UnityEngine;
using System.Collections;

public class RoadScript : MonoBehaviour {

    private float removal = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider col)
    {
        

        if (col.gameObject.name == "Player-2" || col.gameObject.name == "Player-1")
        {
            RoadManager.Instance.Spawn();
            RoadManager.Instance.spawncoin();
            StartCoroutine(Remove());

            Debug.Log("It collides");
        }
    }

    IEnumerator Remove() {
        yield return new WaitForSeconds(removal);
        Destroy(this.gameObject);
    }

    }


