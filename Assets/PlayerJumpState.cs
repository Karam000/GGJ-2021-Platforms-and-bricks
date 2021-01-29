using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : MonoBehaviour
{
    Vector3 jump;
    public float jumpForce = 2.0f;
    Rigidbody rb;
    [Range(20f, 70f)] public float jumpAngle;
    GameObject character;
    Vector3 target;
    int i = 0;
    [SerializeField] List<GameObject> targets;
    Vector3 currentTarget;
    void Start()
    {
        character = this.gameObject.transform.GetChild(0).gameObject;
        rb = character.GetComponent<Rigidbody>();
    }
    public Vector3 GetNextTargetNode()
    {
      
       currentTarget = targets[i].gameObject.transform.position;
       i++;

        return currentTarget;
    }
    public void JumpNormal()
    {
        if(CharacterCollision.isGrounded)
        {
            jump = new Vector3(0.0f, 2.0f, 0.0f);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
    public void JumpCurved()
    {
        Vector3 startPos = character.transform.position;
        target = GetNextTargetNode();
        float distance = Vector3.Distance(startPos, target);

        transform.LookAt(target);

        float initialVeclocity = Mathf.Sqrt(distance * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * jumpAngle * 2f)));
        float yVelocity, zVelocity;

        yVelocity = initialVeclocity * Mathf.Sin(Mathf.Deg2Rad * jumpAngle);
        zVelocity = initialVeclocity * Mathf.Cos(Mathf.Deg2Rad * jumpAngle);


        Vector3 localVelocity = new Vector3(0f, yVelocity, zVelocity);
        Vector3 globalVelocity = transform.TransformVector(localVelocity);

        character.GetComponent<Rigidbody>().velocity = globalVelocity;
    }

}
