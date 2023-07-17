using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PickImageFromGallery : MonoBehaviour
{
    public GameObject Object;
    public void onEnable()
    {
    }



    public void OpenGallery(Lean.Touch.LeanFinger obj)
    {
        PickImage(512);

    }



    public void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }



                // Assign texture to a temporary quad and destroy it after 5 seconds
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                quad.transform.forward = Camera.main.transform.forward;
                quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);



                Material material = quad.GetComponent<Renderer>().material;
                if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find("Legacy Shaders/Diffuse");



                //material.mainTexture = texture;
                //Object.GetComponent <Renderer>().material = material;



                Material newMat = Resources.Load("new_mat", typeof(Material)) as Material;
                Material matChange = Object.GetComponent<Renderer>().materials[1];
                matChange.mainTexture = texture;



            }
        });



        Debug.Log("Permission result: " + permission);
    }





}