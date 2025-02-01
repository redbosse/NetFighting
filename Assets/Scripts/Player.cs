using System;
using Controller;
using Controller.ClientNetWork;
using Controller.Hp;
using Model;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IRpcMethod, IGameplayRtc
{
    [Inject]
    private IGameNetwork _network;

    [Inject]
    private IClient _client;
    
    [Inject]
    HpController _hpController;

    [SerializeField] private string userName;
    
    [SerializeField]
    bool rightOfWay = false;
    
    [SerializeField]
    HpBar hpBar;
    
    void Start()
    {
        _client.StartClient(userName);
        _hpController.ResetHp();
    }

    private void OnEnable()
    {
        hpBar.SetHpController(_hpController);
        
        _client.SubscribeToRPC(this);
        
        _hpController.onDeathEvent += OnDeath;
        _hpController.onHpChanged += OnHpChanged;
        
        hpBar.Subscribe();
    }

    private void OnDisable()
    {
        _client.UnSubscribeToRPC(this);
        
        _hpController.onDeathEvent -= OnDeath;
        _hpController.onHpChanged -= OnHpChanged;
        
        hpBar.Unsubscribe();
    }

    void OnHpChanged(int hp)
    {
        
    }

    void OnDeath()
    {
        
    }

    private void Run()
    {
        Debug.Log($"Run Run {name}");
    }

    public void RPCMethod(string cmd)
    {
        if (nameof(Run) == cmd)
        {
            Run();
        }
        if (nameof(OnStartGame) == cmd)
        {
            OnStartGame();
        }
    }

    public void OnStartGame()
    {
        Debug.Log($"OnStartGame {name}");
    }
}
