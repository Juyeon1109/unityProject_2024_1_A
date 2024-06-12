using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLind : MonoBehaviour
{
    public bool isDrag;         //마우스 Drag 판단
    public bool isUsed;         //사용 완료 체크
    Rigidbody2D rigidbody2D;    //2D 강체 선언

    public int Index;           //과일 번호 설정

    public float EndTime = 0.0f;     //종료 전 시간 체크 변수(float)
    public SpriteRenderer spriteRenderer;   //종료시 스프라이트 색을 변환 시키기 위해서 접근 선언

    public GameManager gameManager;     //게임 메니저 참조용

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();      //오브젝트의 강체에 접근
        isUsed = false;                                 //시작할때 사용이 안되었다고 입력
        rigidbody2D.simulated = false;                  //물리 행동이 처음에는 동작하지 않게 설정

        spriteRenderer = GetComponent<SpriteRenderer>();        //오브젝트에 붙어잇는 컴포넌트에 접근
    }



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();    //게임 매니저를 얻어온다
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
