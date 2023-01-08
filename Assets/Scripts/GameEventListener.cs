using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{

    [SerializeField] protected GameEvent gameEvent;
    [SerializeField] protected UnityEvent unityEvent;

    private void OnEnable()
    {
        gameEvent.Register(this);
    }
    private void OnDisable()
    {
        gameEvent.Deregister(this);
    }

    public virtual void RaiseEvent()
    {
        unityEvent.Invoke();
    }
}
