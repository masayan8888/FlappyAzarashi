using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    GameObject gameController;

    void Start()
    {
        // �Q�[���J�n����GameController��Find���Ă���
        gameController = GameObject.FindWithTag("GameController");
    }

    // �g���K�[����Exit������N���A�Ƃ݂Ȃ�
    void OnTriggerExit2D(Collider2D other)
    {
        gameController.SendMessage("IncreaseScore");
    }

}
