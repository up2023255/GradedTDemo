using UnityEngine;
using CodeMonkey.Utils;

public class RayCastShooting : MonoBehaviour
{

    public float damage = 100f;
    public float range = 100f;
    public GameObject wallTrap;
    private Animator anim;
    bool settingUp = false;


    [SerializeField] private Material rayMaterial;

    void Start()
    {
        wallTrap = GameObject.Find("WallTrap");
        anim = wallTrap.GetComponent<Animator>();
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (settingUp == false && other.gameObject.CompareTag("Player"))
        {
            anim.Play("DangerZone");
            settingUp = true;
            Debug.Log("Hi");
            Invoke("Fire", 2f);
        }
    }

    void Fire()
    {
        anim.Play("Attack");
        settingUp = false;
        // check if player is within the bounds then deal damage.
    }

    

    /*public void CreateRay (Vector3 fromPosition, Vector3 targetPosition)
    {
        Vector3 dir = (targetPosition - fromPosition).normalized;
        float eulerZ = UtilsClass.GetAngleFromVectorFloat(dir) -180;
        float distance = Vector3.Distance(fromPosition, targetPosition);
        Vector3 tracerSpawnPosition = fromPosition + dir * distance * .4f;
        World_Mesh worldMesh = World_Mesh.Create(tracerSpawnPosition, eulerZ, 6f, distance, rayMaterial, null, 10000);

    CreateRay(this.gameObject.transform.position, endPosition.transform.position);

    RaycastHit hit;
        if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.right, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
        }
    }*/
}
