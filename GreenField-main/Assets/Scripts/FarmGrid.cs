using EasyUI.BarnEmpty;
using EasyUI.PopUp;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmGrid : MonoBehaviour
{
    public int columnLength, rowLength;
    public float xSpace, zSpace;

    public GameObject grass;
    public GameObject[] currentGrid;

    public bool gotGrid;

    public GameObject hitted;
    public GameObject wet_field;
    public GameObject field;
    public GameObject soil;
    public GameObject grid;
    public GameObject water;

    private RaycastHit _Hit;

    public bool creatingFields;
    public bool isWatering;

    public Texture2D basicCursor, fieldCursor, seedCursor, waterCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject goldSystem;
    public int fieldPrice;
    public int waterPrice;
    public int harvestPrice;

    public GameObject[] seeds;

    public TextMeshProUGUI maizeHarvestText;
    public TextMeshProUGUI tomatoesHarvestText;
    public TextMeshProUGUI carrotHarvestText;
    public TextMeshProUGUI beetHarvestText;
    public TextMeshProUGUI bellHarvestText;
    public TextMeshProUGUI melonHarvestText;
    public TextMeshProUGUI cabbageHarvestText;
    public TextMeshProUGUI error;


    public static int maizeHarvest;
    public static int carrotHarvest;
    public static int beetHarvest;
    public static int bellHarvest;
    public static int melonHarvest;
    public static int cabbageHarvest;
    public static int tomatoesHarvest;

    public static int maizeHarvest2;
    public static int tomatoesHarvest2;
    public static int carrotHarvest2;
    public static int beetHarvest2;
    public static int bellHarvest2;
    public static int melonHarvest2;
    public static int cabbageHarvest2;

    public static int totalCropsInBarn;
    public TextMeshProUGUI totalCropsInBarnText;

    public BarnEmpty barnEmpty;
    public GoldSystem GoldSystem;
    private OnClickEvents onClick;

    public Text profitText;
    public static int profit;
    public static int maizeHarvestProfit;
    public static int tomatoesHarvestProfit;
    public static int carrotHarvesProfit;
    public static int beetHarvestProfit;
    public static int bellHarvestProfit;
    public static int melonHarvestProfit;
    public static int cabbageHarvestProfit;

    //private AudioSource gameAudio;
    //public AudioClip gridSound;
    //public AudioClip harvestSound;
    //public AudioClip sowSound;


    public float timeRemaining = 20;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;


    public LeaderBoard leaderBoard;

    public Sprite imageOne;
    public Sprite imageTwo;
    public Sprite imageThree;
    public Sprite imageFour;
    public SpriteRenderer image;

    bool isDry;

    public GameObject wetLandPanel;
    public GameObject errorPanel;


    // public Timer timer;
    void Awake()
    {
        ClearCursor();
    }
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(grass, new Vector3(xSpace + (xSpace * (i % columnLength)), 0, zSpace + (zSpace * (i / columnLength))), Quaternion.identity);
        }

        barnEmpty = GetComponent<BarnEmpty>();
        GoldSystem = GetComponent<GoldSystem>();
        onClick = GetComponent<OnClickEvents>();
        // gameAudio = GetComponent<AudioSource>();
        image = GetComponent<SpriteRenderer>();

        maizeHarvest = 1;
        tomatoesHarvest = 1;
        carrotHarvest = 1;
        beetHarvest = 1;
        bellHarvest = 1;
        melonHarvest = 1;
        cabbageHarvest = 1;

        // for total num of crops in barn
        maizeHarvest2 = 0;
        tomatoesHarvest2 = 0;
        carrotHarvest2 = 0;
        beetHarvest2 = 0;
        bellHarvest2 = 0;
        melonHarvest2 = 0;
        cabbageHarvest2 = 0;
        totalCropsInBarn = 0;


        // timer = GetComponent<Timer>();
        timerIsRunning = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (gotGrid == false)
        {
            currentGrid = GameObject.FindGameObjectsWithTag("grid");
            gotGrid = true;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit))
            {
                // Create New Field

                if (creatingFields == true)
                {
                    CreateFields();
                    if (_Hit.transform.tag == "grid" && goldSystem.GetComponent<GoldSystem>().gold >= fieldPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(field, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= fieldPrice;
                    }
                    // gameAudio.PlayOneShot(gridSound, 1.0f);
                }

                // water field
                if (isDry == true)
                {
                    if (_Hit.transform.tag == "field" && goldSystem.GetComponent<GoldSystem>().gold >= fieldPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(wet_field, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= waterPrice;
                    }
                }

                // Sow seed

                if (Product.isSowing == true)
                {
                    if (_Hit.transform.tag == "wet_field" && goldSystem.GetComponent<GoldSystem>().gold >= Product.currentProductPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(seeds[Product.whichSeed], hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= Product.currentProductPrice;
                    }
                    else if (_Hit.transform.tag == "field" && goldSystem.GetComponent<GoldSystem>().gold >= Product.currentProductPrice)
                    {

                        errorPanel.SetActive(true);
                    }
                }

                // change harvested land to field

                if (Product.isSowing == false)
                {
                    if (_Hit.transform.tag == "soil" && goldSystem.GetComponent<GoldSystem>().gold >= Product.currentProductPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(grid, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);
                        goldSystem.GetComponent<GoldSystem>().gold -= harvestPrice;
                    }
                    //   gameAudio.PlayOneShot(harvestSound, 1.0f);
                }

                //HARVESTING SYSTEM

                if (creatingFields != true && Product.isSowing != true && isDry != true)
                {
                    if (_Hit.transform.tag == "maize")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        maizeHarvestText.text = maizeHarvest.ToString();
                        maizeHarvest++;
                        maizeHarvest2++;

                    }

                    if (_Hit.transform.tag == "tomatoes")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        tomatoesHarvestText.text = tomatoesHarvest.ToString();
                        tomatoesHarvest++;
                        tomatoesHarvest2++;
                    }

                    if (_Hit.transform.tag == "carrot")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        carrotHarvestText.text = carrotHarvest.ToString();
                        carrotHarvest++;
                        carrotHarvest2++;
                    }

                    if (_Hit.transform.tag == "beet")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        beetHarvestText.text = beetHarvest.ToString();
                        beetHarvest++;
                        beetHarvest2++;
                    }

                    if (_Hit.transform.tag == "bell")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        bellHarvestText.text = bellHarvest.ToString();
                        bellHarvest++;
                        bellHarvest2++;
                    }

                    if (_Hit.transform.tag == "melon")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        melonHarvestText.text = melonHarvest.ToString();
                        melonHarvest++;
                        melonHarvest2++;
                    }

                    if (_Hit.transform.tag == "cabbage")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        cabbageHarvestText.text = cabbageHarvest.ToString();
                        cabbageHarvest++;
                        cabbageHarvest2++;
                    }

                    totalCropsInBarn = maizeHarvest2 + tomatoesHarvest2 + carrotHarvest2 + beetHarvest2 + bellHarvest2 + cabbageHarvest2 + melonHarvest2;
                    if (totalCropsInBarn == 0)
                    {
                        totalCropsInBarnText.text = "0";
                    }
                    else
                    {
                        totalCropsInBarnText.text = totalCropsInBarn.ToString();

                    }
                }
            }
        }


        if (creatingFields == true)
        {
            Cursor.SetCursor(fieldCursor, hotSpot, cursorMode);
            Product.isSowing = false;
            isDry = false;
            image.sprite = imageOne;
        }

        if (isDry == true)
        {
            // Cursor.SetCursor(waterCursor, hotSpot, cursorMode);
            // image.sprite = imageFour;
            creatingFields = false;
            Product.isSowing = false;

        }

        if (Shop.beInShop == true)
        {
            creatingFields = false;
            isDry = false;
            Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
        }

        if (Product.isSowing == true)
        {
            creatingFields = false;
            isDry = false;
            Cursor.SetCursor(seedCursor, hotSpot, cursorMode);
            image.sprite = imageTwo;
        }

        if (Input.GetMouseButtonDown(1))
        {
            ClearCursor();
        }

    }


    public void StartTimer()
    {
        if (maizeHarvest >= 1 && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Round(timeRemaining).ToString();
            print(timeRemaining);
            print(maizeHarvest);

        }
        else
        {
            print("Time out");
            timerIsRunning = false;
            timeRemaining = 0;
        }
    }

    public void Close()
    {
        barnEmpty.canvas.SetActive(false);
        errorPanel.SetActive(true);
        print("close");
    }

    public void CreateFields()
    {
        creatingFields = true;
    }

    public void ReturnToNormality()
    {
        creatingFields = false;
        isDry = false;
    }

    public void ClearCursor()
    {
        creatingFields = false;
        Product.isSowing = false;
        isDry = false;

        Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
        image.sprite = imageThree;
    }

    public void WaterLand()
    {

        if (isDry == false)
        {
            Product.isSowing = false;
            isDry = true;
            creatingFields = false;
        }

    }

    public void ClosePanel()
    {
        errorPanel.SetActive(false);

    }

    public int Total()
    {
        totalCropsInBarn = maizeHarvest2 + tomatoesHarvest2 + carrotHarvest2 + beetHarvest2 + bellHarvest2 + cabbageHarvest2 + melonHarvest2;
        return totalCropsInBarn;
    }

    // SELLING SYSTEM
    public void SellMaize()
    {
        if (maizeHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 40;
            maizeHarvest--;
            maizeHarvest2--;
            maizeHarvestText.text = maizeHarvest2.ToString();
            maizeHarvestProfit += 10;
            profit += 10;
            profitText.text = "High Score: " + profit;
            leaderBoard.SubmitScore(profit);
        }
        else if (maizeHarvest == 1 && maizeHarvest2 < 1)
        {
            barnEmpty.ShowMaize();
            return;
        }
    }
    public void SellTomatoes()
    {
        if (tomatoesHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 50;
            tomatoesHarvest--;
            tomatoesHarvest2--;
            tomatoesHarvestText.text = tomatoesHarvest2.ToString();
            tomatoesHarvestProfit += 10;
            profit += 10;
            profitText.text = "High Score: " + profit;
            leaderBoard.SubmitScore(profit);
        }
        else if (tomatoesHarvest == 1 && tomatoesHarvest2 < 1)
        {
            barnEmpty.ShowTomatoes();
            return;
        }
    }
    public void SellCarrot()
    {
        if (carrotHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 60;
            carrotHarvest--;
            carrotHarvest2--;
            carrotHarvestText.text = carrotHarvest2.ToString();
            carrotHarvesProfit += 10;
            profit += 10;
            profitText.text = "High Score: " + profit;
            leaderBoard.SubmitScore(profit);
        }
        else if (carrotHarvest == 1 && carrotHarvest2 < 1)
        {
            barnEmpty.ShowCarrot();
            return;
        }
    }
    public void SellBeet()
    {
        if (beetHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 70;
            beetHarvest--;
            beetHarvest2--;
            beetHarvestText.text = beetHarvest2.ToString();
            beetHarvestProfit += 10;
            profit += 10;
            profitText.text = "High Score: " + profit;
            leaderBoard.SubmitScore(profit);
        }
        else if (beetHarvest == 1 && beetHarvest2 < 1)
        {
            barnEmpty.ShowBeet();
            return;
        }
    }
    public void SellBell()
    {
        if (bellHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 80;
            bellHarvest--;
            bellHarvest2--;
            bellHarvestText.text = bellHarvest2.ToString();
            bellHarvestProfit += 10;
            profit += 10;
            profitText.text = "High Score: " + profit;
            leaderBoard.SubmitScore(profit);
        }
        else if (bellHarvest == 1 && bellHarvest2 < 1)
        {
            barnEmpty.ShowBell();
            return;
        }
    }
    public void SellMelon()
    {
        if (melonHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 90;
            melonHarvest--;
            melonHarvest2--;
            melonHarvestText.text = melonHarvest2.ToString();
            melonHarvestProfit += 10;
            profit += 10;
            profitText.text = "High Score: " + profit;
            leaderBoard.SubmitScore(profit);
        }
        else if (melonHarvest == 1 && melonHarvest2 < 1)
        {
            barnEmpty.ShowMelon();
            return;
        }
    }
    public void SellCabbage()
    {
        if (cabbageHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 100;
            cabbageHarvest--;
            cabbageHarvest2--;
            cabbageHarvestText.text = cabbageHarvest2.ToString();
            cabbageHarvestProfit += 10;
            profit += 10;
            profitText.text = "High Score: " + profit;
            leaderBoard.SubmitScore(profit);
        }
        else if (cabbageHarvest == 1 && cabbageHarvest2 < 1)
        {
            barnEmpty.ShowCabbage();
            return;
        }
    }
}


