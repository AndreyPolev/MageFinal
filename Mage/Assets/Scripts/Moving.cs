using System.Collections;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody _Body;
    private Animator _Animator;
    private Vector3 _moveDirection;
    private Collider _collider;
    public Shooting Shooting;
    
    public float Speed = 5f;
    public float JumpForce = 10f;
    public float Sensitivity = 10f;
    public float Gravity = 9f;
    private bool _isShoot = false;
    private bool _isJump;
    

    void Start()
    {
        _Body = GetComponent<Rigidbody>();
        _Animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();

        Time.timeScale = 1;
        PlayerSource.Instanse.SetPause(false);
        
        _Body.freezeRotation = true;
        _Body.useGravity = false;
    }

    
    void Update()
    {
        float _forward = Input.GetAxis("Vertical");
        float _right = Input.GetAxis("Horizontal");

        bool _ground = Physics.Raycast(transform.position+Vector3.up,Vector3.down,1.5f);
        bool _jump = Input.GetButtonDown("Jump") && _ground && !_isJump;

        Vector3 rotation = new Vector3(0,Input.GetAxis("Mouse X"),0);

        _Animator.SetFloat("Horizontal", _right);
        _Animator.SetFloat("Vertical", _forward);
        _Animator.SetBool("Jump", _jump);

        

        if(_jump)
        {
            StartCoroutine("Jump");
        }

        _moveDirection = transform.forward * _forward+transform.right*_right;
        _moveDirection*=Speed;
        _Body.velocity = _moveDirection+Vector3.up * _Body.velocity.y;

        if(!PlayerSource.Instanse.Pause)
        {
            transform.Rotate(rotation*Sensitivity);
        }

        if(Input.GetButtonDown("Fire1")&& !_isShoot)
        {
            _isShoot = true;
            _Animator.SetTrigger("Shoot");
            Invoke("Shoot",1f);
        }

        if(Mathf.Abs(_forward) <= 0.3f&& Mathf.Abs(_right) <= 0.3f)
        {
            _collider.sharedMaterial.staticFriction=1f;
            _collider.sharedMaterial.frictionCombine = PhysicMaterialCombine.Maximum;
        }else
        {
            _collider.sharedMaterial.staticFriction=0f;
            _collider.sharedMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
        }

        _Body.AddForce(Vector3.up*-Gravity*_Body.mass*0.5f);
    }
    void Shoot()
    {
        Shooting.Shoot();
        _isShoot = false;
    }

    IEnumerator Jump()
    {
        float _curJump = JumpForce;
        float _prevGravity = Gravity;
        Gravity = 0.1f;
        _isJump = true;

        while (_curJump>0)
        {
            _Body.velocity += new Vector3(0,Mathf.Sqrt(_curJump)/2,0);
            _curJump -=1.5f;
            yield return new WaitForFixedUpdate();
        }    

        Gravity =_prevGravity;    
        _isJump = false;
    }
}
