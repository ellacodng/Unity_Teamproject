using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveRange = 3f;
    [SerializeField] private int damage = 1;
    [SerializeField] private int maxHealth = 3; // ÀûÀÇ ÃÖ´ë Ã¼·Â Ãß°¡

    private Animator animator;
    private Vector2 startPos;
    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;
    private bool isDying = false;
<<<<<<< HEAD
=======
    private int currentHealth; // ÇöÀç Ã¼·Â
>>>>>>> 62f7170fb01ff4ca790abc9d41de3db2dee18e65

    void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
<<<<<<< HEAD
=======
        currentHealth = maxHealth; // ½ÃÀÛ ½Ã Ã¼·Â ÃÊ±âÈ­
>>>>>>> 62f7170fb01ff4ca790abc9d41de3db2dee18e65
    }

    void Update()
    {
        // ÀûÀÌ Á×´Â ÁßÀÌ¶ó¸é ÀÌµ¿ ·ÎÁ÷À» ºñÈ°¼ºÈ­
        if (isDying) return;

        float direction = movingRight ? 1 : -1;
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        if (movingRight && transform.position.x > startPos.x + moveRange)
        {
            movingRight = false;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else if (!movingRight && transform.position.x < startPos.x - moveRange)
        {
            movingRight = true;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

<<<<<<< HEAD
    public void Die()
    {
        if (isDying) return; // ì¤‘ë³µë°©ì§€
        isDying = true;

=======
     // ÃÑ¾Ë °ø°ÝÀ¸·ÎºÎÅÍ µ¥¹ÌÁö¸¦ ¹Þ´Â ÇÔ¼ö
    public void TakeDamage(int damageAmount)
    {
        if (isDying) return; // ÀÌ¹Ì Á×´Â ÁßÀÌ¸é µ¥¹ÌÁö ¹ÞÁö ¾ÊÀ½

        // ÃÑ¾Ë Ãæµ¹ È¿°úÀ½ Àç»ý
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayBulletHitSound();
        }
        else
        {
            Debug.LogWarning("FlyingObject: AudioManager ÀÎ½ºÅÏ½º¸¦ Ã£À» ¼ö ¾ø½À´Ï´Ù.");
        }

        currentHealth -= damageAmount;
        Debug.Log("Enemy took " + damageAmount + " damage. Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Ã¼·ÂÀÌ 0 ÀÌÇÏ¸é Á×À½
        }
    }

    public void Die()
    {
        if (isDying) return; // Áßº¹¹æÁö
        isDying = true;

        // Á×´Â ¼Ò¸® Àç»ý
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayDeadSound(); 
        }
        else
        {
            Debug.LogWarning("FlyingObject: AudioManager ÀÎ½ºÅÏ½º¸¦ Ã£À» ¼ö ¾ø½À´Ï´Ù.");
        }

>>>>>>> 62f7170fb01ff4ca790abc9d41de3db2dee18e65
        animator.SetTrigger("Die");
    }
    public void DestroyAfterDeath()
    {
<<<<<<< HEAD
=======
        Debug.Log("Enemy Destroyed after death animation.");
>>>>>>> 62f7170fb01ff4ca790abc9d41de3db2dee18e65
        Destroy(gameObject);
    }
}
