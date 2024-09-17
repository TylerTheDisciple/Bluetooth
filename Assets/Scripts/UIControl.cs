using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class UIControl : MonoBehaviour
{
    [Header("Panel")]
    public GameObject firstPanel;
    public GameObject secondPanel;
    public GameObject optionPanel;
    public GameObject portPanel;
    public GameObject bluetoothPanel;
    public GameObject portDataPanel;
    public GameObject mainPanel;
    public GameObject mainOptionPanel;
    public GameObject cloudPanel;
    public GameObject compensatePanel;
    public GameObject bodyPanel;
    public GameObject checkPanel;
    public GameObject oneKeyPanel;
    [Header("Sprite")]
    public Sprite OFOn;
    public Sprite OFOff;
    public Sprite mainPanelBackFirst;
    public Sprite mainPanelBackSecond;
    [Header("InputField")]
    public TMP_InputField userInputField;
    public TMP_InputField backInputField;
    public TMP_InputField forntInputField;
    public TMP_InputField heightInputField;
    public TMP_InputField tilitInputField;

    private bool optionPanelState = false;
    private bool mainOptionPanelState = false;

    private GameObject nowPanel;

    private string fileName = "SavedCSV";
    public GameObject NowPanel 
    {
        get 
        {
            return nowPanel; 
        }
        set
        {
            nowPanel = value;
        }
    }

    void Start()
    {
        nowPanel = firstPanel;
    }

    void Update()
    {

    }

    IEnumerator SecondPanelDelay()
    {
        yield return new WaitForSeconds(5);
        secondPanel.SetActive(false);
    }

    public void OptionBtnEvent()
    {
        optionPanelState = !optionPanelState;
        optionPanel.SetActive(optionPanelState);
    }

    public void MainOptionBtnEvent()
    {
        mainOptionPanelState = !mainOptionPanelState;
        mainOptionPanel.SetActive(mainOptionPanelState);

    }

    public void PortBtnEvent()
    {
        nowPanel.SetActive(false);
        portPanel.SetActive(true);
        nowPanel = portPanel;

        optionPanel.SetActive(false);
        optionPanelState = false;
    }

    public void ReturnBtnEvent()
    {
        nowPanel.SetActive(false);
        secondPanel.SetActive(true);
        nowPanel = secondPanel;

        optionPanel.SetActive(false);
        optionPanelState = false;
    }

    public void MainReturnBtnEvent()
    {
        mainPanel.SetActive(false);
        secondPanel.SetActive(true);
        nowPanel = secondPanel;

        mainOptionPanel.SetActive(false);
        mainOptionPanelState = false;
    }

    public void AfterThirdReturnBtnEvent()
    {
        nowPanel.SetActive(false);
        mainPanel.SetActive(true);
        nowPanel = mainPanel;

        mainOptionPanel.SetActive(false);
        mainOptionPanelState = false;
    }

    public void BluetoothBtnEvent()
    {
        nowPanel.SetActive(false);
        bluetoothPanel.SetActive(true);
        nowPanel = bluetoothPanel;

        optionPanel.SetActive(false);
        optionPanelState = false;
    }

    public void MainBtnEvent()
    {
        secondPanel.SetActive(false);
        mainPanel.SetActive(true);
        nowPanel = mainPanel;
    }

    public void OFBtnEvent(GameObject gameObject)
    {
        Image image = gameObject.GetComponent<Image>();
        if (image.sprite == OFOff)
        {
            image.sprite = OFOn;
        }
        else if (image.sprite == OFOn)
        {
            image.sprite = OFOff;
        }
    }

    public void IsOrNoPeopleBtnEvent()
    {
        Image image = mainPanel.GetComponent<Image>();
        if (image.sprite == mainPanelBackFirst)
        {
            image.sprite = mainPanelBackSecond;
        }
        else if (image.sprite == mainPanelBackSecond)
        {
            image.sprite = mainPanelBackFirst;
        }
    }

    public void CloudBtnEvent()
    {
        nowPanel.SetActive(false);
        cloudPanel.SetActive(true);
        nowPanel = cloudPanel;

        mainOptionPanel.SetActive(false);
        mainOptionPanelState = false;
    }

    public void CompensateBtnEvent()
    {
        nowPanel.SetActive(false);
        compensatePanel.SetActive(true);
        nowPanel = compensatePanel;

        mainOptionPanel.SetActive(false);
        mainOptionPanelState = false;
    }

    public void SaveBtnEvent()
    {
        string filePath = Application.streamingAssetsPath + "/" +  fileName + ".csv";
        if(!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.WriteLine("User,Back,Fornt,Height,Tilit");
        streamWriter.WriteLine($"{userInputField.text},{backInputField.text},{forntInputField.text},{heightInputField.text},{tilitInputField.text}");
        streamWriter.Flush();
        streamWriter.Close();
    }

    public void LoadBtnEvent()
    {
        StreamReader streamReader = File.OpenText(Application.streamingAssetsPath + "/" + fileName + ".csv");
        if (streamReader == null)
        {
            Debug.LogWarning("there is no file exits");
        }
        else
        {
            string[] data = streamReader.ReadToEnd().Split(new char[] { '\n' });
            string[] row = data[1].Split(new char[] { ',' });
            userInputField.text = row[0];
            backInputField.text = row[1];
            forntInputField.text = row[2];
            heightInputField.text = row[3];
            tilitInputField.text = row[4];
        }
    }

    public void DeleteButton()
    {
        File.Delete(Application.streamingAssetsPath + "/" + fileName + ".csv");
    }

    public void BodyBtnEvent()
    {
        nowPanel.SetActive(false);
        bodyPanel.SetActive(true);
        nowPanel = bodyPanel;

        mainOptionPanel.SetActive(false);
        mainOptionPanelState = false;
    }

    public void CheckBtnEvent()
    {
        nowPanel.SetActive(false);
        checkPanel.SetActive(true);
        nowPanel = checkPanel;

        mainOptionPanel.SetActive(false);
        mainOptionPanelState = false;
    }

    public void OneKeyBtnEvent()
    {
        nowPanel.SetActive(false);
        oneKeyPanel.SetActive(true);
        nowPanel = oneKeyPanel;

        mainOptionPanel.SetActive(false);
        mainOptionPanelState = false;
    }
}