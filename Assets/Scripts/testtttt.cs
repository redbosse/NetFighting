using Controller;
using Model;
using UnityEngine;
using Zenject;

public class testtttt : MonoBehaviour
{
    [Inject]
    private IGameNetwork Network;

    [Inject]
    private IClient _client;

    [SerializeField] private string userName;
    void Start()
    {
      
        
        _client.StartClient(userName);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
