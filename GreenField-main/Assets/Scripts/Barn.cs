using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    public GameObject priceTable;
    public GameObject shop;
    public GameObject barnWindow;

    public string[] productName;

    public int storageSize;
    public int numberOfProducts;

    public int[] id;
    public int[] count;
    public int[] sellingPrice;

    // Start is called before the first frame update
    void Start()
    {
        numberOfProducts = 7;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < storageSize; i++)
        {
            sellingPrice[i] = priceTable.GetComponent<Price>().sellingPrice[id[i]];

            productName[i] = shop.GetComponent<Shop>().productName[id[i]];
        }
    }

    public void Close()
    {
        barnWindow.SetActive(false);
    }

    public void Open()
    {
        barnWindow.SetActive(true);
    }
}


