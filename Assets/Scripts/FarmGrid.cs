using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    public int columnLength, rowLength;

    public float xSpace, zSpace;

    public GameObject grass;
    public GameObject[] currentGrid;

    public bool gotGrid;
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < columnLength*rowLength; i++)
        {
            Instantiate(grass, new Vector3(xSpace +(xSpace * (i % columnLength)), 0, zSpace + (zSpace * (i / columnLength))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gotGrid == false)
        {
            currentGrid = GameObject.FindGameObjectsWithTag("grid");

            gotGrid = true;
        }
    }
}
