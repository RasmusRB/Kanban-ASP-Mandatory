using System.Collections.Generic;
using System.Threading.Tasks;
using Kanban.Models;

namespace Kanban.Services
{
    public interface IBoardGet
    {
        Task<Board> GetBoardAsync(int boardId);
        Task<List<Item>> GetItemsByColumnAsync(BoardRepository.ColumnEnum columnId);
        Task<List<Column>> GetColumnsAsync(int boardId);
    }
}
