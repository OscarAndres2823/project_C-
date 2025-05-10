using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.application.Ports;

public interface ITerceroRepository
{
    void Create(Tercero tercero);
    List<Tercero> GetAll();
    void Update(Tercero tercero);
    void Delete(int id);
}
