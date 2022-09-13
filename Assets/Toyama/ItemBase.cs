using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] AudioClip _se = default;

    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_se, Camera.main.transform.position);

            Activate();

            Destroy(gameObject);
        }
    }
}
