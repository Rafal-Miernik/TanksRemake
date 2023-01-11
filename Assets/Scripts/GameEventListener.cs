using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{

    [SerializeField] protected GameEvent _gameEvent;
    [SerializeField] protected UnityEvent _unityEvent;

    private void Awake()
    {

        if (_gameEvent != null)
        {
            _gameEvent.Register(this);
        }

    }

    private void OnDestroy()
    {
        if (_gameEvent != null)
        {
            _gameEvent.Deregister(this);
        }
    }


    public virtual void RaiseEvent()
    {
        _unityEvent.Invoke();
    }
}
