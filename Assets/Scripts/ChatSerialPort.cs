public class ChatSerialPort : AFunSerialPort
{
    private string data;
    public string Data
    {
        get 
        {
            return data;
        }
    }

    public ChatSerialPort(string portName, int baudRate, int dataBits):base(portName, baudRate, dataBits)
    {
        
    }

    protected override void HandleReceivedData(string data)
    {
        this.data = data;
    }
}
