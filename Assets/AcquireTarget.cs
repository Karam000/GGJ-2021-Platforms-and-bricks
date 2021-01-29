using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireTarget : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    Vector3 currentTarget;
    private void Start()
    {
        targets = new List<GameObject>();
    }
    public Vector3 GetNextTargetNode()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            currentTarget = targets[i].transform.position;
            Debug.Log("current pos = " + currentTarget);
        }

        return currentTarget;
    }
   
}
