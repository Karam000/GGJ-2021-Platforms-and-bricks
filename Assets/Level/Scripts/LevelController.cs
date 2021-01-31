using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] public EventSO levelStarted;
    [SerializeField] public EventSO levelEnded;

    //[SerializeField] PathController PathController;
    [SerializeField] List<Node> levelNodes;
    public static LevelController Instance { get; private set; }
    Coroutine levelend_Coroutine;
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
        //PathController.HidePath();
        Debug.Log("hide path");

    }

    public void OnLevelEnded()
    {
        //PathController.ShowPath();
        Debug.Log("show path");
        levelend_Coroutine =  StartCoroutine(levelend());
    }

    IEnumerator levelend()
    {
        yield return new WaitUntil(() => Player.goingToPlatform == true);
        List<Node> nodestoremove = new List<Node>();
        foreach (var node in levelNodes)
        {
            if (node.NodeCenter.finished)
            {
                //levelNodes.Remove(node);
                nodestoremove.Add(node);
                Destroy(node.gameObject);
            }
        }
        foreach (var node in nodestoremove)
        {
            levelNodes.Remove(node);
        }

        StopCoroutine(levelend_Coroutine);
    }
}
