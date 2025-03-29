namespace PersonalWebsite.Models.ToDo_Models
{
    public class ToDoList
    {
        public List<ToDoModel> ToDos { get; set; } = [];
        private int _NextId = 0;

        public void AddToDo(string Item)
        {
            ToDos.Add(new ToDoModel(_NextId, Item));
            _NextId++;
        }
        public void RemoveToDo(int id)
        {
            ToDos.Remove(ToDos.First(x => x.Id == id));
        }
        public void ToggleComplete(int id)
        {
            ToDos.First(x  => x.Id == id).ToggleComplete();
        }
    }
}
