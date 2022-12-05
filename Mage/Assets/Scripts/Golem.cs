using UnityEngine;

public class Golem : MonoBehaviour
{
    private Animator _animator;
    private Collider _target;
    public LayerMask mask;

    public float Speed = 3f;
    public float Damage = 15f;
    public float ViewRadius = 5f;
    public float Health = 100f;

    public bool IsRun;
    private bool _stop;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Collider[] players = Physics.OverlapSphere(transform.position, ViewRadius, mask);
        if(players.Length !=0)
        {
            IsRun = true;
            _target = players[0];
        }else
        {
            IsRun = false;
            _target = null;
        }
        _animator.SetBool("isRun", IsRun);
        if(IsRun)
        {
            Chase();
        }     
    }

    void Chase()
    {
        if(!_stop)
        {
            Vector3 movedire = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);

            transform.LookAt(movedire);
            transform.position+=transform.forward*Speed*Time.deltaTime;

            float distance = (transform.position - _target.transform.position).magnitude;
            if(distance<1.6f)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        _stop = true;
        _animator.SetTrigger("Attack");
        Invoke("StopOn",1.5f);

    }

    void StopOn()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position,1.5f,mask);
        foreach (Collider target in targets)
        {
        target.GetComponent<PlayerSource>().TakeDamage(Damage);
        }
        _stop = false;
    }

    public void TakeDamage (float Damage)
    {
        Health -= Damage;
        if(Health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        _stop = true;
        _animator.SetTrigger("Death");
        Destroy(gameObject,4f);
    }
}
