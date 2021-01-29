using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] EventSO levelStarted;
    [SerializeField] EventSO levelEnded;

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
