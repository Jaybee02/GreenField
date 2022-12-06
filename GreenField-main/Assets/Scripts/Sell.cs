//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class Sell : MonoBehaviour
//{
//    private GameObject goldSystem;
//    private GameObject farmGrid;

//    private int maizeHarvest;
//    private int tomatoesHarvest;
//    private int carrotHarvest;
//    private int beetHarvest;
//    private int bellHarvest;
//    private int melonHarvest;
//    private int cabbageHarvest;

//    private TextMeshProUGUI maizeHarvestText;
//    private TextMeshProUGUI tomatoesHarvestText;
//    private TextMeshProUGUI carrotHarvestText;
//    private TextMeshProUGUI beetHarvestText;
//    private TextMeshProUGUI bellHarvestText;
//    private TextMeshProUGUI melonHarvestText;
//    private TextMeshProUGUI cabbageHarvestText;

//    private int maizeHarvest2;
//    private int tomatoesHarvest2;
//    private int carrotHarvest2;
//    private int beetHarvest2;
//    private int bellHarvest2;
//    private int melonHarvest2;
//    private int cabbageHarvest2;
//    // Start is called before the first frame update
//    void Start()
//    {
//        //maizeHarvest = farmGrid.GetComponent<FarmGrid>().maizeHarvest;
//        //maizeHarvest2 = farmGrid.GetComponent<FarmGrid>().maizeHarvest2;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void SellMaize()
//    {
//        if (maizeHarvest > 1)
//        {
//            goldSystem.GetComponent<GoldSystem>().gold += 20;
//            maizeHarvest--;
//            maizeHarvest2--;
//            maizeHarvestText.text = maizeHarvest2.ToString();
//        }
//        else if (maizeHarvest == 1 && maizeHarvest2 < 1)
//        {
//            print("You do not have maize in barn");
//            return;
//        }
//    }

//    public void SellTomatoes()
//    {
//        if (tomatoesHarvest > 1)
//        {
//            goldSystem.GetComponent<GoldSystem>().gold += 30;
//            tomatoesHarvest--;
//            tomatoesHarvest2--;
//            farmGrid.GetComponent<FarmGrid>().tomatoesHarvestText.text = tomatoesHarvest2.ToString();
//        }
//        else if (tomatoesHarvest == 1 && tomatoesHarvest2 < 1)
//        {
//            print("You do not have tomatoes in barn");
//            return;
//        }
//    }

//    public void SellCarrot()
//    {
//        if (carrotHarvest > 1)
//        {
//            goldSystem.GetComponent<GoldSystem>().gold += 40;
//            carrotHarvest--;
//            carrotHarvest2--;
//            farmGrid.GetComponent<FarmGrid>().carrotHarvestText.text = carrotHarvest2.ToString();
//        }
//        else if (carrotHarvest == 1 && carrotHarvest2 < 1)
//        {
//            print("You do not have carrot in barn");
//            return;
//        }
//    }

//    public void SellBeet()
//    {
//        if (beetHarvest > 1)
//        {
//            goldSystem.GetComponent<GoldSystem>().gold += 50;
//            beetHarvest--;
//            beetHarvest2--;
//            farmGrid.GetComponent<FarmGrid>().beetHarvestText.text = beetHarvest2.ToString();
//        }
//        else if (beetHarvest == 1 && beetHarvest2 < 1)
//        {
//            print("You do not have maize in barn");
//            return;
//        }
//    }

//    public void SellBell()
//    {
//        if (bellHarvest > 1)
//        {
//            goldSystem.GetComponent<GoldSystem>().gold += 60;
//            bellHarvest--;
//            bellHarvest2--;
//            farmGrid.GetComponent<FarmGrid>().bellHarvestText.text = bellHarvest2.ToString();
//        }
//        else if (bellHarvest == 1 && bellHarvest2 < 1)
//        {
//            print("You do not have bell pepper in barn");
//            return;
//        }
//    }

//    public void SellMelon()
//    {
//        if (melonHarvest > 1)
//        {
//            goldSystem.GetComponent<GoldSystem>().gold += 70;
//            melonHarvest--;
//            melonHarvest2--;
//            farmGrid.GetComponent<FarmGrid>().melonHarvestText.text = melonHarvest2.ToString();
//        }
//        else if (melonHarvest == 1 && melonHarvest2 < 1)
//        {
//            print("You do not have water melon in barn");
//            return;
//        }
//    }

//    public void SellCabbage()
//    {
//        if (cabbageHarvest > 1)
//        {
//            goldSystem.GetComponent<GoldSystem>().gold += 80;
//            cabbageHarvest--;
//            cabbageHarvest2--;
//            farmGrid.GetComponent<FarmGrid>().cabbageHarvestText.text = cabbageHarvest2.ToString();
//        }
//        else if (cabbageHarvest == 1 && cabbageHarvest2 < 1)
//        {
//            print("You do not have cabbage in barn");
//            return;
//        }
//    }
//}
