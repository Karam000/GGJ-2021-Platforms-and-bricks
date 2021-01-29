using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;
using SO;
public class CharacterCollision : MonoBehaviour
{
    public static bool isGrounded;
    public VariableSO<int> NumSO;
    [SerializeField] EventSO OnChangeValue;

    private void Start()
    {
       NumSO = (VariableSO<int>)OnChangeValue.Value;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GameTags.PlatformTag)
        {
            int max = collision.gameObject.GetComponent<PlatformBehavior>().maxNumberOfJumps;
            isGrounded = true;
            NumSO.Value++;
            if (NumSO.Value >= max)
            {
                Destroy(collision.gameObject);
                NumSO.Value = 0;
            }

        }
    }
   
}
