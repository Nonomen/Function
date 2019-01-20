using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawImageText : MonoBehaviour {
    public List<Vector3> allPoints;
    public Vector3 tmpView;
    void Start () {
        
	}
    
	void Update () {
        if (Input.GetMouseButton(0)) {
            tmpView = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            allPoints.Add(tmpView);
        }
        if (Input.GetMouseButtonUp(0)) {
            GenerateText();
            allPoints.Clear();
            Invoke("Show", 2f);
        }
	}
    public GameObject End;
    void Show() {
        End.SetActive(true);
    }
    Texture2D paintText;
    public void GenerateText() {
        paintText = new Texture2D(300, 400);

        for (int i = 1; i < allPoints.Count; i++) {
            Vector3 tmpFront = allPoints[i - 1];
            Vector3 tmpBack = allPoints[i];
            float fountX = paintText.width * tmpFront.x;
            float fountY = paintText.height * tmpFront.y;
            float backX = paintText.width * tmpBack.x;
            float backY = paintText.height * tmpBack.y;

            for (int j = 0; j < 100; j++) {
                int tmpXX = (int)(Mathf.Lerp(fountX, backX, j / 100.0f));
                int tmpYY = (int)(Mathf.Lerp(fountY, backY, j / 100.0f));
                paintText.SetPixel(tmpXX, tmpYY, Color.red);
            }

        }
        paintText.Apply();
        transform.GetComponent<Renderer>().material.mainTexture = paintText;
    }


    // When added to an object, draws colored rays from the
    // transform position.
    public int lineCount = 100;
    public float radius = 3.0f;

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        //GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        //GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.LoadOrtho();
        GL.Begin(GL.LINES);

        GL.Color(Color.red);
        


        for (int i = 1;i < allPoints.Count; i++) {
            Vector3 tmpFront = allPoints[i - 1];
            Vector3 tmpBack = allPoints[i];

            GL.Vertex3(tmpFront.x, tmpFront.y, tmpFront.z);
            GL.Vertex3(tmpBack.x, tmpBack.y, tmpFront.z);
        }
        //for (int i = 0; i < lineCount; ++i)
        //{
        //    float a = i / (float)lineCount;
        //    float angle = a * Mathf.PI * 2;
        //    // Vertex colors change from red to green
        //    GL.Color(new Color(a, 1 - a, 0, 0.8F));
        //    // One vertex at transform position
        //    GL.Vertex3(0, 0, 0);
        //    // Another vertex at edge of circle
        //    GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
        //}
        GL.End();
        //GL.PopMatrix();
    }
}
