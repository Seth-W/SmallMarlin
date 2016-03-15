using UnityEngine;
using System.Collections;

public class FishSpawnBox : MonoBehaviour
{

    public GameObject fishObject;
    [SerializeField]
    private bool spawnedOnLeft;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("spawnFish", 0, 1f);
//        spawnFish();
//        spawnFish();
//        spawnFish();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void spawnFish()
    {
        Vector3 pos = transform.position;
        pos.y = UnityEngine.Random.value * 10 - 5;
        transform.position = pos;
        
        GameObject obj = GameObject.Instantiate(fishObject,transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<Fish>().spawnedOnLeft(spawnedOnLeft);

    }
}
