using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    public class JSONTaskContext:ITaskContext
    {
        public Task<bool> InsertCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> FindCategoryNames()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertNewTask(string taskName, string catName, string index)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> FindTaskNamesByTab(string catName, string index)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTask(string catName, string taskName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TaskStatus(string catName, string taskName, string tag)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTaskID(string catName, string taskName)
        {
            throw new NotImplementedException();
        }

        public Task<Task> GetTasksDetails(string catName, string taskName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges(string taskBody, string taskName, string catName)
        {
            throw new NotImplementedException();
        }

        public Task<string> CheckStatus(string catName, string taskName)
        {
            throw new NotImplementedException();
        }
    }
}
