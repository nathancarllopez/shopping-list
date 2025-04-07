using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Models;

namespace ShoppingListApi.Controllers
{
    [Route("api/FoodItems")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly FoodItemContext _context;

        public FoodItemsController(FoodItemContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItemDTO>>> GetFoodItems()
        {
            return await _context.FoodItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItemDTO>> GetFoodItem(long id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);

            if (foodItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(foodItem);
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(long id, FoodItemDTO foodDTO)
        {
            if (id != foodDTO.Id)
            {
                return BadRequest();
            }

            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            foodItem.Name = foodDTO.Name;
            foodItem.Quantity = foodDTO.Quantity;

            // _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FoodItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItemDTO>> PostFoodItem(FoodItemDTO foodDTO)
        {
            var foodItem = new FoodItem
            {
                Name = foodDTO.Name,
                Quantity = foodDTO.Quantity
            };

            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFoodItem), new { id = foodItem.Id }, ItemToDTO(foodItem));
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(long id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodItemExists(long id)
        {
            return _context.FoodItems.Any(e => e.Id == id);
        }

        private static FoodItemDTO ItemToDTO(FoodItem foodItem) => new FoodItemDTO
        {
            Id = foodItem.Id,
            Name = foodItem.Name,
            Quantity = foodItem.Quantity
        };
    }
}
