using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] public EventSO levelStarted;
    [SerializeField] public EventSO levelEnded;

    [SerializeField] PathController PathController;
    public static LevelController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
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
