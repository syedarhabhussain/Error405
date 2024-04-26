using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Boss : MonoBehaviour
{
    Transform playerT;
    Damageable dmg;

    GameObject lightning;
    GameObject lightningOrb;
    public GameObject artifact;
    Animator anim;
    private SpriteRenderer sprite;

    float angle = 0f;
    Vector2 bulletMoveDirection;
    Vector3 direction;

    public List<GameObject> mobs;

    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        dmg = GetComponent<Damageable>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = playerT.position - transform.position;
        direction.Normalize();

        if (direction.x < 0f)
        {
            sprite.flipX = true;
        }
        else if (direction.x >= 0f)
        {
            sprite.flipX = false;
        }

        if (dmg.currentHealth <= 0)
        {
            Instantiate(artifact, new Vector2(161f, -45f), Quaternion.identity);
            Destroy(gameObject);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }

    public void callLightning(GameObject lightning, int amount)
    {
        StartCoroutine(Lightning(lightning, amount));
    }

    IEnumerator Lightning(GameObject lightning, int amount)
    {
        for(int x=0; x<amount; x++)
        {
            Instantiate(lightning, new Vector2(Random.Range(149,173), Random.Range(-56,-34)), transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void callBulletSpiral(GameObject lightningOrb, float delay)
    {
        InvokeRepeating("Fire", 0f, delay);
       // Debug.Log("call");
        //StartCoroutine(Spiral());
    }

    IEnumerator Spiral()
    {
        Fire();
        yield return new WaitForSeconds(0.2f);
    }

    public void cancelSpiral()
    {
        CancelInvoke("Fire");
    }

    void Fire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BossBulletPool.instance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);
        }

        angle += 20f;

        if (angle >= 360f)
            angle = 0f;
    }

    public void callSpawns()
    {
        InvokeRepeating("SpawnMobs", 0f, 5);
    }
    void SpawnMobs()
    {
        GameObject mob = Instantiate(mobs[Random.Range(0,mobs.Count)], new Vector2(Random.Range(149, 173), Random.Range(-56, -34)), Quaternion.identity);
        mob.GetComponent<BossCheckpoint>().enabled = false;
    }
    public void cancelSpawns()
    {
        CancelInvoke("SpawnMobs");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-2);
            anim.SetTrigger("Smash");
        }
    }
}
