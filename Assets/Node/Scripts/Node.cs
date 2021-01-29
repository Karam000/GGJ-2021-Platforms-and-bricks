using SO.Events;
using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    [Serializable]
    public enum NodeState
    {
        Rotate,
        Explode
    }

    public int NodeRequiredNumber;
    public Transform NodeCenter;
    public float NodeRotationSpeed;
    public NodeState currentState;

    private void Start()
    {
        currentState = NodeState.Rotate;
    }
    public void CheckForLevelStateUpdate()
    {

    }
}
