using System.Threading.Tasks;
using Kanban.Models;

namespace Kanban.Services
{
    public interface IBoardRepository : IBoardGet
    {
        int Create(Item item);
        Task MoveItemAsync(int itemId, BoardRepository.ColumnEnum column);
        bool DeleteItem(int itemId);
    }
}
