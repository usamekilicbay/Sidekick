using Constants;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Range(50f, 150)]
    [SerializeField] private float rotationSpeed;

    [Header("Effects")]
    [SerializeField] private GameObject particle;
    [SerializeField] private AudioClip sfx;

    #region UNITY METHOD

    private void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != Layer.PLAYER) return;

        CollectCoin();
    }

    #endregion

    private void Rotate()
    {
        transform.Rotate(Time.deltaTime * Vector3.up * rotationSpeed);
    }

    private void CollectCoin()
    {
        PlayParticle();
        EventManager.Instance.PlaySFX?.Invoke(sfx);
        EventManager.Instance.CollectCoin?.Invoke();
        StartCoroutine(SelfDestruct());
    }

    private void PlayParticle()
    {
        particle.SetActive(true);
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(.5f);

        particle.SetActive(false);

        gameObject.SetActive(false);
    }
}
