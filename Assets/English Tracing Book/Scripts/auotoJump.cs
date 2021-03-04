using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndieStudio.LetterWrite.Utility
{
    public class auotoJump : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            ShapesManagerLetter.shapesManagerReference = "bpmfShapesManager";
            StartCoroutine(SceneLoader.LoadSceneAsync("bpmfcaseAlbum"));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
