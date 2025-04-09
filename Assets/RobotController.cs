using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class RobotController : MonoBehaviour
{
    public GameObject jumpSound;
    GameObject shield;

    bool isJumping;
    bool isSliding; // 엎드리는 상태 플래그
    Rigidbody2D rb;
    float speed = 15.0f;
    float maxSpeed = 3.0f;
    Animator animator;
    float boostedMaxSpeed = 4.5f; // Shift 키를 눌렀을 때의 최대 속도
    private GameObject robot;
    GameObject SN; //쉴드횟수
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
          ? boostedMaxSpeed // Shift 키를 누르면 boostedMaxSpeed
          : maxSpeed;        // 기본 maxSpeed

        // 엎드리기 상태에서 방향키가 눌리면 걷기 상태로 복구
        if (isSliding && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            isSliding = false;
            animator.SetBool("slide", false); // 엎드리기 애니메이션 종료
            animator.speed = 1f;
        }

        // 엎드리는 동안 이동 금지
        if (isSliding)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // X축 속도 제거
            return; // FixedUpdate의 이동 처리 로직을 무시
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

        //쉴드
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // shieldNumber 값 가져오기
            int shieldNumber = int.Parse(GameObject.Find("ShieldNumber").GetComponent<Text>().text);

            if (shieldNumber > 0) // shieldNumber가 0보다 크면 실행
            {
                
                // Shield 활성화 처리
                SN = GameObject.Find("SN");


                    shieldNumber1.text = "0";


                // Shield와 RobotBoy 오브젝트 찾기
                shield = GameObject.Find("Shield");
                robot = GameObject.Find("RobotBoy");

                if (shield != null && robot != null)
                {
                    // Shield를 RobotBoy 위로 1만큼 이동
                    Vector3 newPosition = robot.transform.position;
                    newPosition.y += 1;
                    shield.transform.position = newPosition;

                    // Shield 2초 후 삭제
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
            if (!isSliding) // 엎드리기 시작
            {
                isSliding = true;
                animator.SetBool("slide", true);
                animator.speed = 4f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 바닥에 닿았는지 확인
        {
            isJumping = false; // 점프 상태 해제
            animator.SetBool("IsGrounded", true); // 착지 상태로 설정
            animator.ResetTrigger("JumpCall"); // 점프 트리거 초기화
        }
    }
}
