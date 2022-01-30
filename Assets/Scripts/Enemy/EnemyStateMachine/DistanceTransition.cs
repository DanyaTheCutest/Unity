using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _spredRange;
    
    private void Start()
    {
        _transitionRange += Random.Range(-_spredRange, _spredRange);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) <= _transitionRange)
            NeedTransit = true;
    }
}
