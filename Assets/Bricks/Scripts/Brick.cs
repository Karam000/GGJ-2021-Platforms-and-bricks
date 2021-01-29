using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] Node level;
    [SerializeField] TextMesh requiredNumberText;
    [SerializeField] GameObject gemPrefab;
    [SerializeField] GameObject explodePrefab;

    void Start()
    {
        requiredNumberText.text = level.NodeRequiredNumber.ToString();
    }
    private void Update()
    {
        switch (level.currentState)
        {
            case Node.NodeState.Rotate:
                RotateAroundLevelCenter();
                break;

            case Node.NodeState.Explode:
                ExplodeBrick();
                break;
        }
    }

    #region HelperFunctions
    public void RotateAroundLevelCenter()
    {
        transform.RotateAround(level.NodeCenter.position, Vector3.up, level.NodeRotationSpeed * Time.deltaTime);
    }
    void ExplodeBrick()
    {
        PopupGems();
        Invoke("Explode", 1f);
    }
    void PopupGems()
    {

    }
    void Explode()
    {
        requiredNumberText.gameObject.SetActive(false);

    }
    #endregion
}
