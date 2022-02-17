namespace SchoolApp.Client.RealTime.Hubs.Interface;
public interface IRealTimeHub
{
    Task SendToAll(object[] entities);
    Task UpdateToAll(object entities);
    Task DeleteToAll(object entities);
    Task SendToSpecifiOnes(object entities, IList<string> specificUsersIds);
    IList<string> GetConnectedUsersList();

}
