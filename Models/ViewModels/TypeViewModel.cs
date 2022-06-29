using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using wow.Models;

namespace wow.Models.ViewModels
{
    public class TypeViewModel
    {
        public Type Type { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public IEnumerable<SelectListItem> selectListItem(IEnumerable<Item> Items)
        {
             
             List<SelectListItem> ItemList = new List<SelectListItem>();
             SelectListItem sli = new SelectListItem()
             {
                Text = "Select Item", 
                Value = "0"

             };
             
             ItemList.Add(sli);
             foreach(Item item in Items)
             {
                sli = new SelectListItem()
             {
                Text = item.Name,
                Value = item.Id.ToString()

             };

               ItemList.Add(sli);
             }
             return ItemList;

        }
    }
    
 }