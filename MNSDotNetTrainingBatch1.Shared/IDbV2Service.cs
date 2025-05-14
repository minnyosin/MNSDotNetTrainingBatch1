
namespace MNSDotNetTrainingBatch1.Shared
{
    public interface IDbV2Service
    {
        int Execute(string query, object? parameters = null);
        List<T> Query<T>(string query, object? parameters = null);
    }
}