using System;
using Controller;
using Controller.ClientNetWork;
using Model;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IRpcMethod
{
    [Inject]
    private IGameNetwork _network;

    [Inject]
    private IClient _client;

    [SerializeField] private string userName;
    void Start()
    {
        _client.StartClient(userName);
        
        _network.InvokeRPC(nameof(Run), _client);
    }

    private void OnEnable()
    {
        _client.SubscribeToRPC(this);
        
    }

    private void OnDisable()
    {
        _client.UnSubscribeToRPC(this);
    }

    private void Run()
    {
        Debug.Log("Run Run");
    }

    public void RPCMethod(string cmd)
    {
       Debug.Log(cmd + userName);
    }
}
