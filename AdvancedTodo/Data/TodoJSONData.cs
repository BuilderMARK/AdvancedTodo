using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AdvancedTodo.Models;

namespace AdvancedTodo.Data
{
    public class TodoJSONData : IToDoData
    {
        private string todoFile = "todos.json";
        private IList<ToDo> todos;

        public TodoJSONData()
        {
            if (!File.Exists(todoFile))
            {
                Seed();
                writeTodosToFile();
            }
            else
            {
                string content = File.ReadAllText(todoFile);
                todos = JsonSerializer.Deserialize<List<ToDo>>(content);
            }
        }

        private void Seed()
        {
            ToDo[] ts =
            {
                new ToDo {UserId = 1, TodoId = 1, Title = "Do dishes", IsCompleted = false},
                new ToDo {UserId = 1, TodoId = 2, Title = "Walk the dog", IsCompleted = false},
                new ToDo {UserId = 2, TodoId = 3, Title = "Do DNP homework", IsCompleted = true},
                new ToDo {UserId = 3, TodoId = 4, Title = "Eat breakfast", IsCompleted = false},
                new ToDo {UserId = 4, TodoId = 5, Title = "Mow lawn", IsCompleted = true},
                new ToDo {UserId = 1, TodoId = 1, Title = "Do dishes", IsCompleted = false},
                new ToDo {UserId = 1, TodoId = 2, Title = "Walk the dog", IsCompleted = false},
                new ToDo {UserId = 2, TodoId = 3, Title = "Do DNP homework", IsCompleted = true},
                new ToDo {UserId = 3, TodoId = 4, Title = "Eat breakfast", IsCompleted = false},
                new ToDo {UserId = 4, TodoId = 5, Title = "Mow lawn", IsCompleted = true},
            };
            todos = ts.ToList();
        }

        public IList<ToDo> GetTodos()
        {
            List<ToDo> tmp = new List<ToDo>(todos);
            return tmp;
        }

        public void AddTodo(ToDo todo)
        {
            todo.TodoId = todos.Max(t => t.TodoId) + 1;
            todos.Add(todo);
            writeTodosToFile();
        }

        private void writeTodosToFile()
        {
            string todoAsJson = JsonSerializer.Serialize(todos);
            File.WriteAllText(todoFile, todoAsJson);
        }

        public void RemoveTodo(int todoId)
        {
            ToDo toRemove = todos.First(t => t.TodoId == todoId);
            todos.Remove(toRemove);
           writeTodosToFile();
        }
        public void Update(ToDo todo)
        {
            ToDo toUpdate = todos.First(t => t.TodoId == todo.TodoId);
            toUpdate.IsCompleted = todo.IsCompleted;
            toUpdate.Title = todo.Title;
            writeTodosToFile();
        }

        public ToDo Get(int id)
        {
            return todos.FirstOrDefault(t => t.TodoId == id);
        }
        

    }
}