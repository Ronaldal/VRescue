using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class RotateCube : MonoBehaviour {
    SerialPort stream = new SerialPort("COM3", 115200);
    private string strReceived = "";
    private float qw, qx, qy, qz;
    private bool isNewDataAvailable = false;
    private Thread serialThread;

    void Start()
    {
        try
        {
            stream.Open();
            Debug.Log("stream.Open();");
            serialThread = new Thread(ReadSerialData);
            serialThread.Start();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Serial Port Error: " + e.Message);
        }
    }

    void ReadSerialData()
    {
        Debug.Log("In thread: ");
        while (stream.IsOpen)
        {
            try
            {
 

                string rawData = stream.ReadLine();
                string[] strData = rawData.Split(',');
                if (strData.Length == 5) // Ensure correct data length
                {

                    qw = float.Parse(strData[0]);
                    qx = float.Parse(strData[1]);
                    qy = float.Parse(strData[2]);
                    qz = float.Parse(strData[3]);

                    isNewDataAvailable = true; // Mark data as ready

                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Serial Read Error: " + e.Message);

            }
        }
    }

    void Update()
    {
        if (isNewDataAvailable)
        {
            transform.rotation = new Quaternion(-qy, -qz, qx, qw);
            isNewDataAvailable = false; // Reset flag after applying data
        }
    }

    void OnApplicationQuit()
    {
        if (serialThread != null) serialThread.Abort(); // Stop the thread on exit
        if (stream.IsOpen) stream.Close(); // Close the serial port
    }
}
