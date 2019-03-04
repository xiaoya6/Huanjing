using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// 是否左移动，反之向右
    /// </summary>
    private bool isMoveLeft = false;
    private bool isJumping;
    private Vector3 nextPlatformLeft, nextPlatformRight;
    private ManagerVars vars;
    private void Awake()
    {
        vars = ManagerVars.GetManagerVars();
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameStart == false || GameManager.Instance.isGameOver) {
            return;
        }

        if (Input.GetMouseButtonDown(0) && isJumping == false)
        {
            EventCenter.Broadcast(EventDefine.DecidePath);
            Vector3 mousePos = Input.mousePosition;

            if (mousePos.x < Screen.width / 2)
            {
                isMoveLeft = true;
            }
            else if (mousePos.x > Screen.width / 2)
            {
                isMoveLeft = false;

            }
            isJumping = true;
            Jump();

        }
    }

    private void Jump() {
        if (isMoveLeft)
        {
            transform.localScale = new Vector3(-1,1,1);
            transform.DOMoveX(nextPlatformLeft.x, 0.2f);
            transform.DOMoveY(nextPlatformLeft.y+0.8f, 0.15f);

        }
        else {
            transform.localScale = Vector3.one;
            transform.DOMoveX(nextPlatformRight.x, 0.2f);
            transform.DOMoveY(nextPlatformRight.y + 0.8f, 0.15f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform") {
            isJumping = false;
            Vector3 currentPlatformPos = collision.gameObject.transform.position;
            nextPlatformLeft = new Vector3(currentPlatformPos.x - vars.nextXpos, currentPlatformPos.y + vars.nextYpos, 0);
            nextPlatformRight = new Vector3(currentPlatformPos.x + vars.nextXpos, currentPlatformPos.y + vars.nextYpos, 0);

        }
    }
}
