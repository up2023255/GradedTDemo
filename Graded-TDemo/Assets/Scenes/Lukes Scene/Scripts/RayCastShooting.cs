using UnityEngine;
using CodeMonkey.Utils;

public class RayCastShooting : MonoBehaviour
{

    public float damage = 100f;
    public float range = 100f;
    public GameObject endPosition;

    [SerializeField] private Material rayMaterial;

    void Start()
    {
        endPosition = GameObject.Find("EndPosition");
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CreateRay(this.gameObject.transform.position, endPosition.transform.position);
            Debug.Log("Hi");
            Fire();
        }
    }

    void Fire ()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.right, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
        }

    }

    /*public void CreateRay (Vector3 fromPosition, Vector3 targetPosition)
    {
        Vector3 dir = (targetPosition - fromPosition).normalized;
        float eulerZ = UtilsClass.GetAngleFromVectorFloat(dir) -180;
        float distance = Vector3.Distance(fromPosition, targetPosition);
        Vector3 tracerSpawnPosition = fromPosition + dir * distance * .4f;
        World_Mesh worldMesh = World_Mesh.Create(tracerSpawnPosition, eulerZ, 6f, distance, rayMaterial, null, 10000);
    }*/
}
