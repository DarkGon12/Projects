using UnityEngine;

namespace Scripts.ResourceManager
{
    public static class ResourceSimplificator
    {
        private const string rePath = "Prefabs/";

        public static Object Instantiate(string path)
        {
            return Object.Instantiate(Resources.Load(rePath + path, typeof(GameObject))) as GameObject;
        }

        public static Object Instantiate(string path, Vector3 position)
        {
            return Object.Instantiate(Resources.Load(rePath + path, typeof(GameObject)), position, Quaternion.identity) as GameObject;
        }

        public static Object Instantiate(string path, Vector3 position, Quaternion quaternion)
        {
            return Object.Instantiate(Resources.Load(rePath + path, typeof(GameObject)), position, quaternion) as GameObject;
        }
    }
}