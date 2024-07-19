using UnityEngine;

namespace BuildingSystem
{
    public class BuildingPlacer : MonoBehaviour
    {
        [field:SerializeField]
        public BuildablesItems ActiveBuildable { get; private set; }

        [field:SerializeField]
        private float _maxBuildingDistance = 3f;

        [field:SerializeField]
        private ConstructionLayer _constructionLayer;

        
    }

}

