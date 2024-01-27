using System.Collections;
using UnityEngine;

public class SpecialBox : MonoBehaviour
{
    public enum Ability { Cake, BananaPeel }
    public Ability ability;

    private bool isInteracted = false;
    private float scaleSpeed = 1.5f;
    private float rotationSpeed = 50.0f;

    public delegate void BoxUsedHandler(SpecialBox box);
    public static event BoxUsedHandler OnBoxUsed;

    void Start()
    {
        ability = (Ability)Random.Range(0, System.Enum.GetValues(typeof(Ability)).Length);
    }

    void Update()
    {
        if (!isInteracted)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
            float scale = Mathf.Sin(Time.time) * 0.1f + 1.0f;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInteracted)
        {
            isInteracted = true;
            ActivateAbility();
            StartCoroutine(ScaleDownAnimation());
        }
    }

    void ActivateAbility()
    {
        switch (ability)
        {
            case Ability.Cake:
                // Can throw a cake to the another player
                break;
            case Ability.BananaPeel:
                // Can throw a banana peel to the another player
                break;
        }
    }

    public void ResetBox()
    {
        isInteracted = false;
        ability = (Ability)Random.Range(0, System.Enum.GetValues(typeof(Ability)).Length);
    }

    IEnumerator ScaleDownAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.2f;
        Vector3 disappearScale = Vector3.zero;

        float timer = 0.0f;
        while (timer <= 1.0f)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timer);
            timer += Time.deltaTime * scaleSpeed;
            yield return null;
        }

        timer = 0.0f;
        while (timer <= 1.0f)
        {
            transform.localScale = Vector3.Lerp(targetScale, disappearScale, timer);
            timer += Time.deltaTime * scaleSpeed;
            yield return null;
        }

        OnBoxUsed?.Invoke(this);

        gameObject.SetActive(false);
    }
}
