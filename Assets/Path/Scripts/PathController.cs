using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

    [SerializeField] GameObject pathUnitPrefab;

    List<Transform> pathUnits = new List<Transform>();
    //List<GameObject> instantiatedPathUnits = new List<GameObject>();
    GameObject Instantiated = new GameObject();

    bool firstGizmos = true;
    bool runMode = false;
    void Start()
    {
        runMode = true;
        Transform[] temp = this.transform.GetComponentsInChildren<Transform>();
        for (int i = 1; i < temp.Length; i++)
        {
            pathUnits.Add(temp[i]);
        }
    }

    void Update()
    {
    }

    public void ShowPath()
    {
        Instantiated = Instantiate(pathUnitPrefab);
        //foreach (Transform pathunit in pathUnits)
        //{
        //    instantiatedPathUnits.Add(Instantiate(pathUnitPrefab, pathunit.position, pathunit.rotation, pathunit));
        //}
    }

    public void HidePath()
    {
        Destroy(Instantiated);
        //foreach (var pathunit in instantiatedPathUnits)
        //{
        //    if (pathunit != null)
        //        Destroy(pathunit.gameObject);
        //}
    }

    //private void OnDrawGizmos()
    //{

    //    if (!runMode)
    //    {
    //        if (firstGizmos || this.transform.childCount > pathUnits.Count)
    //        {
    //            firstGizmos = false;
    //            Transform[] temp = this.transform.GetComponentsInChildren<Transform>();
    //            for (int i = 1; i < temp.Length; i++)
    //            {
    //                pathUnits.Add(temp[i]);
    //            }
    //        }

    //        if (pathUnits.Count > 0)
    //        {
    //            //Gizmos.color = Color.green;
    //            //for (int i = 0; i < pathUnits.Count - 1; i++)
    //            //{
    //            //    //Gizmos.DrawLine(pathUnits[i].position, pathUnits[i + 1].position);
    //            //}
}
