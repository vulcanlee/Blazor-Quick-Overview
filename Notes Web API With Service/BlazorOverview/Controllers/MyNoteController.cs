using BlazorOverview.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOverview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyNoteController : ControllerBase
    {
        public MyNoteDbContext MyNoteDbContext { get; }

        public MyNoteController(MyNoteDbContext myNoteDbContext)
        {
            MyNoteDbContext = myNoteDbContext;
        }

        [HttpGet]
        public IEnumerable<MyNote> Get()
        {
            return MyNoteDbContext.MyNotes.ToList();
        }

        [HttpGet("{id}", Name = "Get")]
        public MyNote Get(int id)
        {
            return MyNoteDbContext.MyNotes.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] MyNote myNote)
        {
            MyNoteDbContext.MyNotes.Add(myNote);
            MyNoteDbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MyNote myNote)
        {
            MyNote NoteItem = MyNoteDbContext.MyNotes.FirstOrDefault(x => x.Id == id);
            NoteItem.Title = myNote.Title;
            MyNoteDbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MyNoteDbContext.MyNotes.Remove(MyNoteDbContext.MyNotes.FirstOrDefault(x => x.Id == id));
            MyNoteDbContext.SaveChanges();
        }
    }
}
