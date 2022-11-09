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

    //new
    public GameObject hitted;
    public GameObject field;

    private RaycastHit _Hit;

    public bool creatingFields;
    //end

    public Texture2D basicCursor, fieldCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject goldSystem;

    public int fieldsPrice;

    void Awake()
    {
        Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
    }
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

        //new
        if(Input.GetMouseButtonDown (0))
        {
            if(Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out _Hit))
            {
                if(creatingFields == true)
                {
                    if(_Hit.transform.tag == "grid" && goldSystem.GetComponent<GoldSystem>().gold >= fieldsPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(field,hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= fieldsPrice;
                    }
                }
            }
        }
        if(creatingFields == true)
        {
            Cursor.SetCursor(fieldCursor, hotSpot, cursorMode);
        }
    }

    //new3
    public void CreateFields()
    {
        creatingFields = true;
    }

    public void returnToNormality()
    {
        creatingFields = false;
    }
    //end3
}
