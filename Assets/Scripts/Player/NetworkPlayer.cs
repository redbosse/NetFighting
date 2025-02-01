using Controller.ClientNetWork;
using Controller.Hp;
using EditorCools;
using Model;
using UnityEngine;
using Zenject;

namespace Player
{
    public class NetworkPlayer : MonoBehaviour, IRpcMethod, IGameplayRtc
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
    
        private const string RestartToken = "OnRestartGame";
    
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
            _network.InvokeRPC(RestartToken,_client,RpcType.ClientToServer);
        }

        void OnRestartGame()
        {
            Debug.Log("OnRestartGame");
        
            _hpController.ResetHp();
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
            if (nameof(OnRestartGame) == cmd)
            {
                OnRestartGame();
            }

       
        }

        public void OnStartGame()
        {
            Debug.Log($"OnStartGame {name}");
        }

        [Button]
        public void Damage()
        {
            _hpController.Damage(10);
        }
    }
}
