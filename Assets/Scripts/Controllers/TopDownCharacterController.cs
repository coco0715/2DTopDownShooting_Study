using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHendler Stats { get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHendler>();
    }

    protected virtual void Update()
    {
        HendleAttackDelay();
    }

    private void HendleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
        {
            return;
        }

        if (_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        
        if(IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 diraction)
    {
        OnMoveEvent?.Invoke(diraction);
    }

    public void CallLookEvent(Vector2 diraction)
    {
        OnLookEvent?.Invoke(diraction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
// 이동 연습 코드
//[SerializeField] private float speed = 5f;
//// Start is called before the first frame update
//void Start()
//{

//}

//// Update is called once per frame
//void Update()
//{
//    float x = Input.GetAxisRaw("Horizontal");
//    float y = Input.GetAxisRaw("Vertical");

//    transform.position += new Vector3(x, y) * speed * Time.deltaTime;
//}

