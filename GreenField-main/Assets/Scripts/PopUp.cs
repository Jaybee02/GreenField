using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.PopUp
{
    public class PopUpUI
    {
        public string Title = "Title";
        public string Message = "About Agriculture";
    }

    public class PopUp : MonoBehaviour
    {

        [SerializeField] Text titleText;
        [SerializeField] Text messageText;
        [SerializeField] Button closeButton;
        public GameObject canvas;

        PopUpUI popUpUI = new PopUpUI();

        public static PopUp Instance;
        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;

            // close event listener
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(Hide);
        }

        // set Title
        public PopUp SetTitle(string title)
        {
            popUpUI.Title = title;
            return Instance;
        }

        // set Message
        public PopUp SetMessage(string message)
        {
            popUpUI.Message = message;
            return Instance;
        }

        // show popup
        public void Show()
        {
            titleText.text = popUpUI.Title;
            messageText.text = popUpUI.Message;

            canvas.SetActive(true);
        }

        //  hide popup
        public void Hide()
        {
            canvas.SetActive(false);

            // reset popup UI
            popUpUI = new PopUpUI();
        }

        public void ShowMaize()
        {
            PopUp.Instance.SetTitle("Interesting Facts About Maize").SetMessage("Maize's scientific name is 'Zea mays' however in Africa, it is known as mealies.\n According to FAO(2017), Nigeria is the top producer of maize followed by Tanzania.\nMaize is main the staple food in South Africa and the most important cereal in sub-Saharan Africa.\nIt is worthy of note that maize is a vegetable, fruit, and grain with a cup containing 177 calories. Its stalks can grow as tall as thirteen feet high.\nIt is an ingredient in fireworks.").Show();
        }

        public void ShowTomatoes()
        {
            PopUp.Instance.SetTitle("Interesting Facts About Tomatoes").SetMessage("This crop cultivated and consumed worldwide has a scientific name of Solanum lycopersicum L.\nTomatoes production improves the livelihoods of  small-scale producers as it creates jobs and serves as a source of income for both rural and urban dwellers.\nThere are over 10 thousand varieties of tomato with different colours.\nTomatoes help to prevent cancer, regulate blood pressure and enhance brain power. This vegetable is cultivated and consumed worldwide. ").Show();
        }

        public void ShowCarrot()
        {
            PopUp.Instance.SetTitle("Interesting Facts About Carrot").SetMessage("The first cultivated carrots recorded in history is from Afghanistan in 900AD.\nCarrots were originally white or purple. Then a yellow carrot appeared through mutation and the familiar orange carrot was bred from it.\nThe carrot is a root vegetable, usually orange in color, though purple, red, black , white, and yellow varieties exist.\nCarrot are made up of 88 percent water and it takes around 4 months for carrots to finish growing.\nYou can take carrot to lower blood Cholesterol and improve vision?").Show();
        }

        public void ShowBeet()
        {
            PopUp.Instance.SetTitle("Interesting Facts About Beetroots").SetMessage("The ancestor of the cultivated beet is the wild sea beet, which grew in Africa, the Middle East, and Europe.\nBeets have the highest sugar content of any vegetable and it is made up of 88% water. The entire beet is edible from the top of the greens to the bottom of the root.\nBeet juice can indicate the acidity of a solution. If a solution turns pink when beet juice is added, it is an acid. If it turns yellow, the solution is alkaline.\nIn Nigeria, beet plants are being grown in Plateau State.").Show();
        }

        public void ShowBell()
        {
            PopUp.Instance.SetTitle("Interesting Facts About Bell Peppers").SetMessage("Bell peppers, scientifically known as 'Capsicum annum' are rich sources of antioxidants and vitamins.\nThey were named by Christopher Columbus and Spanish explorers who were searching for peppercorn plants to produce black pepper.\nThe pepper comes in red, green, yellow, orange and purple colours. Red bell pepper which are sweater than green bell pepper are not grown seasonally so they can be enjoyed year-round.\nThe intake of green bell pepper cures rashes, acne, blemishes and many other skin infections with its phyto nutrients.").Show();
        }

        public void ShowWaterMelon()
        {
            PopUp.Instance.SetTitle("Interesting Facts About Watermelon").SetMessage("Watermelon originated in the Kalahari Desert in Africa with the first seen in Egypt 5,000 years ago.\nThe botanical name of this fruit is 'Citrullus Lanatus'. Watermelon is 92% water. It contains 46 calories and can be used to fight against diseases.\nEvery part of watermelon is edible. Approximately 300 types of watermelon exist, though only about 50 are eaten regularly. The fruit comes in red, golden yellow-orange and pale green colours.\nIt takes about 90 days for the fruit to grow.").Show();
        }

        public void ShowCabbage()
        {
            PopUp.Instance.SetTitle("Interesting Facts About Cabbage").SetMessage("This cold-weather veggie with over 400 varieties has a scientific name as 'Cleome gynandra' and is the oldest cultivated vegetable on record grown in China more than 6000 years ago.\nThe most popular types are green, red, and Savoy varieties. It was used as medicine to cure headache, acne, baldness and to promote hair, skin and nails.\nThe red cabbage makes an excellent all natural dye for food and fabric.\nThis vegetable is loaded with a lot of vitamins and minerals which makes the body (and heart) healthy.").Show();
        }

    }

}