using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


    public class SelectGameObjectByScripts
    {
        [MenuItem("Tools/选中带脚本的物体", false, priority = 22)]
        private static void SelectScriptObj()
        {
            var mono = Selection.activeObject as MonoScript;
            if (mono.GetClass() == null || !typeof(MonoBehaviour).IsAssignableFrom(mono.GetClass()))
                return;
            var g = new List<GameObject>(Object.FindObjectsOfType<GameObject>());
            g.RemoveAll(item => !item.GetComponent(mono.GetClass()));
            Selection.objects = g.ToArray();
        }


        [MenuItem("Tools/选中带脚本的物体", true)]
        private static bool VSelectScriptObj()
        {
            return (Selection.activeObject) ? Selection.activeObject is MonoScript : false;
        }
    }
