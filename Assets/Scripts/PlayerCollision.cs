using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            Events.GameFinish?.Invoke();
        }
        if (collision.gameObject.CompareTag("Sea"))
        {
            GetComponent<Collider>().enabled = false;
            Events.GameFinish?.Invoke();
        }
        if (collision.gameObject.CompareTag("Billet"))
        {
            transform.SetParent(collision.gameObject.transform);
            collision.transform.DOMoveY(collision.transform.position.y - 0.1f, 0.1f).OnComplete(() => collision.transform.DOMoveY(collision.transform.position.y + 0.1f, 0.1f));
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Billet"))
        {
            transform.SetParent(null);
        }
    }
}
