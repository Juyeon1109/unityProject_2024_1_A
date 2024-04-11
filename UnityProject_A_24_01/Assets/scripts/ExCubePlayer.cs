using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExcubePlayer : MonoBehaviour
{
    public Text TextUI = null;          // �ؽ�Ʈ UI
    public int Count = 0;               // ���콺 Ŭ�� ī����
    public float Power = 100;           // ���� �� ��ġ
   
    public int Point = 0;
    public float checkTime = 0.0f;
    public float checkEndTime = 30.0f;

    public Rigidbody m_Rigidbody;       // ������Ʈ�� ��ü

    // Update is called once per frame
    void Update()
    {
        checkEndTime -= Time.deltaTime;

        if (checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("ResultScene");
        }


        checkTime += Time.deltaTime;
        if(checkTime >= 1.0f)
        {
            Point += 1;
            checkTime = 0.0f;
        }


        if (Input.GetKeyDown(KeyCode.Space))        //�����̽��� ���� ��
        {
            Count += 1;                             //���콺�� Ŭ���Ǿ����� Count�� 1�� �ø���
            TextUI.text = Count.ToString();         //UI ����
            Power = Random.Range(100, 200);         //100 ~ 200 ������ ���� ���� �ش�.
            m_Rigidbody.AddForce(transform.up * Power);     //Y������ ������ ���� �ش�.
        }

        TextUI.text = Point.ToString();

      
    }
    void OnCollisionEnter(Collision collision)      //�浹�� �Ǿ��� ��
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Pipe")
        {
            Point = 0;
            gameObject.transform.position = Vector3.zero;       //�÷��̾ �������� �̵� ��Ų��.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Items")
        {
            Point += 10;
            Destroy(other.gameObject);
        }
    }

}

