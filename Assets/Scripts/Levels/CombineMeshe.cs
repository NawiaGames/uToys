using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMeshe : MonoBehaviour
{
    public void Combine()
    {
        var myTransform = transform;
        var position = myTransform.position;
        myTransform.position = Vector3.zero;
        
        var meshFilters = GetComponentsInChildren<MeshFilter>();
        var combine = new CombineInstance[meshFilters.Length];
        
        var i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }
        
        var meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = new Mesh()
        {
            indexFormat = UnityEngine.Rendering.IndexFormat.UInt32
        };
        meshFilter.mesh.CombineMeshes(combine);
        myTransform.gameObject.SetActive(true);
        
        myTransform.position = position;
    }
}
