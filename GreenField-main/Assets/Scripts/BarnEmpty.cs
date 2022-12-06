using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.BarnEmpty
{
    public class BarnEmptyUI
    {
        public string Title = "Barn is empty!";
        public string Message = "No crop in barn";
    }

    public class BarnEmpty : MonoBehaviour
    {

        [SerializeField] Text titleText;
        [SerializeField] Text messageText;
        [SerializeField] Button closeButton;
        public GameObject canvas;
        public GameObject canvasTwo;

        BarnEmptyUI barnEmptyUI = new BarnEmptyUI();

        public static BarnEmpty Instance;
        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;

            // close event listener
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(Hide);

        }

        // set Title
        public BarnEmpty SetTitle(string title)
        {
            barnEmptyUI.Title = title;
            return Instance;
        }

        // set Message
        public BarnEmpty SetMessage(string message)
        {
            barnEmptyUI.Message = message;
            return Instance;
        }

        // show BarnEmpty
        public void Show()
        {
            titleText.text = barnEmptyUI.Title;
            messageText.text = barnEmptyUI.Message;

            canvas.SetActive(true);
            canvasTwo.SetActive(false);
        }

        //  hide BarnEmpty
        public void Hide()
        {
            canvas.SetActive(false);
            canvasTwo.SetActive(true);

            // reset BarnEmpty UI
            barnEmptyUI = new BarnEmptyUI();
        }

        public void Close()
        {
            canvas.SetActive(false);
            print("close");
        }

        public void ShowMaize()
        {
            BarnEmpty.Instance.SetTitle("Maize barn is empty!").SetMessage("Plant and harvest maize to have maize in barn.").Show();
        }

        public void ShowTomatoes()
        {
            BarnEmpty.Instance.SetTitle("Tomatoes barn is empty!").SetMessage("Plant and harvest tomatoes to have tomatoes in barn.").Show();
        }

        public void ShowCarrot()
        {
            BarnEmpty.Instance.SetTitle("Carrot barn is empty!").SetMessage("Plant and harvest carrot to have carrot in barn.").Show();
        }

        public void ShowBeet()
        {
            BarnEmpty.Instance.SetTitle("Beetroot barn is empty!").SetMessage("Plant and harvest beetroot to have beetroot in barn.").Show();
        }

        public void ShowBell()
        {
            BarnEmpty.Instance.SetTitle("Bell pepper barn is empty!").SetMessage("Plant and harvest bell pepper to have bell pepper in barn.").Show();
        }

        public void ShowMelon()
        {
            BarnEmpty.Instance.SetTitle("Watermelon barn is empty!").SetMessage("Plant and harvest water melon to have water melon in barn.").Show();
        }

        public void ShowCabbage()
        {
            BarnEmpty.Instance.SetTitle("Cabbage barn is empty!").SetMessage("Plant and harvest cabbage to have cabbage in barn.").Show();
        }

    }

}