/// <summary>
/// Server Script.
/// Created By 蓝鸥3G 2014.08.23
/// https://www.cnblogs.com/daxiaxiaohao/p/4402063.html
/// </summary>
/// 
/// 
using UnityEngine;
using System.Collections;
using System;
;

public class ServerScript : MonoBehaviour {

    private string receive_str;
    IocpServer.IoServer server;

    private const int BUFF_SIZE = 1024;
    private const int PLAYER_MAX_COUNT = 100;
    byte[] ReceiveBuffer = new byte[BUFF_SIZE];
    
    // Use this for initialization
    void Start()
    {
        //初始化服务器
        server = new IocpServer.IoServer(PLAYER_MAX_COUNT, BUFF_SIZE, OnReceive);
    }

    void OnReceive(byte[] content, int size)
    {
        Array.Copy(content, 0, ReceiveBuffer, 0, size);        
        receive_str = System.Text.Encoding.Default.GetString(content);
    }

    void OnGUI()
    {
        if (receive_str != null)
        {
            var style = GUILayout.Width(600);
            GUILayout.Label (receive_str, style);
        }
    }
}