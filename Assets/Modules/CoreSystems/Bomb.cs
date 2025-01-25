using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float fuseTime = 3f;

    private SpriteRenderer sp;
    private BoxCollider2D bc;
    private Transform tr;
    private Vector3 sizeIncrease; 
    public bool isExploding = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        tr = GetComponent<Transform>();
        gameObject.tag = "Bomb";
        isExploding = false;
        sizeIncrease = new Vector3(3, 3, 3);
        sp.color = Color.green;
        StartCoroutine(Fuse());
    }


    private IEnumerator Fuse()
    {
        yield return new WaitForSeconds(fuseTime);
        Explode();
    }

    private IEnumerator Exploding()
    {
        isExploding = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void Explode()
    {
        tr.localScale += sizeIncrease;
        sp.color = Color.yellow;
        StartCoroutine(Exploding());
    }
}
