using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color damageColor = Color.red;
    private bool isBlinking = false;

    [SerializeField] private float blinkDuration = 4f;
    [SerializeField] private float blinkInterval = 0.5f;
    [SerializeField] private float minAlpha = 0.12f;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float damageDuration = 0.6f;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }

    private IEnumerator TransparencyEffect()
    {

        float timer = 0f;

        while (timer < blinkDuration)
        {

            float alpha = Mathf.PingPong(timer / blinkInterval, 1) > 0.5f ? maxAlpha : minAlpha;

            spriteRenderer.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, alpha);

            timer += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = defaultColor;
        isBlinking = false;


    }

    private IEnumerator DamageEffect()
    {
        isBlinking = true;

        float timer = 0f;
        float halfDuration = damageDuration / 2;
        while(timer < damageDuration)
        {
            spriteRenderer.color = Color.Lerp(defaultColor, damageColor, timer / halfDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = damageColor;

        timer = 0f;
        while (timer < damageDuration)
        {
            spriteRenderer.color = Color.Lerp(damageColor, defaultColor, timer / halfDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = defaultColor;
        StartCoroutine(TransparencyEffect());
    }


    public void PlayDamageEffect()
    {
        if (!isBlinking)
        {
            StartCoroutine(DamageEffect());
        }
    }
}
