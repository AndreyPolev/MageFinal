using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform CamTrans;
    public Transform targetLook;    
    public LayerMask Mask;

    public float Sensitivity = 5f;
    public float TtitleAngle;
    private float _blindZone;

    void Start()
    {
        _blindZone = (CamTrans.position - transform.position).magnitude;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        TtitleAngle -= _mouseY * Sensitivity;
        TtitleAngle = Mathf.Clamp(TtitleAngle,-10f,90f);

        if(!PlayerSource.Instanse.Pause)
        {
            transform.localRotation = Quaternion.Euler(TtitleAngle,0,0);
        }

        TargetLook();
    }
    
    void TargetLook(){
        Ray _ray = new Ray(CamTrans.position+CamTrans.forward*_blindZone, CamTrans.forward*2000);
        RaycastHit _hit;
        
        if(Physics.Raycast(_ray, out _hit, Mask))
        {
            targetLook.position = Vector3.Lerp(targetLook.position,_hit.point, Time.deltaTime*40);
        }else
        {
            targetLook.position = Vector3.Lerp(targetLook.position,transform.forward*200, Time.deltaTime*5);
        }
    }
}
