using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;
    
    private State _currentState;
    private Player _target;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_startState);
    }

    private void Update()
    {
        var nextState = _currentState.TryGetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State state)
    {
        _currentState = _startState;
        _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter(_target);
    }
}
