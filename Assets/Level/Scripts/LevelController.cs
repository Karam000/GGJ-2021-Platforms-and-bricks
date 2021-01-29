using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] EventListenerSO levelStarted;
    [SerializeField] EventListenerSO levelEnded;

    [SerializeField] PathController PathController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnLevelStatrted()
    {
        PathController.HidePath();
    }

    public void OnLevelEnded()
    {
        PathController.ShowPath();
    }
}
