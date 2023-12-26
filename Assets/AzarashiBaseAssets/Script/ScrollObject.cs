using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;
    

    void Update()
    {
        // ���t���[��x�|�W�V�������������ړ�������
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // �X�N���[�����ڕW�|�C���g�܂œ��B�������`�F�b�N
        if (transform.position.x <= endPosition) ScrollEnd();

    }

    void ScrollEnd()
    {
        // �ʂ�߂��������������ă|�W�V�������Đݒ�
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
        transform.position = restartPosition;

        // �����Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���R���|�[�l���g�Ƀ��b�Z�[�W�𑗂�
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);

    }

}
