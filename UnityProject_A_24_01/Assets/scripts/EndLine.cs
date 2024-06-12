using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLind : MonoBehaviour
{
    public bool isDrag;         //���콺 Drag �Ǵ�
    public bool isUsed;         //��� �Ϸ� üũ
    Rigidbody2D rigidbody2D;    //2D ��ü ����

    public int Index;           //���� ��ȣ ����

    public float EndTime = 0.0f;     //���� �� �ð� üũ ����(float)
    public SpriteRenderer spriteRenderer;   //����� ��������Ʈ ���� ��ȯ ��Ű�� ���ؼ� ���� ����

    public GameManager gameManager;     //���� �޴��� ������

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();      //������Ʈ�� ��ü�� ����
        isUsed = false;                                 //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D.simulated = false;                  //���� �ൿ�� ó������ �������� �ʰ� ����

        spriteRenderer = GetComponent<SpriteRenderer>();        //������Ʈ�� �پ��մ� ������Ʈ�� ����
    }



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();    //���� �Ŵ����� ���´�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
