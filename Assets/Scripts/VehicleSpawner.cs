using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

    public float startOffset=10f;
    public GameObject[] vehiclePrefabs;
    public float speed = 5.0f;
    public float length = 10f;

    public float maxSpawnTime = 10.0f;

   
    

	// Use this for initialization
	void Start () {

        StartCoroutine("Spawn");
       
       
        
	}

    //Spawn Interval Method
    IEnumerator Spawn ()
    {
        while (true)

        {
            float spawnTime = Random.Range(0.5f, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            instantiateVehicle();
          
        }
    }

    Vector3 getPositionOffset ()
    {
       Vector3 pos =  transform.position;
        pos += startOffset * Vector3.right;

        return pos;
    }

    void instantiateVehicle ()
    {
        int spawnVehicle = Random.Range(0, vehiclePrefabs.Length);
        GameObject vehicle = Instantiate(vehiclePrefabs[spawnVehicle]);
        vehicle.transform.position = getPositionOffset();
        vehicle.transform.parent = transform;

        Vehicle vehicleObject = vehicle.GetComponent<Vehicle>();
        vehicleObject.setPath(speed,length);

       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
