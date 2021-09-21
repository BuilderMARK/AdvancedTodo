using System.Collections;
using System.Collections.Generic;
using AdvancedTodo.Models;

namespace AdvancedTodo.Data
{
    public interface IToDoData
    {
        IList<ToDo> GetTodos();
        void AddTodo(ToDo todo);
        void RemoveTodo(int todoId);
        void Update(ToDo todo);
        ToDo Get(int id);
    }
}