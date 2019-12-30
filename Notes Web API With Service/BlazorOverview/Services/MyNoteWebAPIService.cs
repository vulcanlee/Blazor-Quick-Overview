using BlazorOverview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorOverview.Services
{
    public class MyNoteWebAPIService : IMyNoteService
    {
        public HttpClient Client { get; }

        // 使用建構式注入方式，注入 HttpClient 類別執行個體，以便可以呼叫 Web API
        public MyNoteWebAPIService(HttpClient httpClient)
        {
            Client = httpClient;
        }
        // 建立一筆新記事紀錄
        public async Task CreateAsync(MyNote myNote)
        {
            var content = JsonSerializer.Serialize(myNote);
            using (var stringContent = new StringContent(content, Encoding.UTF8, "application/json"))
            {
                await Client.PostAsync("/API/MyNote", stringContent);
            }
        }
        // 查詢所有記事紀錄
        public async Task<List<MyNote>> RetriveAsync()
        {
            var content = await Client.GetStringAsync("/API/MyNote");
            var allMyNotes = JsonSerializer.Deserialize<List<MyNote>>(content); ;
            return allMyNotes;
        }
        // 修改記事紀錄
        public async Task UpdateAsync(MyNote origMyNote, MyNote myNote)
        {
            var content = JsonSerializer.Serialize(myNote);
            using (var stringContent = new StringContent(content, Encoding.UTF8, "application/json"))
            {
                await Client.PutAsync($"/API/MyNote/{myNote.Id}", stringContent);
            }
        }
        // 刪除記事紀錄
        public async Task DeleteAsync(MyNote myNote)
        {
            await Client.DeleteAsync($"/API/MyNote/{myNote.Id}");
        }

    }
}
