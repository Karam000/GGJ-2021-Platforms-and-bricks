using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;
using UnityEngine.UI;
using Cinemachine;
public class LevelController : MonoBehaviour
{
    [SerializeField] public EventSO levelStarted;
    [SerializeField] public EventSO levelEnded;

    [SerializeField] Canvas GemsCanvas;
    [SerializeField] Canvas GameplayCanvas;
    [SerializeField] Canvas LoseCanvas;
    [SerializeField] Canvas WinCanvas;


    [SerializeField] PathController PathController;
    //[SerializeField] List<Node> levelNodes;
    public static LevelController Instance { get; private set; }
    Coroutine levelend_Coroutine;

    Coroutine win_Coroutine;
    [SerializeField] CinemachineVirtualCamera winCam;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        levelStarted.Raise();
    }

    void Update()
    {
        
    }

    public void OnLevelStatrted()
    {
        PathController.HidePath();
        Debug.Log("hide path");
        GemsCanvas.gameObject.SetActive(true);
        GemsCanvas.gameObject.SetActive(true);

    }

    public void OnLevelEnded()
    {
        PathController.ShowPath();
        Debug.Log("show path");

        Win();
        //levelend_Coroutine =  StartCoroutine(levelend());
    }

    public void changeScene()
    {
        SceneController.NextSceneIndex++;
        SceneController.ChangeScene();
    }

    public void Lose()
    {
        GemsCanvas.gameObject.SetActive(false);
        GemsCanvas.gameObject.SetActive(false);
        LoseCanvas.gameObject.SetActive(true);
        WinCanvas.gameObject.SetActive(false);

    }

    public void Win()
    {
        winCam.gameObject.SetActive(true);
        win_Coroutine = StartCoroutine(win());
    }

    IEnumerator win()
    {
        yield return new WaitForSeconds(5);
        GemsCanvas.gameObject.SetActive(false);
        GemsCanvas.gameObject.SetActive(false);
        WinCanvas.gameObject.SetActive(true);
        LoseCanvas.gameObject.SetActive(false);
        StopCoroutine(win_Coroutine);
    }
    //IEnumerator levelend()
    //{
    //    yield return new WaitUntil(() => Player.goingToPlatform == true);
    //    List<Node> nodestoremove = new List<Node>();
    //    foreach (var node in levelNodes)
    //    {
    //        if (node.NodeCenter.finished)
    //        {
    //            //levelNodes.Remove(node);
    //            nodestoremove.Add(node);
    //            Destroy(node.gameObject);
    //        }
    //    }
    //    foreach (var node in nodestoremove)
    //    {
    //        levelNodes.Remove(node);
    //    }

    //    StopCoroutine(levelend_Coroutine);
    //}
}
