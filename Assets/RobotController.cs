using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class RobotController : MonoBehaviour
{
    public GameObject jumpSound;
    GameObject shield;

    bool isJumping;
    bool isSliding; // ���帮�� ���� �÷���
    Rigidbody2D rb;
    float speed = 15.0f;
    float maxSpeed = 3.0f;
    Animator animator;
    float boostedMaxSpeed = 4.5f; // Shift Ű�� ������ ���� �ִ� �ӵ�
    private GameObject robot;
    GameObject SN; //����Ƚ��
    Text shieldNumber1;

    // Start is called before the first frame update
    void Start()
    {
        shieldNumber1 = GameObject.Find("ShieldNumber").GetComponent<Text>();
        SN = GameObject.Find("AddScore");

        isJumping = false;
        isSliding = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.speed = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentMaxSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)
          ? boostedMaxSpeed // Shift Ű�� ������ boostedMaxSpeed
          : maxSpeed;        // �⺻ maxSpeed

        // ���帮�� ���¿��� ����Ű�� ������ �ȱ� ���·� ����
        if (isSliding && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            isSliding = false;
            animator.SetBool("slide", false); // ���帮�� �ִϸ��̼� ����
            animator.speed = 1f;
        }

        // ���帮�� ���� �̵� ����
        if (isSliding)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // X�� �ӵ� ����
            return; // FixedUpdate�� �̵� ó�� ������ ����
        }

        float speedx = Mathf.Abs(rb.velocity.x);

        if (speedx < currentMaxSpeed)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(transform.right * speed);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(transform.right * -1 * speed);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            animator.speed = speedx;
        }

        //����
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // shieldNumber �� ��������
            int shieldNumber = int.Parse(GameObject.Find("ShieldNumber").GetComponent<Text>().text);

            if (shieldNumber > 0) // shieldNumber�� 0���� ũ�� ����
            {
                
                // Shield Ȱ��ȭ ó��
                SN = GameObject.Find("SN");


                    shieldNumber1.text = "0";


                // Shield�� RobotBoy ������Ʈ ã��
                shield = GameObject.Find("Shield");
                robot = GameObject.Find("RobotBoy");

                if (shield != null && robot != null)
                {
                    // Shield�� RobotBoy ���� 1��ŭ �̵�
                    Vector3 newPosition = robot.transform.position;
                    newPosition.y += 1;
                    shield.transform.position = newPosition;

                    // Shield 2�� �� ����
                    Destroy(shield, 2f);
                }
                else
                {
                    Debug.LogError("Shield or RobotBoy object not found!");
                }
            }
        }


            if (Input.GetKey(KeyCode.Space))
        {
            if (!isJumping)
            {
                GameObject.Find("SoundController").GetComponent<SoundController>().PlaySound(jumpSound, 1f);
                isJumping = true;
                rb.AddForce(transform.up * 7.0f, ForceMode2D.Impulse);
                animator.SetTrigger("JumpCall");
                animator.speed = 8f;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!isSliding) // ���帮�� ����
            {
                isSliding = true;
                animator.SetBool("slide", true);
                animator.speed = 4f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // �ٴڿ� ��Ҵ��� Ȯ��
        {
            isJumping = false; // ���� ���� ����
            animator.SetBool("IsGrounded", true); // ���� ���·� ����
            animator.ResetTrigger("JumpCall"); // ���� Ʈ���� �ʱ�ȭ
        }
    }
}
