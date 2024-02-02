using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Vector2 moveDir;
    float moveSpeed;
   // BossBulletPool BPool;
    //[SerializeField] bool isYellow;

    void OnEnable()
    {
        Invoke("Destroy", 3f);
      //  BPool = GameObject.FindWithTag("BulletPool").GetComponent<BossBulletPool>();
    }
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
      //  if (BPool.isP2 && isYellow)
       //     Destroy(gameObject);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDir = dir;
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
        Destroy();
    }
}
