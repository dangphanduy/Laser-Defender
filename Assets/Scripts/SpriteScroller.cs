using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed;
    Vector2 _offset;
    Material _material;

    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        _offset += scrollSpeed * Time.deltaTime;
        _material.mainTextureOffset = _offset;
    }
}
