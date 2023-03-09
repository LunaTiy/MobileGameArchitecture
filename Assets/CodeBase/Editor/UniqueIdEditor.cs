using System;
using System.Linq;
using CodeBase.Logic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueId = (UniqueId)target;

            if (IsPrefab(uniqueId))
                return;
            
            if(string.IsNullOrEmpty(uniqueId.id))
            {
                Generate(uniqueId);
            }
            else
            {
                UniqueId[] uniqueIds = FindObjectsOfType<UniqueId>();
                
                if(uniqueIds.Any(other => other != uniqueId && other.id == uniqueId.id))
                    Generate(uniqueId);
            }
        }

        private bool IsPrefab(UniqueId uniqueId) => 
            uniqueId.gameObject.scene.rootCount == 0;

        private void Generate(UniqueId uniqueId)
        {
            var currentScene = uniqueId.gameObject.scene;
            uniqueId.id = $"{currentScene.name}_{Guid.NewGuid().ToString()}";
            
            if (Application.isPlaying)
                return;
            
            EditorUtility.SetDirty(uniqueId);
            EditorSceneManager.MarkSceneDirty(currentScene);
        }
    }
}