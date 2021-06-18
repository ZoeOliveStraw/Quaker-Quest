using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] bool waitsAtPoints;
    [SerializeField] float waitTimeAtPoint;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject mover;
    [SerializeField] Transform[] points;
    private Transform currentTarget;
    [SerializeField] int startingTargetIndex;
    private bool isMoving = true;
    private int currentTargetIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = points[startingTargetIndex];
        currentTargetIndex = startingTargetIndex;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToTarget = Vector3.Distance(mover.transform.position,currentTarget.position);
        if(!waitsAtPoints)
        {
            if(distanceToTarget <= 0.05f)
            {
                GetNextPoint();
            }
            mover.transform.position = Vector3.MoveTowards(mover.transform.position,currentTarget.position,GetMoveSpeed(distanceToTarget) * Time.deltaTime);
        }
        else
        {
            if(isMoving && distanceToTarget <= 0.05f)
            {
                StartCoroutine(WaitTime());
            }
            else
            {
                mover.transform.position = Vector3.MoveTowards(mover.transform.position,currentTarget.position,GetMoveSpeed(distanceToTarget) * Time.deltaTime);
            }
        }
    }
    private float GetMoveSpeed(float distance)
    {
        return Mathf.Clamp(moveSpeed * distance,0.3f,moveSpeed);
    }

    private void GetNextPoint()
    {
        if(currentTargetIndex < (points.Length - 1))
        {
            currentTargetIndex++;
        }
        else
        {
            currentTargetIndex = 0;
        }
        currentTarget = points[currentTargetIndex];
    }

    private IEnumerator WaitTime()
    {
        isMoving = false;
        yield return new WaitForSeconds(waitTimeAtPoint);
        isMoving = true;
        GetNextPoint();
    }
}
