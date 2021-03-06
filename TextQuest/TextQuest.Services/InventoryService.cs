﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuest.Data;

namespace TextQuest.Services
{
    public class InventoryService :IInventory
    {
        private TextQuestDbContext _context;

        public Inventory GetInventory(int id)
        {
            return _context.Inventories
                .FirstOrDefault(s => s.Id == id);
        }

        public InventoryService(TextQuestDbContext context)
        {
            _context = context;
        }

        public void Add(Inventory inventory)
        {
            _context.Add(inventory);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(GetInventory(id));
            _context.SaveChanges();
        }

        
       
    }
}
