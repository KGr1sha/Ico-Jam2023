using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DinoScripts.ResourceManagementSystem
{
    public class TemplatesLoader : MonoBehaviour
    {
        [Header("Settings")]

        [Tooltip("Loaded templates.")]
        [SerializeField] private List<GameObject> loadedTemplates;

        [Tooltip("Templates folder name in resources.")]
        [SerializeField] private string templatesFolderName;

        [Tooltip("Template name prefix.")]
        [SerializeField] private string templatePrefix;

        [Tooltip("Templates count in resources folder.")]
        [SerializeField] private int templateCount;

        public GameObject GetRandomTemplate()
        {
            int templateId = Random.Range(1, this.templateCount);
            string templateName = this.templatePrefix + templateId;
            if (this.loadedTemplates.Exists(match: GameObject => GameObject.name == templateName))
            {
                GameObject template = this.loadedTemplates.Find(match: GameObject => GameObject.name == templateName);
                return template;
            }
            string templateResourcePath = Path.Combine(this.templatesFolderName, templateName);
            GameObject loadedTemplate = Resources.Load<GameObject>(templateResourcePath);
            //Debug.Log(message: (templateResourcePath + "/" + templateName));
            this.loadedTemplates.Add(loadedTemplate);
            return loadedTemplate;
        }
    }
}
