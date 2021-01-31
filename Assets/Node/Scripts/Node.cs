using SO.Events;
using System;
using UnityEngine;
using SO;

public class Node : MonoBehaviour
{
    [Serializable]
    public enum NodeState
    {
        Rotate,
        Explode
    }

    [SerializeField] EventSO onCurrentNumberChange; 
    public int NodeRequiredNumber;
    public PlatformBehavior NodeCenter;
    public float NodeRotationSpeed;
    public NodeState currentState;
    VariableSO<int> platformCurrentNumber;

    void Awake()
    {
        currentState = NodeState.Rotate;
        platformCurrentNumber = (VariableSO<int>)onCurrentNumberChange.Value;
        //platformCurrentNumber.Value = NodeRequiredNumber;
    }
    public void CheckForLevelStateUpdate()
    {
        if (platformCurrentNumber.Value == NodeRequiredNumber && CharacterCollision.PlayercurrentPlatform == NodeCenter)
        {
            currentState = NodeState.Explode;
            platformCurrentNumber.Value = 0;
        }
    }
}
