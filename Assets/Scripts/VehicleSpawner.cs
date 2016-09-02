using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

    public float startOffset=10f;
    public GameObject[] vehiclePrefabs;
    public float speed = 5.0f;
    public float length = 10f;

   
    

	// Use this for initialization
	void Start () {

        instantiateVehicle();
       
        
	}

    Vector3 getPositionOffset ()
    {
       Vector3 pos =  transform.position;
        pos += startOffset * Vector3.right;

        return pos;
    }

    void instantiateVehicle ()
    {
        GameObject vehicle = Instantiate(vehiclePrefabs[0]);
        vehicle.transform.position = getPositionOffset();
        vehicle.transform.parent = transform;

        Vehicle vehicleObject = vehicle.GetComponent<Vehicle>();
        vehicleObject.setPath(speed,length);

       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
