using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

public class ConnectionManager : MonoBehaviour
{
    public static ConnectionManager instance;

    public UdpClient socket;
    public IPEndPoint endPoint;

    public string id;
    public int port = 24200;
    public string address = "192.168.86.55";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exits");
            Destroy(this);
        }
    }

    private void Start() {
        id = Guid.NewGuid().ToString();
        endPoint = new IPEndPoint(IPAddress.Parse(address), port);

        socket = new UdpClient();
        socket.Connect(endPoint);
        socket.BeginReceive(ReceiveCallback, null);
    }

    private void ReceiveCallback(IAsyncResult _result)
    {
        byte[] _data = socket.EndReceive(_result, ref endPoint);
        socket.BeginReceive(ReceiveCallback, null);

        OnMessage(System.Text.Encoding.Default.GetString(_data));
    }

    public void SendData(string message)
    {
        try
        {
            //Debug.Log($"Sending: {message}");
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            socket.Send(sendBytes, sendBytes.Length);
        }
        catch (Exception _ex)
        {
            Debug.Log($"Error sending data to server via UDP: {_ex}");
        }
    }

    public void OnMessage(string message)
    {
        GameController.instance.worldData = JsonUtility.FromJson<WorldData>(message);
    }
}

[System.Serializable]
public class WorldData
{
    public string type;
    public PlayerData[] clients;
}