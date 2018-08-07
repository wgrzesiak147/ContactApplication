using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ContactApplication.Interfaces.Model;
using ContactApplication.Remote.Interfaces;
using Newtonsoft.Json;

namespace ContactApplication.Remote.Services
{
    public class ContactService : IContactService
    {
        protected readonly HttpClient HttpClient = new HttpClient();
        private readonly string _apiUrl = "http://localhost:63346/api/contact";


        public async Task<IEnumerable<ContactDto>> ReadAsync()
        {
            var stream = await HttpClient.GetStringAsync(_apiUrl);
            return JsonConvert.DeserializeObject<List<ContactDto>>(stream);
        }

        public async void AddAsync(ContactDto contact)
        {
            var response = await HttpClient.PostAsync(_apiUrl, GetSerializedContent(contact));
        }

        public async void RemoveAsync(ContactDto contact)
        {
            var result =
                await HttpClient.SendAsync(
                    new HttpRequestMessage(HttpMethod.Delete, _apiUrl)
                    {
                        Content = GetSerializedContent(contact)
                    });
        }

        public async void EditAsync(ContactDto contactDto)
        {
            await HttpClient.PutAsync(_apiUrl, GetSerializedContent(contactDto));
        }

        private HttpContent GetSerializedContent(ContactDto dto)
        {
            var myContent = JsonConvert.SerializeObject(dto);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}