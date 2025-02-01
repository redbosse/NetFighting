using System;
using System.Collections.Generic;
using System.Linq;
using Controller.ClientNetWork;
using Controller.GamePlay;
using Controller.Hp;
using EditorCools;
using Model;
using UnityEngine;
using Zenject;

namespace Controller.Player
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
        HpBar hpBar;

        [SerializeField]
        private NetworkPlayer _enemy;

        [SerializeField] private Ability _ability;

        [SerializeField] private AudioSource _attackSound;
        [SerializeField] private AudioSource _damageSound;
        [SerializeField] private AudioSource _deathSound;
        
        public event Action OnDamageEvent;
        public event Action OnDeathEvent;
        public event Action OnAttackedEvent; 
        
        private const string RestartToken = "OnRestartGame";
    
        void Start()
        {
            _client.StartClient(userName);
            _hpController.ResetHp();
        }

        public void Attack()
        {
            var ab = new AttackAbillity();
            
            _ability.StartAbility(ab);
        }

        private void OnEnable()
        {
            hpBar.SetHpController(_hpController);
        
            _client.SubscribeToRPC(this);
        
            _hpController.onDeathEvent += OnDeath;
            _hpController.onHpChanged += OnHpChanged;
            _ability.AbilityAction += OnAbilityAction;
            _ability.OnEndAbilityAction += OnAbilityEnd;
        
            hpBar.Subscribe();
        }

        private void OnDisable()
        {
            _client.UnSubscribeToRPC(this);
        
            _hpController.onDeathEvent -= OnDeath;
            _hpController.onHpChanged -= OnHpChanged;
            _ability.AbilityAction -= OnAbilityAction;
            _ability.OnEndAbilityAction -= OnAbilityEnd;
        
            hpBar.Unsubscribe();
        }

        void OnHpChanged(int hp)
        {
        
        }

        void OnDeath()
        {
            Debug.Log("OnDeath");
            
            OnDeathEvent?.Invoke();
            
            _deathSound.Play();
            
            _network.InvokeRPC(RestartToken,_client,RpcType.ClientToServer);
        }

        void OnRestartGame()
        {
            _ability.ClearAbility();
            
            OnStartGame();
        }
        
        public void RPCMethod(string cmd)
        {
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
            _hpController.ResetHp();
        }

        void OnAbilityAction(IAbility ability)
        {
            
            _enemy.Damage(ability.NegativeEffect().GetDamage());
            
            _attackSound.Play();
            
            OnAttackedEvent?.Invoke();
        }
        void OnAbilityEnd()
        {
            _enemy.Attack();
            _network.InvokeRPC("ChangeRole",_client,RpcType.ClientToServer);
        }

        
        public void Damage(int damage)
        {
            OnDamageEvent?.Invoke();
            
            _hpController.Damage(damage);
            
            _damageSound.Play();
            
            _network.InvokeRPC("SyncDamage",_client,RpcType.ClientToServer);
        }
    }
}
