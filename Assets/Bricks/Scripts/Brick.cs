using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] Node node;
    [SerializeField] TextMesh requiredNumberText;
    [SerializeField] GameObject gemPrefab;
    [SerializeField] GameObject explodePrefab;
    bool isExploding;

    void Start()
    {
        requiredNumberText.text = node.NodeRequiredNumber.ToString();
    }
    private void Update()
    {
        if(!isExploding)
        {
            switch (node.currentState)
            {
                case Node.NodeState.Rotate:
                    RotateAroundLevelCenter();
                    break;

                case Node.NodeState.Explode:
                    ExplodeBrick();
                    break;
            }
        }
    }

    #region HelperFunctions
    public void RotateAroundLevelCenter()
    {
        transform.RotateAround(node.NodeCenter.position, Vector3.up, node.NodeRotationSpeed * Time.deltaTime);
    }
    void ExplodeBrick()
    {
        isExploding = true;

        Invoke("Explode", 0.1f);
    }
    void PopupGems()
    {
        requiredNumberText.gameObject.SetActive(false);
        GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
        gem.GetComponent<Gem>().TweenTowards(node.NodeCenter);
    }
    void Explode()
    {
        GameObject explodeGO = Instantiate(explodePrefab, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        PopupGems();

        Destroy(explodeGO, 1f);
        Destroy(gameObject, 1.5f);
    }
    #endregion
}
