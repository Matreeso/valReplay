using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Check if the target object is assigned.
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            return;
        }

        // Calculate the desired camera position by adding the offset to the target's position.
        Vector3 desiredPosition = targetObject.position + offset;

        // Smoothly interpolate the current camera position to the desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Set the camera's position to the smoothed position.
        transform.position = smoothedPosition;

        // Make the camera look at the target object.
        transform.LookAt(targetObject);
    }
}
