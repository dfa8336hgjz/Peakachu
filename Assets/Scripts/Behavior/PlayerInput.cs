using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public enum Side { Left, Right };
public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;
    [SerializeField] GameObject lightning;
    [SerializeField] GameObject quickAttack;
    private Animator _animator;
    private float x1, x2;
    private Side side;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if( _animator != null && !GameControl.instance.quickAttackActivated())
        {
            AnimatorClipInfo[] clipInfos = _animator.GetCurrentAnimatorClipInfo(0);
            string clipname = clipInfos[0].clip.name;
            lightning.SetActive(clipname.Contains("Pikachu_JumpFrom"));
#if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                x1 = Input.mousePosition.x;
            }
            if (Input.GetMouseButtonUp(0))
            {
                x2 = Input.mousePosition.y;
                if (Mathf.Abs(x1-x2) > 10.0f)
                {
                    if (x1 > x2 && clipname.Contains("Pikachu_RunningRight"))
                    {
                        _animator.SetTrigger("Jump");
                        lightning.SetActive(true);
                        side = Side.Left;
                    }
                    else if (x1 < x2 && clipname.Contains("Pikachu_RunningLeft"))
                    {
                        _animator.SetTrigger("Jump");
                        lightning.SetActive(true);
                        side = Side.Right;
                    }
                }
            }
#elif UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    x1 = touch.position.x;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    x2 = touch.position.x;
                    if (Mathf.Abs(x1-x2) > 10.0f)
                    {
                        if (x1 > x2 && clipname.Contains("Pikachu_RunningRight"))
                        {
                            _animator.SetTrigger("Jump");
                            lightning.SetActive(true);
                            side = Side.Left;
                        }
                        else if (x1 < x2 && clipname.Contains("Pikachu_RunningLeft"))
                        {
                            _animator.SetTrigger("Jump");
                            lightning.SetActive(true);
                            side = Side.Right;
                        }
                    }
                }
            }
#endif
        }
    }

    public bool isLeftSide()
    {
        return side == Side.Left;
    }

    public int getTransformDirection()
    {
        if (side == Side.Left)
        {
            return -1;
        }
        else return 1;
    }

    public void setSkillActivate(bool active)
    {
        quickAttack.SetActive(active);
        lightning.SetActive(!active);
    }
}
