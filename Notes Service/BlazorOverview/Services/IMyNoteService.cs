using BlazorOverview.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorOverview.Services
{
    public interface IMyNoteService
    {
        // 建立一筆新記事紀錄
        Task CreateAsync(MyNote myNote);
        // 刪除記事紀錄
        Task DeleteAsync(MyNote myNote);
        // 查詢所有記事紀錄
        Task<List<MyNote>> RetriveAsync();
        // 修改記事紀錄
        Task UpdateAsync(MyNote origMyNote, MyNote myNote);
    }
}