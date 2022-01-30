using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Client.RealTime.Interfaces;
public interface IRealTimeConnectionManager<TEntity> where TEntity : Entity
{
    void AddConnection(TEntity entity, string connectionId);
    void RemoveConnection(string connectionId);
    HashSet<string> GetConnections(TEntity entity);
    ICollection<TEntity> ListOnlineUsers { get; }
}
