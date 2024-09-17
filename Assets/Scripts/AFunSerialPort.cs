using System;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public abstract class AFunSerialPort
{
    public string portName;
    public int baudRate;
    public int dataBits;

    private Parity parity = Parity.None;
    private StopBits stopBits = StopBits.One;
    private Handshake handshake = Handshake.None;
    private int readTimeOut = 1000;
    public SerialPort serialPort;
    private Thread serialThread;
    private bool isRunning = false;
    private readonly object lockObject = new object(); //�����߳�ͬ��

    public AFunSerialPort(string portName, int baudRate, int dataBits)
    {
        this.portName = portName;
        this.baudRate = baudRate;
        this.dataBits = dataBits;
        try
        {
            serialPort = new SerialPort(this.portName, this.baudRate, parity, this.dataBits, stopBits);
            serialPort.Handshake = handshake;
            serialPort.ReadTimeout = readTimeOut;
            serialPort.Open();
            isRunning = true;
            serialThread = new Thread(ReadSerialLine);
            serialThread.Start();
        }
        catch(Exception e)
        {
            Debug.LogError("Failed to create or open serial port\n" + e.Message);
        }
    }

    ~AFunSerialPort()
    {
        //ֹͣ�̲߳��رմ���
        isRunning = false;
        if (serialThread != null && serialThread.IsAlive)
        {
            serialThread.Join();//�ȴ��߳̽���
        }

        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }

    void ReadSerialLine()
    {
        while (isRunning && serialPort != null && serialPort.IsOpen)
        {
            try
            {
                if (serialPort.BytesToRead > 0)
                {
                    string message = serialPort.ReadLine();
                    Debug.Log(serialPort.PortName + "Receive from serial:" + message);
                    HandleReceivedData(message); //���ó��󷽷����������м̳�ʹ��
                }
            }
            catch (TimeoutException)
            {
                //���ӳ�ʱ
            }
            catch (Exception e)
            {
                Debug.LogError("Error reading from serial port" + e.Message);
                break;
            }
        }
    }

    public void SendData(string data)
    {
        lock (lockObject)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.WriteLine(data);
                }
                catch (Exception e)
                {
                    Debug.LogError("Error writing to serial port: " + e.Message);
                }
            }
            else
            {
                Debug.LogWarning("Serial port is not open.");
            }
        }
    }
    //���󷽷�������̳�ʹ��
    protected abstract void HandleReceivedData(string data);
}
