
using Grupo4.Models;

namespace Grupo4.Services
{
    public class RegistroExportacionService
    {
        private readonly List<InspeccionTemporal> _inspecciones = new();
        private readonly List<PackingList> _packingLists = new();

        public IReadOnlyList<InspeccionTemporal> ObtenerInspecciones()
        {
            return _inspecciones.AsReadOnly();
        }

        public void RegistrarInspeccion(InspeccionTemporal inspeccion)
        {
            _inspecciones.RemoveAll(x =>
                x.IdInspeccion == inspeccion.IdInspeccion);

            _inspecciones.Add(inspeccion);
        }

        public IReadOnlyList<PackingList> ObtenerPackingLists()
        {
            return _packingLists.AsReadOnly();
        }

        public void RegistrarPackingList(PackingList packingList)
        {
            _packingLists.RemoveAll(x =>
                x.IdPackingList == packingList.IdPackingList);

            _packingLists.Add(packingList);
        }
    }
}
