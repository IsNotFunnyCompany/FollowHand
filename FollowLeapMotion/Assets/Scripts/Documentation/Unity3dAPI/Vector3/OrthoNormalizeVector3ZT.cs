using UnityEngine;
using System.Collections;

public class OrthoNormalizeVector3ZT : MonoBehaviour {

    public Vector3 Axis;
    public float fattore = 1.0f;

    private MeshFilter mf;
    private Vector3[] originalVerts;
    private Vector3[] newVerts;
    private Vector3 asseX;
    private Vector3 asseY;
    private Vector3 asseZ;

	void Start() 
    {

        mf = GetComponent<MeshFilter>();
        originalVerts = mf.mesh.vertices;
        newVerts = new Vector3[originalVerts.Length];
	
	}

	void Update() 
    {
        asseX = Axis;
        Vector3.OrthoNormalize(ref asseX,ref asseY,ref asseZ);
        Matrix4x4 newSpace = new Matrix4x4();

        newSpace.SetRow(0,asseX);
        newSpace.SetRow(1,asseY);
        newSpace.SetRow(2,asseZ);

        newSpace[3, 3] = 1.0f;

        Matrix4x4 scale = new Matrix4x4();
        scale[0, 0] = fattore;
        scale[1, 1] = 1.0f / fattore;
        scale[2, 2] = 1.0f / fattore;
        scale[3, 3] = 1.0f;

        Matrix4x4 fromNewSpace = newSpace.transpose;
        Matrix4x4 transitation = newSpace * scale * fromNewSpace;

        for(int i = 0; i < originalVerts.Length;i++ ) 
        {
            newVerts[i] = transitation.MultiplyPoint3x4(originalVerts[i]);
        }

        mf.mesh.vertices = newVerts;

	}
}
