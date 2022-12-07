using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GoldSystem : MonoBehaviour
{
    public int gold;

    public Text goldText;
    public int totalCropsInBarn;

    public OnClickEvents onClick;
    public FarmGrid grid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Wallet: ₦" + gold;

        if (gold == 0 && grid.Total() == 0)
        {
            onClick.GameOver();
        }
    }
}
