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
        if (platformCurrentNumber.Value == NodeRequiredNumber && Player.PlayercurrentPlatform == NodeCenter)
        {
            currentState = NodeState.Explode;
            Player.canChangePlatform = true;
            if(Player.PlayercurrentPlatform.isLevelLastPlatform)
            {
                LevelController.Instance.levelEnded.Raise();
            }
            //platformCurrentNumber.Value = 0;
        }
        else if(Player.PlayercurrentPlatform == NodeCenter)
        {
            Player.canChangePlatform = false;
        }
        if (platformCurrentNumber.Value < NodeRequiredNumber && Player.PlayercurrentPlatform == NodeCenter)
        {
            Player.canChangePlatform = true;
        }
    }
}
