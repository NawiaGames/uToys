using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class MeshScaler : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter = null;
    [SerializeField] Vector3 tiledSize = Vector3.zero;
    Vector3[] originalMeshVerts; 
    private void Awake() {
        originalMeshVerts = meshFilter.mesh.vertices;
    }

    public void SetMeshSize(Vector3 size) => SetMeshSize(size.x, size.y, size.z);
    public void SetMeshSize(Vector3 size, Vector3 borderSize) => SetMeshSize(size.x, size.y, size.z, borderSize.x, borderSize.y, borderSize.z);
    public void SetMeshSize(float sizeX, float sizeY, float sizeZ, float borderSizeX = 0f, float borderSizeY = 0f, float borderSizeZ = 0f)
    {
        var modifiedVerts = new Vector3[originalMeshVerts.Length];

        for (var i = 0; i < originalMeshVerts.Length; i++)
            modifiedVerts[i] = MoveVert(originalMeshVerts[i], sizeX, sizeY, sizeZ, borderSizeX, borderSizeY, borderSizeZ);

       meshFilter.mesh.vertices = modifiedVerts;        
    }

    Vector3 MoveVert(Vector3 v, float offsetX, float offsetY, float offsetZ, float borderSizeX, float borderSizeY, float borderSizeZ)
    {
        return v += new Vector3(
            (v.x > 0 ? offsetX - borderSizeX : -offsetX + borderSizeX),
            (v.y > 0 ? offsetY - borderSizeY : -offsetY + borderSizeY),
            (v.z > 0 ? offsetZ - borderSizeZ : -offsetZ + borderSizeZ)
        );
    }
}
