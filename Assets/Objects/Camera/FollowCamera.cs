using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform followObject;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float cameraSpeed;

    private float lerpTime = 0;

    private Vector3 lastPos;
    private Vector3 TargetPos;

    private void Update()
    {
        maxY = Mathf.Max(maxY, minY);
        minY = Mathf.Min(maxY, minY);

        if(TargetPos != followObject.transform.position)
        {
            TargetPos = followObject.transform.position;
            lastPos = transform.position;
            lerpTime = 0;
        }

        Vector3 temp = new Vector3(lastPos.x, Mathf.Max(minY, Mathf.Min(maxY, TargetPos.y)), lastPos.z);

        transform.position = Vector3.Lerp(lastPos, temp, lerpTime);

        lerpTime += Time.deltaTime* cameraSpeed;
        lerpTime = Mathf.Min(lerpTime, 1);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-100, minY, 0), new Vector3(+100, minY, 0));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(-100, maxY, 0), new Vector3(+100, maxY, 0));
    }

}
