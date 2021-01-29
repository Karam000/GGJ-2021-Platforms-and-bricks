using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

    [SerializeField] GameObject pathUnitPrefab;

    List<Transform> pathUnits = new List<Transform>();

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
        foreach (Transform pathunit in pathUnits)
        {
            Instantiate(pathUnitPrefab, pathunit.position, pathunit.rotation, pathunit);
        }
    }

    public void HidePath()
    {

    }

    private void OnDrawGizmos()
    {

        if (!runMode)
        {
            if (firstGizmos)
            {
                firstGizmos = false;
                Transform[] temp = this.transform.GetComponentsInChildren<Transform>();
                for (int i = 1; i < temp.Length; i++)
                {
                    pathUnits.Add(temp[i]);
                }
            } 
        }

        if (pathUnits.Count > 0)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < pathUnits.Count - 1; i++)
            {
                    Gizmos.DrawLine(pathUnits[i].position, pathUnits[i + 1].position);
            }

            Gizmos.color = Color.red;
            for (int i = 0; i < pathUnits.Count; i++)
            {
                    Gizmos.DrawSphere(pathUnits[i].position,0.05f);
            }
        }
    }

}
