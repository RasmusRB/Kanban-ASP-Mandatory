using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    public class Board
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string BoardName { get; set; }
        #endregion

        #region ToString method
        // overrides the Kanban.Model string displayed on views
        public override string ToString()
        {
            return BoardName;
        }
        #endregion
    }
}
