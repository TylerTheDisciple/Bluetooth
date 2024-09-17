using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Linq;

public class BluetoothRead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BluetoothCommunication()
    {
        BluetoothClient client = new BluetoothClient();
        BluetoothRadio radio = BluetoothRadio.Default; //拿到本机的蓝牙设备
        radio.Mode = RadioMode.Connectable;

        var deviceInfos = client.DiscoverDevices().ToList();
        foreach (var item in deviceInfos)
        {
            Debug.Log(item.DeviceName);
            Debug.Log(item.DeviceAddress);
        }
    }
}
