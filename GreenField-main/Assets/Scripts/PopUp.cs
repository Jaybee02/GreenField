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
            PopUp.Instance.SetTitle("About Maize").SetMessage("Maize plant").Show();
        }

        public void ShowTomatoes()
        {
            PopUp.Instance.SetTitle("About Tomatoes").SetMessage("Tomatoes plant").Show();
        }

        public void ShowCarrot()
        {
            PopUp.Instance.SetTitle("About Carrot").SetMessage("Tomatoes plant").Show();
        }

        public void ShowBeet()
        {
            PopUp.Instance.SetTitle("About Beetroot").SetMessage("Tomatoes plant").Show();
        }

        public void ShowBell()
        {
            PopUp.Instance.SetTitle("About Bell Pepper").SetMessage("Tomatoes plant").Show();
        }

        public void ShowWaterMelon()
        {
            PopUp.Instance.SetTitle("About Water Melon").SetMessage("Tomatoes plant").Show();
        }

        public void ShowCabbage()
        {
            PopUp.Instance.SetTitle("About Cabbage").SetMessage("Tomatoes plant").Show();
        }

    }

}