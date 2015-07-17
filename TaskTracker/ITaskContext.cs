using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    public interface ITaskContext
    {
        Task<bool> InsertCategory(string categoryName);

        Task<bool> DeleteCategory(string categoryName);

        Task<List<string>> FindCategoryNames();

        Task<bool> InsertNewTask(string taskName, string catName, string index);

        Task<List<string>> FindTaskNamesByTab(string catName, string index);

        Task<bool> DeleteTask(string catName, string taskName);

        Task<bool> TaskStatus(string catName, string taskName, string tag);

        Task<string> GetTaskID(string catName, string taskName);

        Task<Task> GetTasksDetails(string catName, string taskName);

        Task<bool> SaveChanges(string taskBody, string taskName, string catName);

        Task<string> CheckStatus(string catName, string taskName);
    }
}
