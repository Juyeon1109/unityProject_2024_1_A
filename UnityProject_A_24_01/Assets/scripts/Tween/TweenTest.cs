using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  //DoTween�� ����ϱ� ���� �߰�

public class TweenTest : MonoBehaviour
{
    Sequence Sequence;
    Tween tween;
    // Start is called before the first frame update
    void Start()
    {
        //transform.DOmoveX(5, 2);      //�� ������Ʈ�� 2�ʵ��� X�� 5�� �̵���Ų��.
        //transform.DORotate( new Vecter3(0, 0, 180), 2);  //�� ������Ʈ�� 2�ʵ��� Z������ ȸ�� ��Ų��.
        // transform.DOScale(new Vector3(2, 2, 2), 2);        //�� ������Ʈ�� 2�ʵ��� Scale�� 2�� �ǵ��� Ű���.

        // Sequence sequence = DOTween.Sequence();
        // sequence.Append(transform.DOMoveX(5, 2));
        // sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 2));
        // sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));

        // transform.DOMoveX(5, 2f).SetEase(Ease.OutBounce);     //Ease �ɼ��� ����Ͽ� �ٿ ȿ�� ����
        // transform.DOShakeRotation(0.5f, new Vector3(0, 0, 90), 10, 90); //ȸ���� Z�� 90�� ���� 10, ���� 90���� ���� �ش�

      //transform.DOMoveX(5, 2f).SetEase(Ease.OutBounce).OnComplete(TweenEnd);  //Ʈ���� �Ϸ�Ǹ� Tween End �Լ��� ȣ���Ѵ�

        Sequence sequence = DOTween.Sequence();   //Tween�� �̾ ������� ���� �����ִ� ����
        sequence.Append(transform.DOMoveX(5, 1));   //Tween ����
        sequence.SetLoops(-1,LoopType.Yoyo);        //Tween ��� ���·� �ݺ� ��Ų��
    }

    // Update is called once per frame
    void TweenEnd()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sequence.Kill();
            //tween.Kill();
        }
    }
}
