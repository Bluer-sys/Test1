using States;
using UnityEngine;
using Zenject;

public class GameRunner : MonoBehaviour
{
    private IGameStateMachine _gameStateMachine;
    
    [Inject] 
    private void Construct(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
    
    private void Awake()
    {
        _gameStateMachine.Enter<BootstrapState>();
    }
}
