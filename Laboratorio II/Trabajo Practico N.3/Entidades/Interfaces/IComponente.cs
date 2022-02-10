namespace Entidades.Interfaces
{
    public interface IComponente<T> where T: ComponenteElectronico
    {
        public bool EsOvercockleable(T obj);
        public string DetallesTecnicos();
    }
}
