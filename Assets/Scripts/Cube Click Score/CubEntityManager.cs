using System;
using System.Collections.Generic;
using LTX.Singletons;

namespace Taho.Game
{
    public class CubeEntityManager : MonoSingleton<CubeEntityManager>
    {
        public event Action OnCubeEntityCleared;
        
        private List<CubeEntity> currentCubeEntities;
        protected override void Awake()
        {
            base.Awake();
            currentCubeEntities = new List<CubeEntity>();
        }

        public void AddCubeEntity(CubeEntity cubeEntity)
        {
            currentCubeEntities.Add(cubeEntity);
        }
        public void RemoveCubeEntity(CubeEntity cubeEntity)
        {
            currentCubeEntities.Remove(cubeEntity);
            Destroy(cubeEntity.gameObject);

            if (currentCubeEntities.Count <= 0)
            {
                OnCubeEntityCleared?.Invoke();
            }
        }
    }
}