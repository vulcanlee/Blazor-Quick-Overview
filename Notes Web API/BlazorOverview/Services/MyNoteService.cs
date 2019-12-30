using BlazorOverview.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOverview.Services
{
    public class MyNoteService : IMyNoteService
    {
        // 記事清單的私有欄位物件
        List<MyNote> MyNotes { get; set; }
        public MyNoteService()
        {
            // 預設建立的集合清單紀錄
            MyNotes = new List<MyNote>()
            {
                new MyNote { Title= "買芭樂" },
                new MyNote { Title= "買蘋果" },
                new MyNote { Title="買西瓜" }
            };
        }
        // 建立一筆新記事紀錄
        public Task CreateAsync(MyNote myNote)
        {
            MyNotes.Add(myNote);
            // 因為這裡都是使用同步呼叫，所以需要回傳一個工作物件
            return Task.FromResult(0);
        }
        // 查詢所有記事紀錄
        public Task<List<MyNote>> RetriveAsync()
        {
            // 因為這裡都是使用同步呼叫，所以需要回傳一個工作物件
            return Task.FromResult(MyNotes);
        }
        // 修改記事紀錄
        public Task UpdateAsync(MyNote origMyNote, MyNote myNote)
        {
            MyNotes.FirstOrDefault(x => x.Title == origMyNote.Title).Title = myNote.Title;
            // 因為這裡都是使用同步呼叫，所以需要回傳一個工作物件
            return Task.FromResult(0);
        }
        // 刪除記事紀錄
        public Task DeleteAsync(MyNote myNote)
        {
            MyNotes.Remove(MyNotes.FirstOrDefault(x => x.Title == myNote.Title));
            // 因為這裡都是使用同步呼叫，所以需要回傳一個工作物件
            return Task.FromResult(0);
        }
    }
}
