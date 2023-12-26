using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
   // �Q�[���X�e�[�g
   enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    int score;

    public AzarashiController azarashi;
    public GameObject blocks;
    public Text scoreText;
    public Text stateText;

    void Start()
    {
        // �J�n�Ɠ�����Ready�X�e�[�g�Ɉڍs
        Ready();
    }

    void LateUpdate ()
    {
        // �Q�[���̃X�e�[�g���ƂɃC�x���g���Ď�
        switch (state)
        {
            case State.Ready:
                // �^�b�`������Q�[���X�^�[�g
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case State.Play:
                if (azarashi.IsDead()) GameOver();
                break;
            case State.GameOver:
                // �^�b�`������V�[���������[�h
                if (Input.GetButtonDown("Fire1")) Reload();
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;

        // �e�I�u�W�F�N�g�𖳌���Ԃɂ���
        azarashi.SetSteerActive(false);
        blocks.SetActive(false);

        // ���x�����X�V
        scoreText.text = "Score : " + 0;

        stateText.gameObject.SetActive(true);
        stateText.text = "Ready?";

    }
       
    void GameStart()
    {
        state = State.Play;

        // �e�I�u�W�F�N�g��L���ɂ���
        azarashi.SetSteerActive(true);
        blocks.SetActive(true);

        // �ŏ��̓��͂����Q�[���R���g���[���[����n��
        azarashi.Flap();

        // ���x�����X�V
        stateText.gameObject.SetActive(false);
        stateText.text = "";


    }

    void GameOver()
    {
        state = State.GameOver;

        // �V�[�����̂��ׂĂ�ScrollObject�R���|�[�l���g��T���o��
        ScrollObject[] scrollobjects =FindObjectsOfType<ScrollObject>();

        // �SScrollObject�̃X�N���[�������𖳌��ɂ���
        foreach (ScrollObject so in  scrollobjects) so.enabled = false;

        // ���x�����X�V
        stateText.gameObject.SetActive(true);
        stateText.text = "GameOver";
    }

    void Reload()
    {
        // ���ݓǂݍ���ł���V�[�����ēǂݍ���
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score : " + score;
    }

}
