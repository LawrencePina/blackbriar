﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Models;

namespace App1.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Alpha Male Strategies", Description="Are you a sleazeball?" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "AM1", Description="The sound of Oakland" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Angryman", Description="Witness the power" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Obsidian Radio", Description="The voice of the everyday brother" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Kevin Samuels", Description="Become a modern day savage." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "BGS IBMOR", Description="It is what it is." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}