using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pest : MonoBehaviour
{
    //public Transform[] Positions;
    //public GameObject Object;
    //public Transform Location;

    //public bool ToSpawn = true;

    //public FarmGrid farmGrid;

    // Start is called before the first frame update
    void Start()
    {
        //farmGrid = GetComponent<FarmGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        //Location = Positions[Random.Range(0,Positions.Length)];

        //if(ToSpawn == true)
        //{
        //    Instantiate(Object, Location);
        //    ToSpawn = false;
        //    StartCoroutine(ToSpawnTrue());

        //}
    }

    //IEnumerator ToSpawnTrue()
    //{
    //    yield return new WaitForSeconds(0.75f);
    //    ToSpawn = true;
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pest"))
        {
            print("collded with " + collision.gameObject.name);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(collision.gameObject);
    //    print("destroy");
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("maize"))
        {
            print("maize");
        }
    }
}
