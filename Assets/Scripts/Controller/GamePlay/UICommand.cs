using Controller.ClientNetWork;
using Controller.Player;
using EditorCools;
using UnityEngine;
using Zenject;

namespace Controller.GamePlay
{
    public class UICommand : MonoBehaviour
    { 
        [Inject]
        IGameNetwork _network;

        [SerializeField] 
        private NetworkPlayer _player;
        
        [SerializeField] 
        private NetworkPlayer _enemy;
        
        private const string RestartToken = "OnRestartGame";
        
        [Button]
        public void ResetGame()
        {
            _network.InvokeRPC(RestartToken,RpcType.AnonimysToServer);
        }

        [Button]
        public void Attack()
        {
            _player.Attack();
            
        }
    }
}