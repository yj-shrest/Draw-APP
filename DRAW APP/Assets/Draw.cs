using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{   
    [SerializeField]
    GameObject pointPrefab1,pointPrefab2;
    List<GameObject> ls = new List<GameObject>();


    public static string tool="pencil";
    public static float zvalue = 9f;
    void Update()
    {
     draw();  
    }
    
    void draw()
    {  

        if(Input.GetKey(KeyCode.Mouse0))
        {

        if(tool=="pencil")
            {
            Vector3 mpos = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,zvalue);
            Vector3 pos = Camera.main.ScreenToWorldPoint(mpos);
            GameObject point = Instantiate(pointPrefab1);
            ls.Add(point);
            point.transform.localPosition = pos;
            }
            if(tool=="eraser")
            {
            Vector3 mpos = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,zvalue);
            Vector3 pos = Camera.main.ScreenToWorldPoint(mpos);
            GameObject point = Instantiate(pointPrefab2);
            point.transform.localPosition = pos;
            ls.Add(point);
            }
            if(tool=="clear")
            {
                foreach (GameObject point in ls)
                {
                    Destroy(point);
                }
                StartCoroutine(Delay());
                

            }
        
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        tool="pencil";
    }
     /*IEnumerator ss()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,false);
        texture.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);
        texture.Apply();
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/img.png",bytes);
        
        Destroy(texture);
        }

        public void takess()
    {
        StartCoroutine(ss());
    }*/

}
