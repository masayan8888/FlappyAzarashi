using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject root;

    void Start()
    {
        // �J�n���Ɍ��Ԃ̍�����ύX
        ChangeHeight();
    }

    void ChangeHeight()
    {
        // �����_���ȍ����𐶐����Đݒ�
        float height = Random.Range(minHeight, maxHeight);
        root.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }

    // ScrollObjcet�X�N���v�g����̃��b�Z�[�W���󂯎���č�����ύX
    void OnScrollEnd()
    {
        ChangeHeight();
    }

}
