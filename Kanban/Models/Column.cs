namespace Kanban.Models
{
    public class Column
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; }
        #endregion

        #region Ctor
        public Column(int id, string title, int boardId)
        {
            Id = id;
            Title = title;
            BoardId = boardId;
        }
        #endregion
    }
}
