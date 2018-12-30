using UnityEngine.Networking; 
using UnityEngine;

public class PlayerShoot : NetworkBehaviour
{

    private const string PLAYER_TAG = "Player";
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    LayerMask mask;

    void Start()
    {
        if(cam == null){
            Debug.LogError("No Camera Referenced");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    private void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward , out _hit, weapon.range, mask))
        {
            if(_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name);

            }
        }
    }

    [Command]
    void CmdPlayerShot (string _Id)
    {
        Debug.Log(_Id + "has been shot!");
    }
}
