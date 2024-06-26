using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cirlcleobjcet : MonoBehaviour
{
    public bool isDrag;     //마우스 드래그 판단
    public bool isUsed;     //사용완료 체크
    Rigidbody2D rigidbody2D;    //2D 강체 선언

    public int index;     //과일 번호 설정
    public float EndTime;

    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();  //오브젝트의 강체에 접근
        isUsed = false;                             //시작할때 사용이 안되었다고 입력
        rigidbody2D.simulated = false;              //물리 행도이 청므에는 동작하지 않게 설정
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)     //사용이 완료된 오브젝트는 업데이트 문을 그냥 돌려 보낸다. (마우스 Input 적용을 막기 위해)
            return;

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     //화면 스크린에서 유니티 Scene 공간의 좌표를 가져온다.

            float leftBorder = -5.0f + transform.localScale.x / 2f;     //반지름 만큼 이동 제한
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;       //마우스 위치가 이동 제한 한곳 이상, 이하로 가면 값을 조절해서 가둔다.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                             //오브젝트 Y축 값 고정
            mousePos.z = 0;                                             //오브젝트 X축 값 고정
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);      //이 오브젝트를 마우스 위치로 리니어하게 0.2값만큼씩 이동시켜 따라간다.
        }

        if (Input.GetMouseButtonDown(0)) Drag();    //마우스 버튼이 눌렸을 때 Drag함수 실행
        if (Input.GetMouseButtonUp(0)) Drop();      //마우스 버튼이 올라갈 때 Drop함수 실행
    }

    void Drag()             //드래그 할 때 상태 값 함수
    {
        isDrag = true;      //드래그 중이다.(true)
        rigidbody2D.simulated = false;  //물리 시뮬레이션 안함.(false)
    }

    void Drop()     //드랍 할 때 상태값 함수
    {
        isDrag = false; //드래그 중이다(false)
        isUsed = true;  //사용 완료 되었다(true)
        rigidbody2D.simulated = true;   //물리 시뮬레이션 사용함(true)

        GameObject temp = GameObject.FindWithTag("GameManager");    //Scene에서 GameManager Tag 가지고 있는 오브젝트를 가져온다
        if(temp != null)                                            //해당 오브젝트가 있을 경우
        {
            temp.gameObject.GetComponent<GameManager>().GenObject();    //GameManager의 GenObject 함수를 호출
        }
    }
    public void Used()
    {
        isDrag = false;     //드래그 중이다 (false)
        isUsed = true;      //사용 완료 되었다.(true)
        rigidbody2D.simulated = true;   //물리 시뮬레이션 사용함 (true)
    }
    public void OnTriggerStay2D (Collider2D collision)       //해당 오브젝트가 충돌 했을 때 OnCollisionEnter2D
    {
        if( collision.tag == "EndLine")                     //충돌중인 물체의 Tag가 EndLine일 경우
        {
            EndTime += Time.deltaTime;                      //프레임 시간만큼 누적 시켜서 초기화
            if(EndTime > 1)                                 //1초 이상일 경우
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f); //빨강색 처리
            }
            if(EndTime > 3)                                 //3초 이상일 경우
            {
                Debug.Log("게임종료");                      //우선 게임 종료 처리
            }
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.tag == "EndLine")
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;
        }
    }


}

