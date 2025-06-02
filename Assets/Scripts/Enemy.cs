using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveRange = 3f;
    [SerializeField] private int damage = 1;
    [SerializeField] private int maxHealth = 3; // ���� �ִ� ü�� �߰�

    private Animator animator;
    private Vector2 startPos;
    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;
    private bool isDying = false;
<<<<<<< HEAD
=======
    private int currentHealth; // ���� ü��
>>>>>>> 62f7170fb01ff4ca790abc9d41de3db2dee18e65

    void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
<<<<<<< HEAD
=======
        currentHealth = maxHealth; // ���� �� ü�� �ʱ�ȭ
>>>>>>> 62f7170fb01ff4ca790abc9d41de3db2dee18e65
    }

    void Update()
    {
        // ���� �״� ���̶�� �̵� ������ ��Ȱ��ȭ
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
        if (isDying) return; // 중복방지
        isDying = true;

=======
     // �Ѿ� �������κ��� �������� �޴� �Լ�
    public void TakeDamage(int damageAmount)
    {
        if (isDying) return; // �̹� �״� ���̸� ������ ���� ����

        // �Ѿ� �浹 ȿ���� ���
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayBulletHitSound();
        }
        else
        {
            Debug.LogWarning("FlyingObject: AudioManager �ν��Ͻ��� ã�� �� �����ϴ�.");
        }

        currentHealth -= damageAmount;
        Debug.Log("Enemy took " + damageAmount + " damage. Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ���ϸ� ����
        }
    }

    public void Die()
    {
        if (isDying) return; // �ߺ�����
        isDying = true;

        // �״� �Ҹ� ���
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayDeadSound(); 
        }
        else
        {
            Debug.LogWarning("FlyingObject: AudioManager �ν��Ͻ��� ã�� �� �����ϴ�.");
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
