using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarashiController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;
    bool isDead;

    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;

    public bool IsDead()
    {
        return isDead;
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
    }

    void Update()
    {
        // �ō����x�ɒB���Ă��Ȃ��ꍇ�Ɍ���^�b�v�̓��͂��󂯕t����
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }

        // �p�x�𔽉f
        ApplyAngle();

        // angle�������ȏゾ������A�A�j���[�^�[��flap�t���O��true�ɂ���
        animator.SetBool("flap", angle >= 0.0);
    }

    public void Flap()
        {
        // ���񂾂�͂΂����Ȃ�
        if (isDead) return;

        // �d�͂������Ă��Ȃ��Ƃ��͑��삵�Ȃ�
        if (rb2d.isKinematic) return;

            // Velocity�𒼐ڏ��������ď�����ɉ���
            rb2d.velocity = new Vector2(0.0f, flapVelocity);
        }
    void ApplyAngle()
    {
        // ���݂̑��x�A���Α��x����i��ł���p�x�����߂�
        float targetAngle;

        // ���S�������ɂЂ�����Ԃ�
        if (isDead)
        {
            targetAngle = 180.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }
            

        // ��]�A�j�����X���[�W���O
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        // Rotation�̔��f
        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        // �N���b�V���G�t�F�N�g
        Camera.main.SendMessage("Clash");

        // �����ɂԂ������玀�S�t���O�����Ă�
        isDead = true;
    }
    
    public void SetSteerActive(bool active)
    {
        // Rigidbody�̃I���A�I�t��؂�ւ���
        rb2d.isKinematic = !active;
    }

}
