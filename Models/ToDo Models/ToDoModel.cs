namespace PersonalWebsite.Models.ToDo_Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Item { get; set; } = string.Empty;
        public bool Complete { get; set; } = false;

        public ToDoModel(int id, string task)
        {
            Id = id;
            Item = task;
        }

        public void ToggleComplete()
        {
            Complete = !Complete;
        }
    }
}
