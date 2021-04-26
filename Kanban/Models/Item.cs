using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class Item
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Notes { get; set; }
        public int ColumnId { get; set; }
        public Column Column { get; set; }
        #endregion

        #region ToString method
        // overrides the Kanban.Model string displayed on views
        public override string ToString()
        {
            return Title;
        }
        #endregion
    }
}
