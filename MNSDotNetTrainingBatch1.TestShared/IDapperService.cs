
namespace MNSDotNetTrainingBatch1.TestShared
{
    public interface IDapperService
    {
        int Execute(string query, object? parameters = null);
        List<T> Query<T>(string query, object? parameters = null);
    }
}