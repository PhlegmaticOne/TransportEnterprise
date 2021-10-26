using System;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class LoadingResult<T> where T : BaseDomainModel
    {
        public LoadingResult(T loadedEntity, LoadingResultType loadingResultType)
        {
            LoadedEntity = loadedEntity;
            LoadingResultType = loadingResultType;
        }
        public T LoadedEntity { get; }
        public LoadingResultType LoadingResultType { get; }
        public override string ToString() => string.Format("{0}. {1}", LoadingResultType, LoadedEntity);
    }
    public enum LoadingResultType
    {
        Succesfull,
        EntityNotFound
    }
}
