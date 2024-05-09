using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float rotationSpeed = 5f;
    public float rotationMultiplier = 0.1f;

    public float cameraAngel = 30f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Create the camera's target rotation with the character's rotation
            Quaternion targetRotation = Quaternion.Euler(cameraAngel+target.eulerAngles.x,target.eulerAngles.y, 0f);

            //Calculate the camera's target position from the character's position and the set distance
            Vector3 targetPosition = target.position - targetRotation * Vector3.forward * distance;
            targetPosition.y = target.position.y + height;

            // Update camera rotation gently
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, targetPosition, rotationSpeed * Time.deltaTime);

            //High Performance//

            transform.position = targetPosition;
            transform.rotation = targetRotation;
        }
    }
}
