using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Data;
using Kanban.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kanban.Services
{
    public class BoardRepository : IBoardRepository
    {
        public enum ColumnEnum
        {
            ToDo = 1, Doing = 2, Done = 3
        }

        private readonly ApplicationDbContext _context;
        private readonly ILogger<BoardRepository> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public BoardRepository(ApplicationDbContext context, ILogger<BoardRepository> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<Board> GetBoardAsync(int boardId = 1)
        {
           
                return await _context.Boards.FirstAsync(x => x.Id == boardId);
        }

        public async Task<List<Item>> GetItemsByColumnAsync(ColumnEnum column)
        {
            return await _context.Items.Where(t => t.ColumnId == (int)column).ToListAsync();
        }

        async Task<List<Column>> IBoardGet.GetColumnsAsync(int boardId)
        {
            return await _context.Columns.Where(x => x.BoardId == (int) boardId).ToListAsync();
        }

        public int Create(Item item)
        {
            _context.Add(item);
            return _context.SaveChanges();
        }

        public async Task MoveItemAsync(int itemId, ColumnEnum column)
        {
            var toUpdate = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
            if (toUpdate != null)
            {
                toUpdate.ColumnId = _context.Columns.Find((int)column).Id;
                _context.SaveChanges();
            }
        }

        public bool DeleteItem(int itemId)
        {
            {
                Item item = _context.Items.Find(itemId);
                if (item is null)
                {
                    return false;
                }
                _context.Items.Remove(item);
                _context.SaveChanges();
            }

            return true;
        }
    }
}