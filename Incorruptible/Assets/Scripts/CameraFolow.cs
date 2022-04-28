using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 minValues, maxValues;
    [Range(1,10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x,minValues.x,maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));
        //lerp=liniar interpolation
        Vector3 smoothPosition = Vector3.Lerp(transform.position,boundPosition,smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

}
