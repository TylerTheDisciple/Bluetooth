using System.IO.Ports;
using TMPro;
using System;
using UnityEngine;

public class SerialPortGet : MonoBehaviour
{
    [Header("FormUnity")]
    public GameObject portDataPanel;
    public TMP_InputField baudRateInputField;
    public TMP_InputField dataBitsInputField;
    public TMP_InputField stopBitsInputField;
    public TMP_InputField sendInputField;
    public TMP_Text receiveText;

    private ChatSerialPort testSerialPort;
    private ChatSerialPort chatSerialPort;
    private TMP_Dropdown comDropdowm;
    private TMP_Dropdown.OptionData optionData;
    private string portName;
    private event Action<string> showMessage;
    private void OnEnable()
    {
        comDropdowm = GetComponentInChildren<TMP_Dropdown>();
        SerialPortSet();
    }

    void Update()
    {
        showMessage?.Invoke(chatSerialPort.Data);
    }

    private void OnApplicationQuit()
    {
        chatSerialPort = null;
        GC.Collect();
    }
    void SerialPortSet()
    {
        string[] ports = SerialPort.GetPortNames();

        foreach (string port in ports)
        {
            optionData = new TMP_Dropdown.OptionData();
            optionData.text = port;
            comDropdowm.options.Add(optionData);
        }
    }

    private void ShowMessageOnText(string str)
    {
        receiveText.text = str;
        //Debug.Log();
    }

    public void OnPortValueChanged()
    {
        portName = comDropdowm.options[comDropdowm.value].text;
    }

    public void ConfirmBtnEvent()
    {
        if (chatSerialPort != null)
        {
            if (chatSerialPort.serialPort.IsOpen)
            {
                Debug.LogWarning("There is a port opening");
            }
        }
        else
        {
            portDataPanel.SetActive(true);
        }
    }

    public void DisconnectedBtnEvent()
    {
        if (chatSerialPort != null)
        {
            showMessage -= ShowMessageOnText;
            chatSerialPort = null;
            GC.Collect();
        }
        else
        {
            Debug.LogWarning("No port is opening");
        }
    }

    public void SendBtnEvent()
    {
        chatSerialPort.SendData(sendInputField.text);
    }

    public void OpenTestPortBtnEvent()
    {
        testSerialPort = new ChatSerialPort("COM2", 9600, 8);
    }

    public void TestPortSendBtnEvent()
    {
        testSerialPort.SendData("111");
    }

    public void PortDataPanelBackBtnEvent()
    {
        portDataPanel.SetActive(false);
    }

    public void PortDataConfirmBtnEvent()
    {
        chatSerialPort = new ChatSerialPort(portName, int.Parse(baudRateInputField.text), int.Parse(dataBitsInputField.text));
        showMessage += ShowMessageOnText;
        portDataPanel.SetActive(false);
        Debug.Log(chatSerialPort.serialPort.IsOpen);
    }
}
