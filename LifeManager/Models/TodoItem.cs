using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
// Id, Title, Status
namespace LifeManager.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
    }
}
