using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime = 3f;

    private void OnEnable()
    {
        StartCoroutine(DeactivateAfterLifetime());
    }
    private IEnumerator DeactivateAfterLifetime()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }
}
