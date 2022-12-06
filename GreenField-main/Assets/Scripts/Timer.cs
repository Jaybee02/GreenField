//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class Timer : MonoBehaviour
//{
//    public float timeRemaining = 10;
//    public bool timerIsRunning = false;
//    public TextMeshProUGUI timerText;
//    public FarmGrid farmGrid;

//    // Start is called before the first frame update
//    void Start()
//    {
//        timerIsRunning = true;
//        farmGrid = GetComponent<FarmGrid>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //StartTimer();
//    }

//    public void StartTimer()
//    {
//        if (timeRemaining > 0 && farmGrid.maizeHarvest >= 1)
//        {
//            timeRemaining -= Time.deltaTime;
//            timerText.text = Mathf.Round(timeRemaining).ToString();
//            print(timeRemaining);
//            print("Hello");
//            print(farmGrid.maizeHarvest);
//            //DisplayTime(minutes);

//        }
//        else
//        {
//            print("Time out");
//            timerIsRunning = false;
//            timeRemaining = 0;
//        }
//    }
//}
