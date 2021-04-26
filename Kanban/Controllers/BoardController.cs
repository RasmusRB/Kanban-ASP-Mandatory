using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kanban.Data;
using Kanban.Models;
using Kanban.Services;
using Kanban.VMs;
using Column = Kanban.Models.Column;

namespace Kanban.Controllers
{
    public class BoardController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly IBoardRepository _repo;

            public BoardController(ApplicationDbContext context, IBoardRepository repo)
            {
                _context = context;
                _repo = repo;
            }

            // returns board vm
            public async Task<IActionResult> Index()
            {
                Board board = await _repo.GetBoardAsync(1);
                List<Column> columns = await _repo.GetColumnsAsync(board.Id);
                List<Item> todoItems = await _repo.GetItemsByColumnAsync(BoardRepository.ColumnEnum.ToDo);
                List<Item> doingItems = await _repo.GetItemsByColumnAsync(BoardRepository.ColumnEnum.Doing);
                List<Item> doneItems = await _repo.GetItemsByColumnAsync(BoardRepository.ColumnEnum.Done);

                BoardVm vM = new BoardVm()
                {
                    Board = board,
                    Columns = columns,
                    ToDoItem = todoItems,
                    DoingItem = doingItems,
                    DoneItem = doneItems
                };

                return View(vM);
            }

            // deletes item from id
        public IActionResult DeleteItem(int itemId)
            {
                Item boardItem = _context.Items.Find(itemId);
                if (boardItem == null)
                {
                    return NotFound();
                }
                return View(boardItem);
            }

        // moves item
            public async Task<IActionResult> MoveItem(int itemId, int columnId)
            {
                await _repo.MoveItemAsync(itemId, (BoardRepository.ColumnEnum)columnId);
                return RedirectToAction(nameof(Index));
            }
        }
    }

