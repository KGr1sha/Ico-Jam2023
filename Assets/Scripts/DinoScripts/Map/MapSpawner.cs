using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using DinoScripts.ResourceManagementSystem;

namespace DinoScripts.Map

{
    public class MapSpawner : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TemplatesLoader templatesLoader;

        [Header("Settings")]
        [Tooltip("Map parent transform.")]
        [SerializeField] private Transform templateParentTransform;
        
        [Tooltip("Templates count on scene in one moment.")]
        [SerializeField] private int templatesPoolSize;

        [Tooltip("Template Size.")]
        [SerializeField] private Vector3 templateSize;

        [Tooltip("Templates on scene.")]
        [SerializeField] private List<GameObject> spawnedTemplates;

        private void Update()
        {
            if (this.spawnedTemplates.Count < this.templatesPoolSize)
            {
                SpawnTemplate();
            }
        }
        private void Awake()
        {
            if (this.templatesLoader == null) this.templatesLoader = GetComponent<TemplatesLoader>();
        }

        public void SpawnTemplate()
        {
            GameObject template = this.templatesLoader.GetRandomTemplate();
            GameObject spawnedTemplate = Instantiate(template, this.templateParentTransform);

            GameObject lastSpawnedTemplate = this.spawnedTemplates.Last();
            Vector3 lastSpawnedTemplatePosition = lastSpawnedTemplate.transform.localPosition;
            Vector3 templatePosition = lastSpawnedTemplatePosition + this.templateSize;

            spawnedTemplate.transform.localPosition = templatePosition;
            this.spawnedTemplates.Add(spawnedTemplate);

        }
        public void DeleteTemplate(GameObject template)
        {
            this.spawnedTemplates.Remove(template);
            Destroy(template);
        }    
    }
}
